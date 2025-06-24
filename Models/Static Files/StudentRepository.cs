namespace Web_APIS.Models
{
    public class StudentRepository
    {
        public static List<StudentModel> Students= new List<StudentModel>(){
                new StudentModel
                {
                    id=10,
                    name="Ayush",
                    age=15,
                    standrad=10
                },

                new StudentModel
                {
                    id=101,
                    name="Shivam",
                    age=12,
                    standrad=8
                }
        };
    }
}
