




using _01_Framework.Domain;

namespace CommentManagment.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        private Comment()
        {
            
        }
        public string Name { get; private set; }
        public string Massege { get; private set; }
        public string Email { get; private set; }
        public string Website { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public long? ParentId { get; private set; }
        public Comment Parent { get; private set; }


        public Comment(string massege, string email, string name, long ownerRecordId, int type, string website, long parentId)
        {

            Massege = massege;
            Email = email;
            Name = name;
            OwnerRecordId = ownerRecordId;
            Type = type;
            Website = website;
            ParentId = parentId;
        }

        public void Cancel()
        {
            IsCanceled = true;

        }
        public void Confirm()
        {
            IsConfirmed = true;

        }
    }
}
