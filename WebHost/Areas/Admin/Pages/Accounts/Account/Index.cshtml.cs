using AccountManagment.Application.Contracts.Accounts;
using AccountManagment.Application.Contracts.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace WebHost.Areas.Admin.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        public AccountSearchModel searchModel;
        public List<AccountViewModel> Accounts { get; set; }
        public SelectList Roles { get; set; }


        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
            Accounts = _accountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var account = new CreateAccount()
            {
                Roles = _roleApplication.List()
           };
            return Partial("./Create", account);
        }

        public JsonResult OnPostCreate(CreateAccount command)
        {
           var result= _accountApplication.Create(command);
            
            return new JsonResult(result);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _accountApplication.GetDetails(id);
            command.Roles = _roleApplication.List();
            return Partial("./Edit",command);
        }

        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);

        }


        public IActionResult OnGetChengePassword(long id)
        {
            var command = new ChengePassword{Id=id };
            
            return Partial("./ChengePassword", command);
        }

        public JsonResult OnPostChengePassword(ChengePassword command)
        {
            var result = _accountApplication.ChengePassword(command);
            return new JsonResult(result);

        }

    }
}
