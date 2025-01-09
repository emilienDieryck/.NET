using System;
using System.ComponentModel;

namespace WpfEmployee.Models
{
    public class EmployeeModel
    {
        private readonly Employee _employee;

        // constructor that take en Employee object as parameter
        public EmployeeModel(Employee employee)
        {
            _employee = employee;
        }

        public string FullName
        {
            get
            {
                return _employee.FirstName + " " + _employee.LastName;
            }
        }

        public int EmployeeId
        {
            get { return _employee.EmployeeId; }
        }

        /**
         * DisplayBirthDate is a property that returns the BirthDate of the Employee
         * if the BirthDate is null, it will return "N/A"
         */
        public String DisplayBirthDate
        {
            get
            {
                return _employee.BirthDate.HasValue ? _employee.BirthDate.Value.ToShortDateString() : "N/A";
            }
        }

        /**
         * LastName is a property that returns the LastName of the Employee
         */
        public String LastName
        {
            get { return _employee.LastName; }
            set { _employee.LastName = value; }
        }

        /**
         * FirstName is a property that returns the FirstName of the Employee
         */
        public String FirstName
        {
            get { return _employee.FirstName; }
            set { _employee.FirstName = value; }
        }

        /**
         * Title is a property that returns the Title of the Employee
         */
        public String TitleOfCourtesy
        {
            get { return _employee.TitleOfCourtesy; }
            set { _employee.TitleOfCourtesy = value; }
        }

        /**
         * BirthDate is a property that returns the BirthDate of the Employee
         */
        public DateTime? BirthDate
        {
            get { return _employee.BirthDate; }
            set { _employee.BirthDate = value; }
        }

        /**
         * HireDate is a property that returns the HireDate of the Employee
         */
        public DateTime? HireDate
        {
            get { return _employee.HireDate; }
            set { _employee.HireDate = value; }
        }
    }
}


