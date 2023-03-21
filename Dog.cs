using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkedTheDog
{
    public class Dog:ModelApp
    {

       
        private int dogId;
        private string dogName;
        private string dogDescription;
        private EnumSize dogSize;
        private EnumActivityDemand dogActivityDemand;
        private EnumDogGender dogGender;
        private string dogBreed;
        private DateTime dogDateOfBirth;
        public static Dog SavedDog;
        [Key]
        public int DogId { get => dogId; set => dogId = value; }
        public string DogName { get => dogName; set => dogName = value; }
        public string DogDescription { get => dogDescription; set => dogDescription = value; }
        public EnumSize DogSize { get => dogSize; set => dogSize = value; }
        public EnumActivityDemand DogActivityDemand { get => dogActivityDemand; set => dogActivityDemand = value; }
        public EnumDogGender DogGender { get => dogGender; set => dogGender = value; }
        public string DogBreed { get => dogBreed; set => dogBreed = value; }
        public DateTime DogDateOfBirth { get => dogDateOfBirth; set => dogDateOfBirth = value; }


        
        public virtual User DogOwner { get; set; }
        
        public int UserId { get; set; }

        public virtual List<OwnerAdvert> Advert { get; set; }
        public Dog()
        {
            DogId = 0;
            DogId++;
        }

        public Dog(string dogName, string dogDescription, EnumSize dogSize, EnumActivityDemand dogActivityDemand, EnumDogGender dogGender, string dogBreed, string dogDateOfBirth) : this()
        {
            DogName = dogName;
            DogDescription = dogDescription;
            DogSize = dogSize;
            DogActivityDemand = dogActivityDemand;
            DogGender = dogGender;
            DogBreed = dogBreed;
            DateTime.TryParseExact(dogDateOfBirth, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date);
            DogDateOfBirth = date;
            
            DogOwner = Users.Where(x => x.UserId == User.SavedUser.UserId).FirstOrDefault();

        }

        public int dogAge()
        {
            return   DateTime.Now.Year - DogDateOfBirth.Year;
        }

        public void SaveDogToBase()
        {

            DogModels.Add(this);
            SaveChanges();
        }

        public ObservableCollection<Dog> MyDogs()
        {
            ObservableCollection<Dog> dogs= new ObservableCollection<Dog>();
            
            foreach (Dog dog in DogModels.Where(x => x.UserId == User.SavedUser.UserId))
            {

                dogs.Add(dog);

            }

            return dogs;
        }

        public int NumberOfDogs()
        {
            return DogModels.Where(x => x.UserId == User.SavedUser.UserId).Count();
        }

        public override string ToString()
        {
            return $"{DogName}";
        }
    }
    public enum EnumSize { big, small, medium }
    public enum EnumActivityDemand { big, small, medium }
    public enum EnumDogGender { female, male, castrated }
}
