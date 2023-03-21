using System;
using System.Data.Entity;
using System.Linq;

namespace WalkedTheDog
{
    public class ModelApp : DbContext
    {
        // Your context has been configured to use a 'ModelApp' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WalkedTheDog.ModelApp' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelApp' 
        // connection string in the application configuration file.
        public ModelApp()
            : base("ModelApp")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dog> DogModels { get; set; }
        public virtual DbSet<OwnerAdvert> OwnerAdvertModels { get; set; }
        public virtual DbSet<WalkerAdvert> WalkersAdvertModels { get; set;}
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}