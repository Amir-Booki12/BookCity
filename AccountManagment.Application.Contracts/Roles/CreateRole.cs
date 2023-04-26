using _01_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Roles
{
    public class CreateRole
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
    }
}
