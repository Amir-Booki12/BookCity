
using _0_Framework.Application;
using _01_Framework.Application;
using ShopManagment.Application.Contract.slide;
using ShopManagment.Domain.SlideAgg;


namespace ShopManagment.Application.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            var pictureName = _fileUploader.Upload(command.Picture, "slides");
           
            var slide = new Domain.SlideAgg.Slide(command.Title,command.Link,command.Text, command.Header, command.BtnText,
                pictureName, command.PictureAlt, command.PictureTitle);

            _slideRepository.Add(slide);
            _slideRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(command.Id);
            if (slide == null)          
                operation.Failed("گزینه مورد نظر یافت نشد...");

            var pictureName = _fileUploader.Upload(command.Picture, "slides");

            slide.Edit(command.Title, command.Link,command.Text, command.Header, command.BtnText,
                pictureName, command.PictureAlt, command.PictureTitle);

            _slideRepository.Save();
            return operation.Succedded();
           
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);
            if (slide == null)
                operation.Failed("گزینه مورد نظر یافت نشد...");

            slide.Remove();

            _slideRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);
            if (slide == null)
                operation.Failed("گزینه مورد نظر یافت نشد...");

            slide.Restore();

            _slideRepository.Save();
            return operation.Succedded();
        }

        public List<SlideViewModel> Search(SlideSearchModel searchModel)
        {
            return _slideRepository.Search(searchModel);
        }
    }
}
