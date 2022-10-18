using EmployeeForm.Core.IService;
using EmployeeForm.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeFormAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeAPIController : Controller
    {
        private readonly IEmployeeService _EmployeeServices;
        public EmployeeAPIController(IEmployeeService _EmployeeServices)
        {

            this._EmployeeServices = _EmployeeServices;
        }
        #region Create
        [HttpPost]
        public IActionResult CreateForm(EmployeeDetails registration)
        {
            _EmployeeServices.CreateMethod(registration);
            return Ok(registration);
        }
        #endregion

        #region List
        [HttpGet]
        public IActionResult ListForm()
        {
           var data= _EmployeeServices.ListMethod();
            return Ok(data);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult EditForm(int employeeId)
        {
           var value= _EmployeeServices.EditMethod(employeeId);
            return Ok(value) ;
        }
        #endregion

        #region Delete
        [HttpDelete]
        public IActionResult DeleteForm(int employeeId)
        {
            _EmployeeServices.DeleteMethod(employeeId);
            return Ok();
        }
        #endregion
    }
}
