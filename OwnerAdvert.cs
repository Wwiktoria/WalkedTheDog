using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkedTheDog
{
    public class OwnerAdvert : ModelApp
    {
        private int ownerAdvertId;


        private string ownerAdvertCity;
        private string ownerAdvertTitle;
        private string ownerAdvertDescription;
        private int ownerAdvertAmount;
        private DateTime ownerAdvertDateAdded;
        private DateTime ownerAdvertDateOfSerice;
        private int ownerAdvertWalkingTime;
        public static OwnerAdvert SavedOwnerAdvert;
        public static bool filterGenderMale;
        public static bool filterGenderFemale;
        public static bool filterGenderCastrated;
        public static bool filterActivitySmall;
        public static bool filterActivityMedium;
        public static bool filterActivityBig;
        public static bool filterSizeSmall;
        public static bool filterSizeMedium;
        public static bool filterSizeBig;
        public static string filterCity;
        public static int filterHourlyWageFrom;
        public static int filterHourlyWageTo;
        public static int filterWalkingTimeFrom;
        public static int filterWalkingTimeTo;


        [Key]

        public int OwnerAdvertId { get => ownerAdvertId; set => ownerAdvertId = value; }

        public string OwnerAdvertCity { get => ownerAdvertCity; set => ownerAdvertCity = value; }
        public string OwnerAdvertTitle { get => ownerAdvertTitle; set => ownerAdvertTitle = value; }
        public string OwnerAdvertDescription { get => ownerAdvertDescription; set => ownerAdvertDescription = value; }
        public int OwnerAdvertAmount { get => ownerAdvertAmount; set => ownerAdvertAmount = value; }
        public DateTime OwnerAdvertDateAdded { get => ownerAdvertDateAdded; set => ownerAdvertDateAdded = value; }
        public DateTime OwnerAdvertDateOfSerice { get => ownerAdvertDateOfSerice; set => ownerAdvertDateOfSerice = value; }
        public int OwnerAdvertWalkingTime { get => ownerAdvertWalkingTime; set => ownerAdvertWalkingTime = value; }

        public virtual Dog Dog { get; set; }

        public int DogId { get; set; }




        public OwnerAdvert()
        {
            OwnerAdvertId = 0;
            OwnerAdvertId++;
        }

        public OwnerAdvert(string ownerAdvertCity, string ownerAdvertTitle, string ownerAdvertDescription, int ownerAdvertAmount, DateTime ownerAdvertDateAdded, DateTime ownerAdvertDateOfSerice, int ownerAdvertWalkingTime) : this()
        {


            OwnerAdvertCity = ownerAdvertCity;
            OwnerAdvertTitle = ownerAdvertTitle;
            OwnerAdvertDescription = ownerAdvertDescription;
            OwnerAdvertAmount = ownerAdvertAmount;
            OwnerAdvertDateAdded = ownerAdvertDateAdded;
            OwnerAdvertDateOfSerice = ownerAdvertDateOfSerice;
            OwnerAdvertWalkingTime = ownerAdvertWalkingTime;

            Dog = DogModels.Where(x => x.DogId == Dog.SavedDog.DogId).FirstOrDefault();
        }
        public void SaveOwnerAdvertToBase()
        {

            OwnerAdvertModels.Add(this);
            SaveChanges();
        }

        public ObservableCollection<OwnerAdvert> Offerts()
        {
            ObservableCollection<OwnerAdvert> offerts = new ObservableCollection<OwnerAdvert>();

            foreach (OwnerAdvert advert in OwnerAdvertModels)
            {

                offerts.Add(advert);

            }

            return offerts;
        }

        public ObservableCollection<OwnerAdvert> Filter()
        {
            List<OwnerAdvert> offerts = new List<OwnerAdvert>();
            
            foreach (OwnerAdvert dog in OwnerAdvertModels)
            {
                offerts.Add(dog);
            }
            //Activity Demand

            if (filterActivityBig == false && filterActivityMedium == false && filterActivitySmall == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogActivityDemand == EnumActivityDemand.small);
            }

            if (filterActivityBig == true && filterActivityMedium == false && filterActivitySmall == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogActivityDemand == EnumActivityDemand.big);
            }

            if (filterActivityBig == false && filterActivityMedium == true && filterActivitySmall == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogActivityDemand == EnumActivityDemand.medium);
            }

            if (filterActivityBig == false && filterActivityMedium == true && filterActivitySmall == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogActivityDemand == EnumActivityDemand.small && x.Dog.DogActivityDemand == EnumActivityDemand.medium);
            }

            if (filterActivityBig == true && filterActivityMedium == false && filterActivitySmall == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogActivityDemand == EnumActivityDemand.small && x.Dog.DogActivityDemand == EnumActivityDemand.big);
            }

            if (filterActivityBig == true && filterActivityMedium == true && filterActivitySmall == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogActivityDemand == EnumActivityDemand.big && x.Dog.DogActivityDemand == EnumActivityDemand.medium);
            }

            //Dog Size

            if (filterSizeBig == true && filterSizeMedium == false && filterSizeSmall == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogSize == EnumSize.big);
            }

            if (filterSizeBig == false && filterSizeMedium == true && filterSizeSmall == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogSize == EnumSize.medium);
            }

            if (filterSizeBig == false && filterSizeMedium == false && filterSizeSmall == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogSize == EnumSize.small);
            }

            if (filterSizeBig == true && filterSizeMedium == true && filterSizeSmall == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogSize == EnumSize.big && x.Dog.DogSize == EnumSize.medium);
            }

            if (filterSizeBig == false && filterSizeMedium == true && filterSizeSmall == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogSize == EnumSize.medium && x.Dog.DogSize == EnumSize.small);
            }

            if (filterSizeBig == true && filterSizeMedium == false && filterSizeSmall == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogSize == EnumSize.big && x.Dog.DogSize == EnumSize.small);
            }

            //Dog Gender

            if (filterGenderCastrated == true && filterGenderMale == false && filterGenderFemale == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogGender == EnumDogGender.castrated);
            }

            if (filterGenderCastrated == false && filterGenderMale == true && filterGenderFemale == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogGender == EnumDogGender.male);
            }

            if (filterGenderCastrated == false && filterGenderMale == false && filterGenderFemale == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogGender == EnumDogGender.female);
            }

            if (filterGenderCastrated == true && filterGenderMale == true && filterGenderFemale == false)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogGender == EnumDogGender.castrated && x.Dog.DogGender == EnumDogGender.male);
            }

            if (filterGenderCastrated == false && filterGenderMale == true && filterGenderFemale == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogGender == EnumDogGender.male && x.Dog.DogGender == EnumDogGender.female);
            }

            if (filterGenderCastrated == true && filterGenderMale == false && filterGenderFemale == true)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.Dog.DogGender == EnumDogGender.castrated && x.Dog.DogGender == EnumDogGender.female);
            }

            //City

            if (filterCity != null)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.ownerAdvertCity == filterCity);
            }

            //Walking Time

            if (filterWalkingTimeFrom != 0 && filterWalkingTimeTo != 0)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.OwnerAdvertWalkingTime >= filterWalkingTimeFrom && x.OwnerAdvertWalkingTime <= filterWalkingTimeTo);

            }

            //Hourly Wage

            if (filterHourlyWageFrom != 0 && filterHourlyWageTo != 0)
            {
                offerts = (List<OwnerAdvert>)offerts.FindAll(x => x.OwnerAdvertAmount >= filterHourlyWageFrom && x.OwnerAdvertWalkingTime <= filterHourlyWageTo);

            }

            ObservableCollection<OwnerAdvert> offertsOC = new ObservableCollection<OwnerAdvert>();

            foreach (OwnerAdvert advert in offerts)
            {

                offertsOC.Add(advert);

            }

           return offertsOC;
        }

        

        public int NumberOfOfferts()
        {
            return OwnerAdvertModels.Count();
        }
        public override string ToString()
        {
            return $"{OwnerAdvertTitle}";
        }
    }
}
