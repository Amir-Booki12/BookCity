
using _0_Framework.Application;
using _01_Framework.Application;
using BlogManagment.Application.Contract.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;

namespace BlogManagment.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = GenerateSlug.Slugify(command.Slug);
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            var articleCategory = new ArticleCategory(command.Name, command.ShortDescription, pictureName,
                command.PictureAlt, command.PictureTitle, slug, command.Keyword, command.MetaDescription,
                command.CannicalAddress);

            _articleCategoryRepository.Add(articleCategory);
            _articleCategoryRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            if(articleCategory == null) 
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name&&x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = GenerateSlug.Slugify(command.Slug);
            var pictureName = _fileUploader.Upload(command.Picture, slug);

            articleCategory.Edit(command.Name, command.ShortDescription, pictureName,
                command.PictureAlt, command.PictureTitle, slug, command.Keyword, command.MetaDescription,
                command.CannicalAddress);

            _articleCategoryRepository.Save();
            return operation.Succedded();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
