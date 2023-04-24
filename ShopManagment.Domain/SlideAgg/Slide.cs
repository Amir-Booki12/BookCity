using _01_Framework.Domain;


namespace ShopManagment.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Text { get; private set; }
        public string Header { get; private set; }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string BtnText { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemove { get; private set; }

        public Slide(string text, string header, string btnText, string picture, string pictureAlt,
            string pictureTitle, string title, string link)
        {
            Text = text;
            Header = header;
            BtnText = btnText;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;
            Title = title;
            Link = link;
        }
        public void Edit(string title, string link, string text, string header, string btnText, string picture, string pictureAlt,
          string pictureTitle)
        {
            Title = title;
            Link = link;
            Text = text;
            Header = header;
            BtnText = btnText;

            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;
        }

        public void Remove()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove = false;
        }
    }
}
