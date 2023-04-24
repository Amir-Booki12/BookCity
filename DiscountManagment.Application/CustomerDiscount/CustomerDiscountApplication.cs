

using _01_Framework.Application;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscount;


namespace DiscountManagment.Application.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
      private readonly  ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Create(CreateCustomerDiscount Command)
        {
            var operation = new OperationResult();
            if(_customerDiscountRepository.Exists(x=>x.ProductId == Command.ProductId && x.DiscountRate==Command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var startDate = Tools.ToGeorgianDateTime(Command.StartDate);
            var endDate = Tools.ToGeorgianDateTime(Command.EndDate);

            var customerDiscount = new Domain.CustomerDiscount.CustomerDiscount(Command.ProductId,
                Command.DiscountRate, startDate, endDate, Command.Reason);

            _customerDiscountRepository.Add(customerDiscount);
            _customerDiscountRepository.Save();
            return operation.Succedded();
            
        }

        public OperationResult Edit(EditCustomerDiscount Command)
        {
            var operation = new OperationResult();
            var customerDiscount = _customerDiscountRepository.GetBy(Command.Id);

            if(customerDiscount == null) 
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountRepository.Exists(x => x.ProductId == Command.ProductId && 
            x.DiscountRate == Command.DiscountRate&&x.Id != Command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var startDate = Tools.ToGeorgianDateTime(Command.StartDate);
            var endDate = Tools.ToGeorgianDateTime(Command.EndDate);

            customerDiscount.Edit(Command.ProductId,
                Command.DiscountRate, startDate, endDate, Command.Reason);

            _customerDiscountRepository.Save();
            return operation.Succedded();

        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);

        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
