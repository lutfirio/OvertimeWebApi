using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IEmployeeRepository
    {
        bool Insert(EmployeeParam employeeParam);
        bool Update(int? Id, EmployeeParam employeeParam);
        bool UpdatePassword(int? Id, EmployeeParam employeeParam);
        bool UpdateBootcamp(int? Id, EmployeeParam employeeParam);
        bool UpdateQuetionAnswer(int? Id, EmployeeParam employeeParam);
        bool Delete(int? Id);
        List<Employee> Get();
        Employee Get(int? Id);
        Employee Login(string Username, string Password);
        Employee getUser(string Username, string Question, string Answer);
        bool ResetPassword(string Username, string Question, string Answer, EmployeeParam employeeParam);
        //List<Employee> GetManager();
    }
}
