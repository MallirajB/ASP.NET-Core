using EmployeeForm.Core.Model;
using EmployeeForm.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
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

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7019/api/EmployeeAPI/GetDetail");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Location>>();
                    readTask.Wait();

                    ViewBag.Location = readTask.Result;
                }
            }
            //List<EmployeeLocation> locations = db.EmployeeLocation.ToList();
            //ViewBag.location = new SelectList(locations, "LocationId", "Employee_Work_Location");
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
                List<EmployeeDetails> SortedList = Employee.OrderBy(o => o.FirstName).ToList();
                return View(SortedList);
            }
        }
        #endregion

        #region _DetailPartial
        public IActionResult _DetailPartial(int employeeid)

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
            return PartialView(Employee);
        }
        #endregion

        #region SearchForm
        [HttpGet]
        public IActionResult SearchForm(string name)
        {
            //IList<EmployeeDetails> value = null;
            IList<EmployeeDetails>? Employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7019/api/EmployeeAPI/SearchForm?name=");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress + name);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<EmployeeDetails>>();
                    readTask.Wait();

                    Employee = readTask.Result;
                }
                return View("ListForm", Employee);
            }
        }

        #endregion

        #region Edit
        [HttpGet]
        public IActionResult EditForm(int employeeid)
        {
            CreateForm();
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
