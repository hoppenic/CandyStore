using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Models
{
    //class, inheriting from IdentityDbContext
    public class CandyStoreDbContext : IdentityDbContext<CandyStoreUser>
    {

        //constructor
        public CandyStoreDbContext(): base()
        {

        }


        public CandyStoreDbContext(DbContextOptions options): base(options)
        {


        }

        
        public DbSet<Product> Products { get; set; }

        //Dbset called Carts that inherits from the Cart class
        public DbSet<Cart> Carts { get; set; }
        //Dbset called CartItems that inherts from CartItem class
        public DbSet<CartItem> CartItems { get; set; }


    }

    public class Cart
    {
        //constructor
        public Cart()
        {
            this.CartItems = new HashSet<CartItem>();
        }

        public int ID { get; set; }
        public Guid CookieIdentifier { get; set; }
        public DateTime LastModified { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }

    public class CartItem
    {
        public int ID { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }

    //public class, inheriting from IdentityUser
    public class CandyStoreUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
