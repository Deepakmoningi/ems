using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployeeRepo empRepo;

        public EmpController(IEmployeeRepo EMPRepo)
        {
            this.empRepo = EMPRepo;
        }

        [HttpPost("insert")]
        public IActionResult insertEmployee([FromBody] Employee empObj)
        {
            if (empObj == null)
            {
                return BadRequest();
            }
            else
            {
                var result = empRepo.insertEmployee(empObj);
                if (result != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        message = "Employee record inserted"
                    });
                }
                else
                {
                    return BadRequest();
                }

            }
        }

        [HttpPut("update")]
        public IActionResult updateEmployee([FromBody] Employee empObj)
        {
            if (empObj == null)
            {
                return BadRequest();
            }
            else
            {
                var result = empRepo.updateEmployee(empObj);
                if (result != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        message = "Employee record updated"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        message = "Employee not found"
                    });
                }

            }
        }

        //[HttpDelete("delete")]
        //public IActionResult deleteEmployee([FromBody] Employee empObj)
        //{
        //    if (empObj == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        var result = empRepo.deleteEmployee(empObj);
        //        if (result != null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                message = "Employee record Deleted"
        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                message = "Employee not found"
        //            });
        //        }

        //    }
        //}

        //[HttpDelete("delete/id")]
        [HttpDelete("delete/{id}")]
        public IActionResult deleteEmployee(int id)
        {
                var result = empRepo.deleteEmployee(id);
                if (result != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        message = "Employee record Deleted"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        message = "Employee not found"
                    });
                }
            
        }

        //[HttpPost("MonthlySalaryDistribution")]
        //public IActionResult GetMonthlySalary([FromQuery] int Emp_ID, DateTime month_year)
        //{
        //    var result = empRepo.GetMonthlySalary(Emp_ID, month_year);
        //    if (result == null)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            message = "Employee not found"
        //        });
        //    }
        //    else
        //    {
        //        if (result == "Success")
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                message = "Employee salary calculated"

        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                message = "Employee salary already calculated"
        //            });
        //        }
        //    }
        //}


        [HttpPost("GetMonthlySalarybyId")]
        public List<MonthlySlaryDistribution> GetMonthlySalarybyId(SalaryDTO salaryObj)
        {
            
            var result = empRepo.GetMonthlySalarybyId(salaryObj);
            if (result != null)
            {
                return result;
            }
            else if(result == null)
            {
                return new List<MonthlySlaryDistribution>();
            }
            else
            {
                return new List<MonthlySlaryDistribution>();
            }
        }


        //[HttpPost("GetWorkinghours")]
        //public IActionResult calculateWorkingHours([FromQuery] int empId, DateTime checkIn, DateTime checkOut)
        //{
        //    var result = empRepo.calculateWorkingHours(empId, checkIn, checkOut);
        //    if (result == null)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            message = "Employee not found"
        //        });
        //    }
        //    else
        //    {
        //        if (result == "success")
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                message = "Employee working hours calculated"
        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                message = "Employee working hours already calculated"
        //            });
        //        }
        //    }
        //}



        [HttpPost("GetWorkinghours")]
        public IActionResult calculateWorkingHours(AttendaceDTO attendaceObj)
        {
            var result = empRepo.calculateWorkingHours(attendaceObj);
            if (result == null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    message = "Employee not found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    message = "Employee working hours updated",
                    result
                });
            }
            
        }

        [HttpGet("GetAllEmployees")]
        public List<Employee> getEmployees()
        {
            var result = empRepo.getAllEmployees();
            if(result.Count>0)
            {
                return result;   
            }
            else
            {
                var emptyList = new List<Employee>();
                return emptyList;
            }
        }

        [HttpGet("GetEmployeebyid/{id}")]
        public List<Employee> getEmployee(int id)
        {
            var result = empRepo.getEmployeebyId(id);
            if (result!=null)
            {
                return result;
            }
            else if(result == null)
            {
                var emptyList = new List<Employee>();
                return emptyList;
            }
            else
            {
                var emptyList = new List<Employee>();
                return emptyList;
            }
        }


        [HttpGet("GetemployeeAttendacebyid/{id}")]
        public List<Attendance> getAttendance(int id)
        {
            var result = empRepo.getempAttendancebyid(id);
            if(result.Count>0)
            {
                result = result.OrderBy(x => x.Check_In_Time).ToList();
                return result;
                //return result.OrderBy(x=>x.Check_In_Time);

            }
            else
            {
                var emptyList = new List<Attendance>();
                return emptyList;
            }
        }

        

    }
}
