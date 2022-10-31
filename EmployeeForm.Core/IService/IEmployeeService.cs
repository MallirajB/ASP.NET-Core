using EmployeeForm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Core.IService
{
    public interface IEmployeeService
    {
        void CreateMethod(EmployeeDetails employeeDetails);
        EmployeeDetails EditMethod(int employeeId);
        List<EmployeeDetails> ListMethod();
        void DeleteMethod(int employeeId);
        List<EmployeeDetails> SearchMethod(string name);
        List<Location> GetDropdown();

    }
}
