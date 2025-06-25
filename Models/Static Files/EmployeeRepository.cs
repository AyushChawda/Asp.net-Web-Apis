using Web_APIS.Models;

namespace Web_APIS.Models.Static_Files
{
    public class EmployeeRepository
    {
        public static List<EmployeeModel> EmployeeList=new List<EmployeeModel>()
            {
                new EmployeeModel
                {
                    id=101,
                    empName="Ayush",
                    empPosition="Developer",
                    empCode=200121
                },
                new EmployeeModel
                {
                    id=102,
                    empName="Shivani",
                    empPosition="Manager",
                    empCode=220012
                },
                new EmployeeModel
                {
                    id = 201,
                    empName = "Aishish",
                    empPosition = "Sals manager",
                    empCode = 200321
                }
            };
    }
}
