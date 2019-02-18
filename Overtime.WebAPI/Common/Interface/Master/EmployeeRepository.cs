using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Employee employee = new Employee();
        MyContext myContext = new MyContext();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Employee employee = Get(Id);
            employee.IsDelete = true;
            employee.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Employee> Get()
        {
            var get = from m in myContext.Employees join e in myContext.Employees on m.Managers_Id equals e.Id select m;
            return get.ToList();
            //select m.First_Name as "employee", e.First_Name as "manager" from Employees e join Employees m on e.Id = m.Managers_Id;

        }

        public Employee Get(int? Id)
        {
            Employee employee = myContext.Employees.Where(x => x.Id == Id).SingleOrDefault();
            return employee;
        }

        //public List<Employee> GetManager()
        //{
        //    var getManager = myContext.Employees.Where(x => x.Positions.Name == "Managers" && x.IsDelete == false).ToList();
        //    return getManager;            
        //}

        public Employee getUser(string Username, string Question, string Answer)
        {
            return myContext.Employees.FirstOrDefault(x => x.Username == Username && x.Question == Question && x.Answer == Answer);
        }

        public bool Insert(EmployeeParam employeeParam)
        {
            var result = 0;
            var employee = new Employee();
            employee.First_Name = employeeParam.First_Name;
            employee.Last_Name = employeeParam.Last_Name;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Address = employeeParam.Address;
            employee.Postal_Code = employeeParam.Postal_Code;
            employee.Salary = employeeParam.Salary;
            employee.Phone = employeeParam.Phone;
            employee.Positions = myContext.Positions.Find(employeeParam.Positions);
            //employee.Managers = myContext.Employees.Find(employeeParam.Managers_Id);
            employee.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Employees.Add(employee);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee Login(string Username, string Password)
        {
            return myContext.Employees.FirstOrDefault(x => x.Username.Equals(Username) && x.Password.Equals(Password) && x.IsDelete == false);
        }

        public bool ResetPassword(string Username, string Question, string Answer, EmployeeParam employeeParam)
        {
            var result = 0;
            Employee employee = getUser(Username, Question, Answer);
            employee.Password = employeeParam.Password;
            result = myContext.SaveChanges();
            if (result >0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, EmployeeParam employeeParam)
        {
            var result = 0;
            var get = Get(Id);
            get.First_Name = employeeParam.First_Name;
            get.Last_Name = employeeParam.Last_Name;
            get.Username = employeeParam.Username;
            get.Password = employeeParam.Password;
            get.Address = employeeParam.Address;
            get.Postal_Code = employeeParam.Postal_Code;
            get.Salary = employeeParam.Salary;
            get.Phone = employeeParam.Phone;
            get.Positions = myContext.Positions.Find(employeeParam.Positions);
            //get.Managers = myContext.Employees.Find(employeeParam.Managers_Id);
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBootcamp(int? Id, EmployeeParam employeeParam)
        {
            var result = 0;
            var get = Get(Id);
            employee.Question = employeeParam.Question;
            employee.Answer = employeeParam.Answer;
            employee.Password = employeeParam.Password;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return status;
        }

        public bool UpdatePassword(int? Id, EmployeeParam employeeParam)
        {
            var result = 0;
            var get = Get(Id);
            employee.Password = employeeParam.Password;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return status;
        }

        public bool UpdateQuetionAnswer(int? Id, EmployeeParam employeeParam)
        {
            var result = 0;
            var get = Get(Id);
            employee.Question = employeeParam.Question;
            employee.Answer = employeeParam.Answer;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return status;

        }
    }
}
