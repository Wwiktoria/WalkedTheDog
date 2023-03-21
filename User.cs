using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkedTheDog
{
    public class User:ModelApp
    {
        private int userId;
        private string userName;
        private string userSurname;
        private EnumGender userGender;
        private string userEmail;
        private string userPassword;
        private DateTime userDateOfBirth;
        private string userPhone;
        public static User SavedUser;


        [Key]
        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserSurname { get => userSurname; set => userSurname = value; }
        public EnumGender UserGender { get => userGender; set => userGender = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public DateTime UserDateOfBirth { get => userDateOfBirth; set => userDateOfBirth = value; }
        public string UserPhone { get => userPhone; set => userPhone = value; }
        //public virtual ICollection<FavouriteOwnerAdvert> FavouriteOwnerAdverts { get; set; }
        //public virtual List<WalkerAdvert> advert { get; set; }
        public virtual List<Dog> Dogs { get; set; }
        
        public virtual List<WalkerAdvert> WalkerAdverts { get; set; }

        public User()
        {
            UserId = 0;
            UserId++;
        }

        public User(string password, string email) : this()
        {
            UserPassword = password;
            UserEmail = email;
        }

        public User(string userName, string userSurname, EnumGender userGender, string userEmail, string userPassword, string userDateOfBirth, string userPhone) : this()
        {
            UserName = userName;
            UserSurname = userSurname;
            UserGender = userGender;
            UserEmail = userEmail;
            UserPassword = userPassword;
            DateTime.TryParseExact(userDateOfBirth, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date);
            UserDateOfBirth = date;
            UserPhone = userPhone;



        }
        public bool CheckIfExist()
        {
            return Users.Any(x => x.UserEmail == this.UserEmail);

        }

        public User CheckIfExistLogin(string email, string password)
        {
           SavedUser = Users.FirstOrDefault(x => (x.UserEmail == email && x.UserPassword == password));
           return SavedUser;
        }

        public void SaveUserToBase()
        {


            Users.Add(this);
            SaveChanges();
        }

        public string CapitalizeFirstLetter(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            if (s.Length == 1)
                return s.ToUpper();
            return s.Remove(1).ToUpper() + s.Substring(1);
        }

        public int userAge()
        {
            return DateTime.Now.Year - UserDateOfBirth.Year;
        }

        public override string ToString()
        {
            return $"{CapitalizeFirstLetter(UserName)} {CapitalizeFirstLetter(UserSurname)}";
        }


    }
    public enum EnumGender { woman, man, other }
}

