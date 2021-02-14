using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wpf.Mvvm;
using Wpf.Mvvm.Interface;
using Wpf.Basic.Data;

namespace Wpf.Basic.View
{
    public class DataGridViewModel : IPageViewModel
    {
        #region Data
        public ObservableCollection<DataGridRow> GridData { get; set; }
        public ObservableCollection<DataGridRow> SelectedRows { get; set; }
        public DataGridRow NewRow { get; set; }
        #endregion

        #region Command
        public ICommand AddRowCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        public DataGridViewModel()
        {
            GridData = new ObservableCollection<DataGridRow>();
            SelectedRows = new ObservableCollection<DataGridRow>();
            NewRow = new DataGridRow();
            AddRowCommand = new RelayCommand(AddRow);
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand(Delete);
        }

        public void AddRow(object parameter)
        {
            GridData.Add(new DataGridRow(NewRow));
        }

        public void Refresh(object parameter)
        {
            GridData.Clear();
        }

        public void Delete(object parameter)
        {
            foreach (var selectedRow in SelectedRows)
                GridData.Remove(selectedRow);
        }
    }
}
