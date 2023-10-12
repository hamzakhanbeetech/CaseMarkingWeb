using System.ComponentModel.DataAnnotations;

namespace Case_Marking_Web_Application.Models
{
    public class Signin
    {
        [Required(ErrorMessage = "Please Enter Your UserName")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
