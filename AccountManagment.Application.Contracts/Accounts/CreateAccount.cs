

using _01_Framework.Application;
using AccountManagment.Application.Contracts.Roles;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Accounts
{
    public class CreateAccount
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string FullName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string UserName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        public IFormFile ProfilePhoto { get; set; }

        
        [Range(1, 1000, ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleId { get; set; }



        public List<RoleViewModel> Roles { get; set; }
    }
}
