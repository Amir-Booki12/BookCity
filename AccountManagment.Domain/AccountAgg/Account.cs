

using _01_Framework.Domain;
using AccountManagment.Domain.RoleAgg;


namespace AccountManagment.Domain.AccountAgg
{

    public class Account : EntityBase

    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }
        public string ProfilePhoto { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        public Account(string fullName, string userName, string mobile, string password, long roleId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Mobile = mobile;
            Password = password;
            RoleId = roleId;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullName, string userName, string mobile, long roleId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Mobile = mobile;
            RoleId = roleId;

            if(!string.IsNullOrWhiteSpace(profilePhoto)) 
            ProfilePhoto = profilePhoto;
        }

        public void ChengePassword(string password)
        {
            Password = password;
        }
    }
}
