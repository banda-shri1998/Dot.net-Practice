using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class EmployeeController : ApiController
    {

        public IEnumerable<Employee> Get() {
            using (MVC_DBEntities1 e = new MVC_DBEntities1())
            {
                return e.Employees.ToList();
            }
        }
        public Employee Get(int id) {
            using (MVC_DBEntities1 e = new MVC_DBEntities1()) {
                return e.Employees.FirstOrDefault(a => a.ID == id);
            }
        }

        public HttpResponseMessage Post([FromBody] Employee emp) {
            try
            {
                using (MVC_DBEntities1 e = new MVC_DBEntities1())
                {
                    e.Employees.Add(emp);
                    e.SaveChanges();
                    var msg = Request.CreateResponse(HttpStatusCode.OK, emp);
                    msg.Headers.Location = new Uri(Request.RequestUri + emp.ID.ToString());
                    return msg;
                }
            }
            catch (Exception E) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, E);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody] Employee emp) {
            try
            {
                using (MVC_DBEntities1 entities1 = new MVC_DBEntities1())
                {
                    Employee em = entities1.Employees.FirstOrDefault(e=>e.ID==id);
                    if (em == null) 
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "employee id " + id + " Not found");
                    }
                    else
                    {
                        em.Name = emp.Name;
                        em.Designation = emp.Designation;
                        em.Salary = emp.Salary;
                        //entities1.Employees.Attach(em);
                        //entities1.Entry(em).State = System.Data.Entity.EntityState.Modified;
                        entities1.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK,em);
                    }
                }
            }
            catch (Exception E)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, E);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (MVC_DBEntities1 entities1 = new MVC_DBEntities1())
                {
                    Employee em = entities1.Employees.Find(id);
                    if (em == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,"employee id "+id+" Not found");
                    }
                    else
                    {
                        entities1.Employees.Remove(em);
                        entities1.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, em.Name.ToString());
                    }
                }
            }
            catch (Exception E)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, E);
            }
        } 
    }
}
