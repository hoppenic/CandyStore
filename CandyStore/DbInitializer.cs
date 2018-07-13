using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CandyStore
{
    internal static class DbInitializer
    {

        //internal method called initialize, takes an instance of class CandyStoreDbContext
        internal static void Initialize(CandyStoreDbContext db)
        {

            db.Database.Migrate();

            if (db.Products.Count() == 0)
            {
                db.Products.Add(new Product
                {
                    Name="Almond Chocolate Bar",
                    Image="/images/dark-brown-milk-candy.jpg",
                    Description="Delicious Chocolate and Almonds",
                    Price=2.99m

                });
                db.Products.Add(new Product
                {
                    Name = "Chocolate Peanut Butter Marshmallow Cookies",
                    Image= "/images/chocolate cookies.jpg",
                    Description = "Best Damn Cookies in America!  USA!",
                    Price = 5.99m

                });

                db.SaveChanges();
            }



        }




    }
}
