using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkedTheDog
{
    public class WalkerAdvert : ModelApp
    {
        private int walkerAdvertId;
        private string walkerAdvertTitle;
        private string walkerAdvertCity;
        private int walkerAdvertAmount;
        private string walkerAdvertDescription;
        private DateTime walkerAdvertDateAdded;
        public static WalkerAdvert SavedWalkerAdvert;
        public static string filterCity;
        public static int filterHourlyWageTo;
        public static int filterHourlyWageFrom;



        public string WalkerAdvertTitle { get => walkerAdvertTitle; set => walkerAdvertTitle = value; }
        public string WalkerAdvertCity { get => walkerAdvertCity; set => walkerAdvertCity = value; }
        public int WalkerAdvertAmount { get => walkerAdvertAmount; set => walkerAdvertAmount = value; }
        public string WalkerAdvertDescription { get => walkerAdvertDescription; set => walkerAdvertDescription = value; }
        public DateTime WalkerAdvertDateAdded { get => walkerAdvertDateAdded; set => walkerAdvertDateAdded = value; }

        [Key]
        public int WalkerAdvertId { get => walkerAdvertId; set => walkerAdvertId = value; }

        public virtual User Walker { get; set; }

        public int UserId { get; set; }

        public WalkerAdvert()
        {
            WalkerAdvertId = 0;
            WalkerAdvertId++;
        }

        public WalkerAdvert(string walkerAdvertTitle, string walkerAdvertCity, int walkerAdvertAmount, string walkerAdvertDescription, DateTime walkerAdvertDateAdded) : this()
        {
            WalkerAdvertTitle = walkerAdvertTitle;
            WalkerAdvertCity = walkerAdvertCity;
            WalkerAdvertAmount = walkerAdvertAmount;
            WalkerAdvertDescription = walkerAdvertDescription;
            WalkerAdvertDateAdded = walkerAdvertDateAdded;

            Walker = Users.Where(x => x.UserId == User.SavedUser.UserId).FirstOrDefault();

        }

        public override string ToString()
        {
            return $"{WalkerAdvertTitle}";
        }

        public void SaveWalkerAdToBase()
        {
            WalkersAdvertModels.Add(this);
            SaveChanges();
        }

        public ObservableCollection<WalkerAdvert> Walkers()
        {
            ObservableCollection<WalkerAdvert> walkers = new ObservableCollection<WalkerAdvert>();

            foreach (WalkerAdvert walker in WalkersAdvertModels)
            {

                walkers.Add(walker);

            }

            return walkers;
        }

        public ObservableCollection<WalkerAdvert> Filter()
        {
            List<WalkerAdvert> offerts = new List<WalkerAdvert>();

            foreach (WalkerAdvert walker in WalkersAdvertModels)
            {
                offerts.Add(walker);
            }

            if (filterCity != null)
            {
                offerts = (List<WalkerAdvert>)offerts.FindAll(x => x.walkerAdvertCity == filterCity);
            }

            if (filterHourlyWageFrom != 0 && filterHourlyWageTo != 0)
            {
                offerts = (List<WalkerAdvert>)offerts.FindAll(x => x.walkerAdvertAmount >= filterHourlyWageFrom && x.walkerAdvertAmount <= filterHourlyWageTo);

            }

            ObservableCollection<WalkerAdvert> offertsOC = new ObservableCollection<WalkerAdvert>();

            foreach (WalkerAdvert advert in offerts)
            {

                offertsOC.Add(advert);

            }

            return offertsOC;
        }

        public int NumberOfWalkerAds()
        {
            return WalkersAdvertModels.Count();
        }


    }
}


