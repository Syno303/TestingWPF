using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Models;
using MVVM.Commands;
using System.Collections.ObjectModel;
using System.Data;

namespace MVVM.ViewModels {
    public class EmployeeViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        EmployeeService employeeService;
        public EmployeeViewModel() {
            employeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            updateCommand = new RelayCommand(Update);
            searchCommand = new RelayCommand(Search);
            //searchCommand2 = new RelayCommand(Search2);
            deleteCommand = new RelayCommand(Delete);
            //Message = "";
        }


        private ObservableCollection<Employee> employees;

        private string message;

        public string Message {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private DataRow selectedRow;

        public DataRow SelectedRow {
            get { return selectedRow; }
            set { selectedRow = value; OnPropertyChanged("SelectedRow"); }
        }


        public ObservableCollection<Employee> Employees {
            get { return employees; }
            set { employees = value; OnPropertyChanged("Employees"); }
        }

        private void LoadData() {
            Employees = employeeService.GetAll();
        }

        private Employee currentEmployee;
        public Employee CurrentEmployee { get { return currentEmployee; } set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); } }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand {
            get { return saveCommand; }

        }

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand {
            get { return updateCommand; }

        }

        private RelayCommand searchCommand;

        public RelayCommand SearchCommand {
            get { return searchCommand; }

        }
               

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand {
            get { return deleteCommand; }

        }

        public void Save() {
            try {
                var IsSaved = employeeService.Add(CurrentEmployee);
                LoadData();
                CurrentEmployee = new Employee();

                if (IsSaved) {
                    Message = "Saved";
                } else {
                    Message = "Save Error";
                }

            } catch (Exception ex) {
                Message = ex.Message;
            }
        }

        public void Update() {
            try {
                if (employeeService.Update(CurrentEmployee)) {
                    Message = "Updated";
                    LoadData();

                } else {
                    Message = "Error Updating";
                }

            } catch (Exception ex) {
                Message = ex.Message;
            }
        }

        public void Search() {
            try {
                Employee found = employeeService.Search(CurrentEmployee.Id);
                if (found!=null) {
                    CurrentEmployee = found;
                }
                
            } catch (Exception ex) {
                Message = ex.Message;
            }
        }

        public void Delete() {
            try {
                if (employeeService.Delete(CurrentEmployee.Id)) {
                    Message = "Deleted";
                    LoadData();
                } else {
                    Message = "Error Deleting";
                }


            } catch (Exception ex) {
                Message = ex.Message;
            }
        }

    }
}
