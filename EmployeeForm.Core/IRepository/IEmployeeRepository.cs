using EmployeeForm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Core.IRepository
{
   public interface IEmployeeRepository
    {
        void CreateMethod(EmployeeDetails employeeDetails);
        EmployeeDetails EditMethod(int employeeId);
        List<EmployeeDetails> ListMethod();
        void DeleteMethod(int employeeId);
    }
}
