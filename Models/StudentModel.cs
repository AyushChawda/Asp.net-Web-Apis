using System.ComponentModel.DataAnnotations;

namespace Web_APIS.Models
{
    public class StudentModel
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        
        [Required]
        [Range(1,20)]
        public int age { get; set; }
        
        [Required]
        [Range(1,12)]
        public int standrad { get; set; }
    }
}
