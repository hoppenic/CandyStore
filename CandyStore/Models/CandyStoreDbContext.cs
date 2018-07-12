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
    

    }

    //public class, inheriting from IdentityUser
    public class CandyStoreUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
