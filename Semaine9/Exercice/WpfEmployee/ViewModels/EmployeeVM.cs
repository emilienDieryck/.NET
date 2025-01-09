using System;
using System.Collections.Generic;
using System.Linq;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM
    {

        // create new instance to get access to the NorthwindContext
        private NorthwindContext dc = new NorthwindContext();
        // create a list of EmployeeModel to use as the DataContext for the MainWindow
        private List<EmployeeModel> _EmployeesList;
        // create a list of string to use as the DataContext for the Title ComboBox
        private List<String> _listTitle;

        /**
         * EmployeesList is a property that returns a list of EmployeeModel
         * if the list is null, it will call the loadEmployee method to load the list
         */
        public List<EmployeeModel> EmployeesList
        {
            get
            {
                return _EmployeesList = _EmployeesList ?? loadEmployee();
            }
        }

        /**
         * loadEmployee is a method that returns a list of EmployeeModel
         */
        private List<EmployeeModel> loadEmployee()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach (var emp in dc.Employees)
            {
                employees.Add(new EmployeeModel(emp));
            }
            return employees;
        }

        /**
         * ListTitle is a property that returns a list of string
         * if the list is null, it will call the loadTitle method to load the list
         */
        public List<String> ListTitle
        {
            get
            {
                return _listTitle = _listTitle ?? loadTitle();
            }
        }

        /**
         * loadTitle is a method that returns a list of string
         */
        private List<String> loadTitle()
        {
            List<String> titles = new List<String>();
            foreach (var emp in dc.Employees)
            {
                titles.Add(emp.Title);
            }
            return titles.Distinct().ToList();
        }
    }
}