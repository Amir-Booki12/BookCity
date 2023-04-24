namespace ShopManagment.Application.Contract.slide
{
    public class SlideViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Header { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }
        public string CreationDate { get; set; }
        public bool  IsRemove { get; set; }
    }
}
