using EmployeeForm.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Create
        [HttpGet]
        public IActionResult CreateForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateForm(EmployeeDetails employeeDetails)
        {
              using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7019/api/EmployeeApi/CreateForm");
                    var Posttask = client.PostAsJsonAsync(client.BaseAddress, employeeDetails);
                    Posttask.Wait();
                    var result = Posttask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listform");
                    }
                }
            
            return RedirectToAction("ListForm");
        }
        #endregion

        #region List
        [HttpGet]
        public IActionResult ListForm()
        {
            //IList<EmployeeDetails> value = null;
           IList<EmployeeDetails>? Employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7019/api/EmployeeAPI/ListForm");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<EmployeeDetails>>();
                    readTask.Wait();

                    Employee = readTask.Result;
                }
                return View(Employee);
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult EditForm(int employeeid)
        {
            EmployeeDetails? Employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7019/api/EmployeeAPI/EditForm?employeeId=");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress + employeeid.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<EmployeeDetails>();
                    readTask.Wait();

                    Employee = readTask.Result;
                }
            }
            return View("CreateForm", Employee);
        }
        #endregion

        #region Delete
        public IActionResult DeleteForm(int employeeid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7019/api/EmployeeAPI/DeleteForm?employeeId=");
                //HTTP GET
                var deleteTask = client.DeleteAsync(client.BaseAddress + employeeid.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListForm");
                }
            }
            return RedirectToAction("ListForm");
        }
        #endregion
    }
}
