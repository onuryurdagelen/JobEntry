using JobEntity.DataAccess.Mappings;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Context
{
	public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
	{


        //Add-Migration InitialCreate -Project SqlServer
        #region EShopper Tables
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }



        #endregion



        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
			//modelBuilder.ApplyConfiguration(new CompanyMap());
			//modelBuilder.ApplyConfiguration(new ImageMap());
			//modelBuilder.ApplyConfiguration(new JobMap());

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           

        }


    }
}
