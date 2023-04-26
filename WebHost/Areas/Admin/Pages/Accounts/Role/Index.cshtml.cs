using AccountManagment.Application.Contracts.Accounts;
using AccountManagment.Application.Contracts.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace WebHost.Areas.Admin.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        
        public List<RoleViewModel> Roles { get; set; }
        


        
        private readonly IRoleApplication _roleApplication;

        public IndexModel( IRoleApplication roleApplication)
        {
           
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            
            Roles = _roleApplication.List();
        }

        public IActionResult OnGetCreate()
        {
            var role = new CreateRole()
            {
                
           };
            return Partial("./Create", role);
        }

        public JsonResult OnPostCreate(CreateRole command)
        {
           var result= _roleApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _roleApplication.GetDetails(id);
            
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return new JsonResult(result);

        }


       

    }
}
