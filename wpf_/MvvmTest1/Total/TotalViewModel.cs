using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvvmTest1.Total
{
    public class TotalViewModel : ObservableObject, IPageViewModel
    {
        public ObservableCollection<ContainerInfo> ContainerInfos { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand LogCommand { get; set; }

        public TotalViewModel()
        {
            ContainerInfos = new ObservableCollection<ContainerInfo>();

            AddCommand = new RelayCommand(Add);
            ClearCommand = new RelayCommand(Clear);
            LogCommand = new RelayCommand(Log);

            Ip = "127.0.0.1";

            var utcNow = DateTime.UtcNow;
            var utcYesterday = utcNow.AddDays(-1);

            SinceDateTimeValue = utcYesterday.ToString("yyyy-MM-dd-HH-mm-ss");
            UntilDateTimeValue = utcNow.ToString("yyyy-MM-dd-HH-mm-ss");
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

        string _sinceDateTimeValue;
        public string SinceDateTimeValue
        {
            get
            {
                return _sinceDateTimeValue;
            }
            set
            {
                if (_sinceDateTimeValue != value)
                {
                    _sinceDateTimeValue = value;
                    RaisePropertyChanged("SinceDateTimeValue");
                }
            }
        }

        string _untilDateTimeValue;
        public string UntilDateTimeValue
        {
            get
            {
                return _untilDateTimeValue;
            }
            set
            {
                if (_untilDateTimeValue != value)
                {
                    _untilDateTimeValue = value;
                    RaisePropertyChanged("UntilDateTimeValue");
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

        private void Add(object parameter)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occured\n\n\n Message = {ex.Message}\n\n StackTrace = {ex.StackTrace}");
            }
        }

        private void Log(object parameter)
        {
            try
            {
                if (SelectedContainer is null)
                    throw new Exception("Not Selected");

                string[] sinceDateTime = SinceDateTimeValue.Split('-');
                string[] untilDateTime = UntilDateTimeValue.Split('-');

                var sinceTimeSpan = (new DateTime(
                    Int32.Parse(sinceDateTime[0]), Int32.Parse(sinceDateTime[1]), 
                    Int32.Parse(sinceDateTime[2]), Int32.Parse(sinceDateTime[3]), 
                    Int32.Parse(sinceDateTime[4]), Int32.Parse(sinceDateTime[5])) - new DateTime(1970, 1, 1));

                var untilTimeSpan = (new DateTime(
                   Int32.Parse(untilDateTime[0]), Int32.Parse(untilDateTime[1]),
                   Int32.Parse(untilDateTime[2]), Int32.Parse(untilDateTime[3]),
                   Int32.Parse(untilDateTime[4]), Int32.Parse(untilDateTime[5])) - new DateTime(1970, 1, 1));

                long since = (long)sinceTimeSpan.TotalSeconds;
                long until = (long)untilTimeSpan.TotalSeconds;

                string url = $"http://{SelectedContainer.Ip}:4243/containers/{SelectedContainer.Id}/logs?stdout=true&since={since}&until={until}";
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

                var win = new Log { DataContext = new LogViewModel { Message = responseText } };
                win.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occured\n\n\n Message = {ex.Message}\n\n StackTrace = {ex.StackTrace}");
            }
        }

        private void Clear(object parameter)
        {
            ContainerInfos.Clear();
        }
    }
}