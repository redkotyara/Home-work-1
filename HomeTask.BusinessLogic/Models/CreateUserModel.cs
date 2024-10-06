using System.ComponentModel.DataAnnotations;

namespace HomeTask.BusinessLogic.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}