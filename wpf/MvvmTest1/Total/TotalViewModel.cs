using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvvmTest1.Total
{
    public class TotalViewModel : ObservableObject, IPageViewModel
    {
        public ObservableCollection<ContainerInfo> ContainerInfos { get; set; }
        public RelayCommand CheckCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand LogCommand { get; set; }

        public TotalViewModel()
        {
            ContainerInfos = new ObservableCollection<ContainerInfo>();

            CheckCommand = new RelayCommand(Check);
            ClearCommand = new RelayCommand(Clear);
            LogCommand = new RelayCommand(Log);

            Ip = "127.0.0.1";
            DateTimeValue = "2020-04-30-15-00-00";
        }

        public string Name
        {
            get { return "Total"; }
        }

        string _nodeName;
        public string NodeName
        {
            get
            {
                return _nodeName;
            }
            set
            {
                if (_nodeName != value)
                {
                    _nodeName = value;
                    RaisePropertyChanged("NodeName");
                }
            }
        }

        string _ip;
        public string Ip
        {
            get
            {
                return _ip;
            }
            set
            {
                if (_ip != value)
                {
                    _ip = value;
                    RaisePropertyChanged("Ip");
                }
            }
        }

        string _dateTimeValue;
        public string DateTimeValue
        {
            get
            {
                return _dateTimeValue;
            }
            set
            {
                if (_dateTimeValue != value)
                {
                    _dateTimeValue = value;
                    RaisePropertyChanged("DateTimeValue");
                }
            }
        }

        private ContainerInfo _selectedContainer;
        public ContainerInfo SelectedContainer
        {
            get
            {
                return _selectedContainer;
            }
            set
            {
                if (_selectedContainer != value)
                {
                    _selectedContainer = value;
                    RaisePropertyChanged("SelectedContainer");
                }
            }
        }

        private void Check(object parameter)
        {
            string url = $"http://{Ip}:4243/containers/json";
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 30 * 1000;

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                if (status != HttpStatusCode.OK)
                {
                    MessageBox.Show("");
                    return;
                }

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }

            }

            List<JObject> jsonList = JsonConvert.DeserializeObject<List<JObject>>(responseText);

            foreach (var item in jsonList)
            {
                ContainerInfos.Add(new ContainerInfo
                {
                    NodeName = NodeName,
                    Ip = Ip,
                    Name = item.GetValue("Names")[0].ToString(),
                    Status = item.GetValue("Status").ToString(),
                    Id = item.GetValue("Id").ToString()
                });
            }
        }

        private void Log(object parameter)
        {
            if (SelectedContainer is null)
            {
                MessageBox.Show("Not Selected");
                return;
            }

            string[] time = DateTimeValue.Split('-');

            var timeSpan = (new DateTime(
                Int32.Parse(time[0]), Int32.Parse(time[1]), Int32.Parse(time[2]),
                Int32.Parse(time[3]), Int32.Parse(time[4]), Int32.Parse(time[5])) - new DateTime(1970, 1, 1));

            long total = (long)timeSpan.TotalSeconds;

            string url = $"http://{SelectedContainer.Ip}:4243/containers/{SelectedContainer.Id}/logs?stdout=true&since={total}";
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 30 * 1000;

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                if (status != HttpStatusCode.OK)
                {
                    MessageBox.Show("");
                    return;
                }

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }

            }

            var win = new Log { DataContext = new LogViewModel { Message = responseText} };
            win.Show();
        }

        private void Clear(object parameter)
        {
            ContainerInfos.Clear();
        }
    }
}