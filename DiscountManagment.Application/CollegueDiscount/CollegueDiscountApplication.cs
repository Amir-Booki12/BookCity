
using _01_Framework.Application;
using DiscountManagment.Application.Contract.CollegueDiscount;
using DiscountManagment.Domain.CollegueDiscount;


namespace DiscountManagment.Application.CollegueDiscount
{
    public class CollegueDiscountApplication : IInventoryApplication
    {
        private readonly ICollegueDiscountRepository _collegueDiscountRepository;

        public CollegueDiscountApplication(ICollegueDiscountRepository collegueDiscountRepository)
        {
            _collegueDiscountRepository = collegueDiscountRepository;
        }

        public OperationResult Create(CreateCollegueDiscount command)
        {
            var operation = new OperationResult();

            if (_collegueDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
            x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var collegueDiscount = new Domain.CollegueDiscount.CollegueDiscount(command.ProductId,
                command.DiscountRate, command.Reason);

            _collegueDiscountRepository.Add(collegueDiscount);
            _collegueDiscountRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCollegueDiscount command)
        {
            var operation = new OperationResult();
            var collegueDiscount = _collegueDiscountRepository.GetBy(command.Id);

            if (collegueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            if (_collegueDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
            x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            collegueDiscount.Edit(command.ProductId,
                command.DiscountRate, command.Reason);

            _collegueDiscountRepository.Save();
            return operation.Succedded();
        }

        public EditCollegueDiscount GetDetails(long id)
        {
            return _collegueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var collegueDiscount = _collegueDiscountRepository.GetBy(id);

            if (collegueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            collegueDiscount.Remove();

            _collegueDiscountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var collegueDiscount = _collegueDiscountRepository.GetBy(id);

            if (collegueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            collegueDiscount.Restore();

            _collegueDiscountRepository.Save();
            return operation.Succedded();
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel)
        {
            return _collegueDiscountRepository.Search(searchModel);
        }
    }
}
