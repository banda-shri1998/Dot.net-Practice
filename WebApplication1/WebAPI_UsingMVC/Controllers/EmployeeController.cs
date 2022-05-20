using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI_UsingMVC.Models;

namespace WebAPI_UsingMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        string BaseURL = "https://localhost:44309/";
        public async Task<ActionResult> Index() {
            List<Employee> employees = new List<Employee>();
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    var EmployeeRes = response.Content.ReadAsStringAsync().Result;
                    employees = JsonConvert.DeserializeObject<List<Employee>>(EmployeeRes);
                }
                return View(employees);
            }
            //return View();
        }
        public async Task<ActionResult> GetByID(int id) {
            Employee e = new Employee();
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"api/Employee/{id}");
                if (response.IsSuccessStatusCode) {
                    var empRes = response.Content.ReadAsStringAsync().Result;
                    e = JsonConvert.DeserializeObject<Employee>(empRes);
                }
                return View(e);
            }
        }
        public ActionResult Create() {
            return View();        
        }
        [HttpPost]
        public ActionResult Create(Employee e) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://localhost:44309/api/Employee");
                var postTask = client.PostAsJsonAsync<Employee>("Employee", e);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Server Error !! Try again later.");
                return View(e);
            }
        }
        public ActionResult Edit(int id)
        {
            Employee emp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44353/api/");
                var responsetask = client.GetAsync("Employees?id=" + id.ToString());
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Employee>();
                    readtask.Wait();
                    emp = readtask.Result;

                }
            }

            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44353/api/");
                var putTask = client.PutAsJsonAsync<Employee>($"Employees/{employee.ID}", employee);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "server Error. pls try after sometime");
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44353/api/");
                var deletetask = client.DeleteAsync("Employees?id=" + id.ToString());
                deletetask.Wait();
                var result = deletetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }
            return View();
        }
    }
}