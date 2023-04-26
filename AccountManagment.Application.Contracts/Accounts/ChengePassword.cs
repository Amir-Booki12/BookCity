

using _01_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Accounts
{
    public class ChengePassword
    {

        public long Id { get; set; }
        public string Password { get; set; }


        [Compare("Password",ErrorMessage = "پسورد و تکرار آن با هم مطابقت ندارند")]
        public string RePassword { get; set; }

    }
}
