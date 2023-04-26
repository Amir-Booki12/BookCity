

using _0_Framework.Application;
using _01_Framework.Application;
using AccountManagment.Application.Contracts.Accounts;
using AccountManagment.Domain.AccountAgg;

namespace AccountManagment.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
        }

        public OperationResult ChengePassword(ChengePassword command)
        {
            var operation = new OperationResult();  

            var account = _accountRepository.GetBy(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);

            account.ChengePassword(password);
            _accountRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Create(CreateAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.UserName == command.UserName & x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var pictureName = _fileUploader.Upload(command.ProfilePhoto, "ProfilePhoto");

            var account = new Account(command.FullName,command.UserName, command.Mobile,
                password,command.RoleId, pictureName);

            _accountRepository.Add(account);    
            _accountRepository.Save();
            return operation.Succedded();   
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();

            var account = _accountRepository.GetBy(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x => x.UserName == command.UserName &&
            x.Mobile == command.Mobile&&x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var pictureName = _fileUploader.Upload(command.ProfilePhoto, "ProfilePhoto");

            account.Edit(command.FullName,command.UserName,command.Mobile,command.RoleId, pictureName);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
           return _accountRepository.GetDetails(id);    
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
