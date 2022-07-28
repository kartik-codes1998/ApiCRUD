using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiCRUD.Models;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    { 
        [HttpGet]
        public ActionResult Get()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees();

            return Ok(obj);
        }



        // GET: api/<EmployeeController>

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.Id == id);
            return Ok(row);
        }

        // POST api/<EmployeeController>
        [HttpPost("create")]

        public ActionResult Post(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {

                        //The inserted data will be clear after clear function.
                        ModelState.Clear();
                        return RedirectToAction("Post");
                    }
                }
                return Ok(200);
            }
            catch
            {
                return RedirectToAction("Post");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            if(ModelState.IsValid == true)
            {
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.UpdateEmployee(emp);
                if(check == true)
                {
                    ModelState.Clear();
                    return RedirectToAction("Get");
                }
            }
            return Ok(200);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, Employee emp)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            bool check = context.DeleteEmployee(id);
            if (check == true)
            {
                var msg = "Data Deleted";
                return Ok(msg) ;
            }
            return null;
        }
    }
}
