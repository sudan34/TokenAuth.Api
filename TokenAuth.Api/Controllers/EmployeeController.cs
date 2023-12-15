using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuth.Api.Data;
using TokenAuth.Api.Models;

namespace TokenAuth.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        [Authorize(Roles =("User"))]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            var user = dbContext.Employees.FirstOrDefault(x => x.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = ("Admin, SuperAdmin"))]
        [Route("api/Employee/GetSomeEmployee")]
        public HttpResponseMessage GetSomeEmployee()
        {
            var user = dbContext.Employees.FirstOrDefault(x => x.Id <= 10);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = ("SuperAdmin"))]
        [Route("api/Employee/GetEmployees")]
        public HttpResponseMessage GetEmployees()
        {
            var user = dbContext.Employees.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
