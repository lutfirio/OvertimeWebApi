using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using Common.Interface;

namespace BussinessLogic.Service.Master
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _employeeRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        public Employee Get(int? Id)
        {
            var getEmployeeId = _employeeRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getEmployeeId;
        }

        //public List<Employee> GetManager()
        //{          
        //    return _employeeRepository.GetManager();
        //}

        public Employee getUser(string Username, string Question, string Answer)
        {
            return _employeeRepository.getUser(Username, Question, Answer);
        }

        public bool Insert(EmployeeParam employeeParam)
        {
            if (employeeParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _employeeRepository.Insert(employeeParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public Employee Login(string Username, string Password)
        {
            return _employeeRepository.Login(Username, Password);
        }

        public bool ResetPassword(string Username, string Question, string Answer, EmployeeParam employeeParam)
        {
            return _employeeRepository.ResetPassword(Username, Question, Answer, employeeParam);
        }

        public bool Update(int? Id, EmployeeParam employeeParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _employeeRepository.Update(Id, employeeParam);
                Console.WriteLine("update Success");
            }
            return status;
        }

        public bool UpdateBootcamp(int? Id, EmployeeParam employeeParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _employeeRepository.UpdateBootcamp(Id, employeeParam);
                Console.WriteLine("update Success");
            }
            return status;
        }

        public bool UpdatePassword(int? Id, EmployeeParam employeeParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _employeeRepository.UpdatePassword(Id, employeeParam);
                Console.WriteLine("update Success");
            }
            return status;
        }

        public bool UpdateQuetionAnswer(int? Id, EmployeeParam employeeParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _employeeRepository.UpdateQuetionAnswer(Id, employeeParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
