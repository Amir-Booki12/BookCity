

using _0_Framework.Application;
using _01_Framework.Application;
using BlogManagment.Application.Contract.Article;
using BlogManagment.Application.Contract.ArticleCategory;
using BlogManagment.Domain.Article;
using BlogManagment.Domain.ArticleCategoryAgg;

namespace BlogManagment.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public List<ArticleCategoryViewModel> articleCategories()
        {
            return _articleRepository.articleCategories();
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if(_articleRepository.Exists(x=>x.Title==command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = GenerateSlug.Slugify(command.Slug);
            var categorySlug = _articleCategoryRepository.GetBySlug(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            
            var publishDate = Tools.ToGeorgianDateTime(command.PublishDate);
            var article = new Article(command.Title,command.Description,command.ShortDescription
                ,pictureName,command.PictureAlt,command.PictureTitle,slug,command.Keyword,
                command.MetaDesctiption,command.CannicalAddress,command.CategoryId, publishDate);

            _articleRepository.Add(article);
            _articleRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();

            var article = _articleRepository.GetWithCategorySlug(command.Id);
            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleRepository.Exists(x => x.Title == command.Title&&x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = GenerateSlug.Slugify(command.Slug);
            var categorySlug = article.Category.Name;
            var path = $"{categorySlug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = Tools.ToGeorgianDateTime(command.PublishDate);

            article.Edit(command.Title, command.Description, command.ShortDescription
                , pictureName, command.PictureAlt, command.PictureTitle, slug, command.Keyword,
                command.MetaDesctiption, command.CannicalAddress, command.CategoryId, publishDate);

            _articleRepository.Save();
            return operation.Succedded();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);   

        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
