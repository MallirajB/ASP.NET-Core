using EmployeeForm.Core.IRepository;
using EmployeeForm.Core.IService;
using EmployeeForm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Service
{
   public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository entry;

        public EmployeeService(IEmployeeRepository UserRepository)
        {
            entry = UserRepository;
        }
        #region Create
        public void CreateMethod(EmployeeDetails employeeDetails)
        {
            //business condition
            if (employeeDetails.FirstName != string.Empty && employeeDetails.FirstName != string.Empty)
            {
                entry.CreateMethod(employeeDetails);
            }
        }
        #endregion

        #region List
        public List<EmployeeDetails> ListMethod()
        {
            return entry.ListMethod();
        }
        #endregion

        #region Edit

        public EmployeeDetails EditMethod(int employeeId)
        {
            return entry.EditMethod(employeeId);
        }
        #endregion

        #region Delete
        public void DeleteMethod(int employeeId)
        {
            entry.DeleteMethod(employeeId);
        }
        #endregion
    }
}
