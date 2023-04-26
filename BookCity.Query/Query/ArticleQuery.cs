

using _01_Framework.Application;
using BlogManagment.Infrastucure.EfCore;
using BookCity.Query.Contract.Article;
using CommentManagment.Infrastucure.EfCore;
using Microsoft.EntityFrameworkCore;


namespace BookCity.Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public ArticlesQueryModel GetDetails(string slug)
        {
            var article = _blogContext.Articles.Include(x => x.Category).Select(x => new ArticlesQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                CannicalAddress = x.CannicalAddress,
                CategoryId = x.CategoryId,
                Keyword = x.Keyword,
                MetaDesctiption = x.MetaDesctiption,
                CategoryName = x.Category.Name,
                Slug = x.Slug,
                Title = x.Title,
                PublishDate = x.PublishDate.ToFarsi()
            }).FirstOrDefault(x => x.Slug == slug);

            article.KeywordList = article.Keyword.Split(",").ToList();

            var comments = _commentContext.Comments
                .Where(x => x.OwnerRecordId == article.Id)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.IsConfirmed)
                .Select(x => new Contract.Products.CommentProduct

                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Massege = x.Massege,
                    OwnerRecordId = x.OwnerRecordId,
                    ParentId = x.ParentId,
                    CreationDate = x.CreationDate.ToFarsi(),

                }).OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                    comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;


            }
            article.Comments = comments;
            return article;
        }

        public List<LatestArticleQueryModel> GetLatestArticels()
        {
            return _blogContext.Articles.Where(x => x.PublishDate < DateTime.Now).Select(x => new LatestArticleQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 100)) + "...",
                Slug = x.Slug,
                Title = x.Title,
                PublishDate = x.PublishDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
