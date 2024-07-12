using System.ComponentModel.DataAnnotations;

namespace Employee.ViewModels
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Enter the First Name")]
        [Display(Name = "Enter First Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Za-z ]*$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter the Last Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Za-z ]*$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter the Salary")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Invalid Salary")]
        public string Salary { get; set; }
        public IFormFile Profile { get; set; }
    }
}
