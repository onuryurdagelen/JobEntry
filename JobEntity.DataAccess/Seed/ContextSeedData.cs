using JobEntity.DataAccess.Context;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntity.DataAccess.Seed
{
	public class ContextSeedData
	{
		private readonly AppDbContext _context;

		public ContextSeedData(AppDbContext context)
		{
			_context = context;
		}
		public async Task InitializeContextAsync()
		{
			if (_context.Database.GetPendingMigrationsAsync().Result.Count() > 0) await _context.Database.MigrateAsync();

			
            #region Users
            if (!await _context.Users.AnyAsync()) 
			{
				var superAdmin = new AppUser
				{
					Id = Guid.Parse("401C0985-AAFE-48BE-9B6C-C3A0DB2E411A"),
					Email = "superadmin@gmail.com",
					UserName = "superadmin@gmail.com",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true,
					PhoneNumber = "+90 546 954 82 72",
					FirstName = "Onur",
					LastName = "Yurdagelen",
					AccessFailedCount = 0,
					TwoFactorEnabled = true,
					LockoutEnabled = true,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					SecurityStamp = Guid.NewGuid().ToString(),
					NormalizedEmail = "SUPERADMIN@GMAIL.COM"

				};
				superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "12345onur");

				var admin = new AppUser
				{
					Id = Guid.Parse("B3A349AB-2C07-41EE-9860-F6E34064317C"),
					Email = "admin@gmail.com",
					UserName = "admin@gmail.com",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true,
					PhoneNumber = "+90 543 264 37 03",
					FirstName = "Bekir",
					LastName = "Yurdagelen",
					AccessFailedCount = 0,
					TwoFactorEnabled = true,
					LockoutEnabled = true,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					SecurityStamp = Guid.NewGuid().ToString(),
					NormalizedEmail = "ADMIN@GMAIL.COM"

				};
				admin.PasswordHash = CreatePasswordHash(admin, "12345bekir");

				

				var customer = new Customer
				{
					Id = Guid.Parse("D2BD1B8F-7C4A-48F3-A35C-659A7C05F617"),
					Email = "customer@gmail.com",
					UserName = "customer@gmail.com",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true,
					PhoneNumber = "+90 542 539 64 02",
					FirstName = "Adem",
					LastName = "Yurdagelen",
					AccessFailedCount = 0,
					TwoFactorEnabled = true,
					LockoutEnabled = true,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					SecurityStamp = Guid.NewGuid().ToString(),
					NormalizedEmail = "CUSTOMER@GMAIL.COM"

				};
                customer.PasswordHash = CreatePasswordHash(customer, "12345adem");

				await _context.Users.AddRangeAsync(new AppUser[]
				{
				superAdmin,
				admin,
                customer,
				});

			}


			#endregion
			#region Roles
			if(!await _context.Roles.AnyAsync())
			{
				await _context.Roles.AddRangeAsync(new AppRole[]
				{
					new AppRole
				{
					Id = Guid.Parse("F9F752BB-9557-4182-B99F-532275416820"),
					Name = "Superadmin",
					NormalizedName = "SUPERADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				new AppRole
				{
					Id = Guid.Parse("215DB9FD-6D39-4210-83DD-3C1333381267"),
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				
				new AppRole
				{
					Id = Guid.Parse("4EBE9430-68F6-41DD-9446-BD67004F683A"),
					Name = "Customer",
					NormalizedName = "CUSTOMER",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				}
				});
			}


            #endregion
            #region UserRoles
            if (!await _context.UserRoles.AnyAsync())
            {
                await _context.UserRoles.AddRangeAsync(new AppUserRole[]
                {
						//Super admin
				new AppUserRole
                {
                    RoleId = Guid.Parse("F9F752BB-9557-4182-B99F-532275416820"),
                    UserId = Guid.Parse("401C0985-AAFE-48BE-9B6C-C3A0DB2E411A")
                },
				//Admin
				new AppUserRole
                {
                    RoleId = Guid.Parse("215DB9FD-6D39-4210-83DD-3C1333381267"),
                    UserId = Guid.Parse("B3A349AB-2C07-41EE-9860-F6E34064317C")
                },
				
				//Customer
				new AppUserRole
                {
                    RoleId = Guid.Parse("4EBE9430-68F6-41DD-9446-BD67004F683A"),
                    UserId =Guid.Parse("D2BD1B8F-7C4A-48F3-A35C-659A7C05F617")

                },
                });

            }


            #endregion
			#region Images
			if(!await _context.Images.AnyAsync())
			{
				await _context.Images.AddRangeAsync(new Image[]
				{
					new Image
				{
					Id = Guid.NewGuid(),
					FileName = "https://localhost:7088/img/com-logo-5.jpg",
					//CompanyId = Guid.Parse("5461BBC7-6540-4FFD-BD1B-428ADD2CD4AB"),
					FileType = "jpg",
				},
				new Image
				{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("413B3F4B-ADBC-40CB-8ECD-3D4D07FFE83C"),
					FileType = "jpg",
                    FileName = "https://localhost:7088/img/com-logo-4.jpg",
                },
				new Image
				{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("72A35046-26F2-4E86-A623-8EE152F93CE3"),
					FileType = "jpg",
                     FileName = "https://localhost:7088/img/com-logo-3.jpg",
                },
				new Image
						{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("B880972D-AAE5-457F-B2DB-5AB19476000F"),
					FileType = "jpg",
                    FileName = "https://localhost:7088/img/com-logo-2.jpg",
                        },
				new Image
						{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("88707DC4-7C1D-4839-90C4-B317CCCC4A70"),
					FileName = "https://localhost:7088/img/com-logo-1.jpg",
                    FileType = "jpg",
						},
				});
			}
			#endregion
            #region Categories
            if (!await _context.Categories.AnyAsync())
            {
                var parentCategory = new Category { Name = "Electronics",CreatedBy = "superadmin@gmail.com",CreatedDate = DateTime.Now };
                await _context.Categories.AddAsync(parentCategory);
                await _context.Categories.AddRangeAsync(new Category[]
                {
                    new Category
                    {
                        Name = "Mobile Phones",
                        CreatedBy = "superadmin@gmail.com",
                        CreatedDate = DateTime.Now,
                        ParentCategory = parentCategory,
                    },
                    new Category
                    {
                        Name = "Laptops",
                        CreatedBy = "superadmin@gmail.com",
                        CreatedDate = DateTime.Now,
                        ParentCategory = parentCategory
                    },
                    new Category
                    {
                        Name = "Desktops",
                        CreatedBy = "superadmin@gmail.com",
                        CreatedDate = DateTime.Now,
                        ParentCategory = parentCategory
                    }
                });
            }

            #endregion


            await _context.SaveChangesAsync();
		}

		private static string CreatePasswordHash(AppUser user, string password)
		{
			var passwordHasher = new PasswordHasher<AppUser>();

			return passwordHasher.HashPassword(user, password);
		}

	}
}
