using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace phoneBook.Model
{
    public class context: IdentityDbContext<ApplicationUser>//DbContext
    {
      
        
            public context() : base()
            {

            }
            public context(DbContextOptions options) : base(options)
            {

            }
            public DbSet<BookPhone> bookPhones { get; set; }
             public DbSet<Phones> Phones { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=AngularProject;Integrated Security=True");
        //}
    }

    }

