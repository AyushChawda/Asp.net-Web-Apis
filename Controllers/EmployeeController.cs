using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_APIS.Models;
using Web_APIS.Models.DOTs;
using Web_APIS.Models.Static_Files;

namespace Web_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> getAllEmployee()
        {
            var EmployeeList = new List<EmployeeDTOs>();
            foreach(var item in EmployeeRepository.EmployeeList)
            {
                EmployeeDTOs obj = new EmployeeDTOs()
                {
                    id = item.id,
                    empName = item.empName,
                    empPosition = item.empPosition,

                };
                EmployeeList.Add(obj);
            }

            return Ok(EmployeeList);
        }
    }
}
