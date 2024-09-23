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

				var applicant = new Applicant
				{
					Id = Guid.Parse("0D5154D2-D1D7-4674-80E9-CDA7C6116037"),
					Email = "applicant@gmail.com",
					UserName = "applicant@gmail.com",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true,
					PhoneNumber = "+90 542 539 64 02",
					FirstName = "Eslem",
					LastName = "Yurdagelen",
					AccessFailedCount = 0,
					TwoFactorEnabled = true,
					LockoutEnabled = true,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					SecurityStamp = Guid.NewGuid().ToString(),
					NormalizedEmail = "APPLICANT@GMAIL.COM"

				};
				applicant.PasswordHash = CreatePasswordHash(applicant, "12345eslem");

				var employer = new Employer
				{
					Id = Guid.Parse("D2BD1B8F-7C4A-48F3-A35C-659A7C05F617"),
					Email = "employer@gmail.com",
					UserName = "employer@gmail.com",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true,
					PhoneNumber = "+90 542 539 64 02",
					FirstName = "Adem",
					LastName = "Yurdagelen",
					AccessFailedCount = 0,
					TwoFactorEnabled = true,
					CompanyId = Guid.Parse("5461BBC7-6540-4FFD-BD1B-428ADD2CD4AB"), //Company 1
					LockoutEnabled = true,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					SecurityStamp = Guid.NewGuid().ToString(),
					NormalizedEmail = "EMPLOYER@GMAIL.COM"

				};
				employer.PasswordHash = CreatePasswordHash(employer, "12345adem");

				await _context.Users.AddRangeAsync(new AppUser[]
				{
				superAdmin,
				admin,
				applicant,
				employer,
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
					Id = Guid.Parse("053D34DE-DFCA-4BAB-BBFF-AA60BBBFE6A5"),
					Name = "Applicant",
					NormalizedName = "APPLICANT",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				new AppRole
				{
					Id = Guid.Parse("4EBE9430-68F6-41DD-9446-BD67004F683A"),
					Name = "Employer",
					NormalizedName = "EMPLOYER",
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
				//Applicant
				new AppUserRole
				{
					RoleId = Guid.Parse("053D34DE-DFCA-4BAB-BBFF-AA60BBBFE6A5"),
					UserId = Guid.Parse("CBDBD54C-13D4-4A75-A60B-25D514D4C0BC")
				},
				//Employer
				new AppUserRole
				{
					RoleId = Guid.Parse("4EBE9430-68F6-41DD-9446-BD67004F683A"),
					UserId =Guid.Parse("D2BD1B8F-7C4A-48F3-A35C-659A7C05F617")

				},
				});

			}


			#endregion

			#region Companies
			if (!await _context.Companies.AnyAsync()) 
			{
				await _context.Companies.AddRangeAsync(new Company[]
				{
					new Company
					{
						Id = Guid.Parse("5461BBC7-6540-4FFD-BD1B-428ADD2CD4AB"),
						Description = "Ipsum dolor ipsum accusam stet et et diam dolores, sed rebum sadipscing elitr vero dolores. Lorem dolore elitr justo et no gubergren sadipscing, " +
						"ipsum et takimata aliquyam et rebum est ipsum lorem diam. Et lorem magna eirmod est et et sanctus et, kasd clita labore.",
						Name = "Company 1",
					},
				new Company
					{
						Id = Guid.Parse("413B3F4B-ADBC-40CB-8ECD-3D4D07FFE83C"),
						Description = "Ipsum dolor ipsum accusam stet et et diam dolores, sed rebum sadipscing elitr vero dolores. Lorem dolore elitr justo et no gubergren sadipscing, " +
						"ipsum et takimata aliquyam et rebum est ipsum lorem diam. Et lorem magna eirmod est et et sanctus et, kasd clita labore.",
						Name = "Company 2",

					},
				 new Company
					{
						Id = Guid.Parse("72A35046-26F2-4E86-A623-8EE152F93CE3"),
						Description = "Ipsum dolor ipsum accusam stet et et diam dolores, sed rebum sadipscing elitr vero dolores. Lorem dolore elitr justo et no gubergren sadipscing, " +
						"ipsum et takimata aliquyam et rebum est ipsum lorem diam. Et lorem magna eirmod est et et sanctus et, kasd clita labore.",
						Name = "Company 3",
					},
				 new Company
					{
						Id = Guid.Parse("B880972D-AAE5-457F-B2DB-5AB19476000F"),
						Description = "Ipsum dolor ipsum accusam stet et et diam dolores, sed rebum sadipscing elitr vero dolores. Lorem dolore elitr justo et no gubergren sadipscing, " +
						"ipsum et takimata aliquyam et rebum est ipsum lorem diam. Et lorem magna eirmod est et et sanctus et, kasd clita labore.",
						Name = "Company 4",
					},
				 new Company
					{
						Id = Guid.Parse("88707DC4-7C1D-4839-90C4-B317CCCC4A70"),
						Description = "Ipsum dolor ipsum accusam stet et et diam dolores, sed rebum sadipscing elitr vero dolores. Lorem dolore elitr justo et no gubergren sadipscing, " +
						"ipsum et takimata aliquyam et rebum est ipsum lorem diam. Et lorem magna eirmod est et et sanctus et, kasd clita labore.",
						Name = "Company 5",
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
					FileName = "https://localhost:7088/com-logo-5.jpg",
					//CompanyId = Guid.Parse("5461BBC7-6540-4FFD-BD1B-428ADD2CD4AB"),
					FileType = "jpg",
				},
				new Image
				{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("413B3F4B-ADBC-40CB-8ECD-3D4D07FFE83C"),
					FileType = "jpg",
                    FileName = "https://localhost:7088/com-logo-4.jpg",
                },
				new Image
				{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("72A35046-26F2-4E86-A623-8EE152F93CE3"),
					FileType = "jpg",
                     FileName = "https://localhost:7088/com-logo-3.jpg",
                },
				new Image
						{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("B880972D-AAE5-457F-B2DB-5AB19476000F"),
					FileType = "jpg",
                    FileName = "https://localhost:7088/com-logo-2.jpg",
                        },
				new Image
						{
					Id = Guid.NewGuid(),
					//CompanyId = Guid.Parse("88707DC4-7C1D-4839-90C4-B317CCCC4A70"),
					FileName = "https://localhost:7088/com-logo-1.jpg",
                    FileType = "jpg",
						},
				});
			}
			#endregion
			#region Jobs
			if(!await _context.Jobs.AnyAsync())
			{
				await _context.Jobs.AddRangeAsync(new Job[]
				{
					new Job
				{
					Id = Guid.Parse("9C2069FC-0535-4D04-B1BA-08ECEC4F125F"),
					Name = "Software Engineer",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
					Location = "New York,USA",
					Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("5461BBC7-6540-4FFD-BD1B-428ADD2CD4AB"),


				},
				new Job
				{
					Id = Guid.Parse("D0639FB3-5E1E-49E1-AADA-D9FC525A34EA"),
					Name = "Marketing Manager",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
					Location = "New York,USA",
					Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("413B3F4B-ADBC-40CB-8ECD-3D4D07FFE83C"),

				},
				new Job
				{
					Id = Guid.Parse("A96C75FA-999B-4D83-928B-1342DBEEA32A"),
					Name = "Product Designer",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
					Location = "New York,USA",
					Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("72A35046-26F2-4E86-A623-8EE152F93CE3"),

				},
				new Job
				{
					Id = Guid.Parse("51A798E6-CAA3-4B20-A38F-ED8489265276"),
					Name = "Creative Director",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
					Location = "New York,USA",
					Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("B880972D-AAE5-457F-B2DB-5AB19476000F"),

				},
				new Job
				{
					Id = Guid.Parse("BBC076AB-38B9-4F33-9741-C8F81DDA84EA"),
					Name = "Wordpress Developer",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
					Location = "New York,USA",
					Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("88707DC4-7C1D-4839-90C4-B317CCCC4A70"),

				},
				});
			}

			#endregion
			#region Qualifications
			if(!await _context.Qualifications.AnyAsync())
			{
				await _context.Qualifications.AddRangeAsync(new Qualification[]
			{
				new Qualification
					{
						Id = Guid.Parse("E6F7F96C-FA6C-4B39-BEC1-61BE57A08654"),
						JobId = Guid.Parse("9C2069FC-0535-4D04-B1BA-08ECEC4F125F"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. " +
						"Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
					},
				new Qualification
					{
						Id = Guid.Parse("90B464BE-2DC7-4A54-B2B2-2DD9F57E3F3A"),
						JobId = Guid.Parse("D0639FB3-5E1E-49E1-AADA-D9FC525A34EA"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. " +
						"Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",

					},
				new Qualification
					{
						Id = Guid.Parse("5DC82CBA-1F3F-41A0-9FC3-D10F023C2047"),
						JobId = Guid.Parse("A96C75FA-999B-4D83-928B-1342DBEEA32A"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. " +
						"Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
					},
				new Qualification
					{
						Id = Guid.Parse("0CD0083D-6D12-4CBA-9748-AD6E8A7DBFF1"),
						JobId = Guid.Parse("51A798E6-CAA3-4B20-A38F-ED8489265276"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. " +
						"Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
					},
				new Qualification
					{
						Id = Guid.Parse("F31FD6EF-355E-4890-A6C1-FF313C5B55EF"),
						JobId = Guid.Parse("BBC076AB-38B9-4F33-9741-C8F81DDA84EA"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. " +
						"Accusam sed lorem stet voluptua sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
					},
			});
			}
			#endregion
			#region QualificationDetails
			if(!await _context.QualificationDetails.AnyAsync())
			{
				await _context.QualificationDetails.AddRangeAsync(new QualificationDetail[]
			{
				new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("E6F7F96C-FA6C-4B39-BEC1-61BE57A08654"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("E6F7F96C-FA6C-4B39-BEC1-61BE57A08654"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("E6F7F96C-FA6C-4B39-BEC1-61BE57A08654"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("E6F7F96C-FA6C-4B39-BEC1-61BE57A08654"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("E6F7F96C-FA6C-4B39-BEC1-61BE57A08654"),
								Description = "Diam diam stet erat no est est"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("90B464BE-2DC7-4A54-B2B2-2DD9F57E3F3A"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("90B464BE-2DC7-4A54-B2B2-2DD9F57E3F3A"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("90B464BE-2DC7-4A54-B2B2-2DD9F57E3F3A"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("90B464BE-2DC7-4A54-B2B2-2DD9F57E3F3A"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("90B464BE-2DC7-4A54-B2B2-2DD9F57E3F3A"),
								Description = "Diam diam stet erat no est est"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("5DC82CBA-1F3F-41A0-9FC3-D10F023C2047"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("5DC82CBA-1F3F-41A0-9FC3-D10F023C2047"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("5DC82CBA-1F3F-41A0-9FC3-D10F023C2047"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("5DC82CBA-1F3F-41A0-9FC3-D10F023C2047"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("5DC82CBA-1F3F-41A0-9FC3-D10F023C2047"),
								Description = "Diam diam stet erat no est est"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("0CD0083D-6D12-4CBA-9748-AD6E8A7DBFF1"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("0CD0083D-6D12-4CBA-9748-AD6E8A7DBFF1"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("0CD0083D-6D12-4CBA-9748-AD6E8A7DBFF1"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("0CD0083D-6D12-4CBA-9748-AD6E8A7DBFF1"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("0CD0083D-6D12-4CBA-9748-AD6E8A7DBFF1"),
								Description = "Diam diam stet erat no est est"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("F31FD6EF-355E-4890-A6C1-FF313C5B55EF"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("F31FD6EF-355E-4890-A6C1-FF313C5B55EF"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("F31FD6EF-355E-4890-A6C1-FF313C5B55EF"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("F31FD6EF-355E-4890-A6C1-FF313C5B55EF"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new QualificationDetail
							{
								Id = Guid.NewGuid(),
								QualificationId = Guid.Parse("F31FD6EF-355E-4890-A6C1-FF313C5B55EF"),
								Description = "Diam diam stet erat no est est"
							},
			});
			}
			#endregion
			#region Responsibilities
			if(!await _context.Responsibilities.AnyAsync())
			{
				await _context.Responsibilities.AddRangeAsync(new Responsibility[]
			{
				new Responsibility
					{
						Id = Guid.Parse("E17E24FF-4F2A-4792-8885-9BC219F111B2"),
						JobId = Guid.Parse("9C2069FC-0535-4D04-B1BA-08ECEC4F125F"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua " +
						"sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor",
					},
				new Responsibility
					{
						Id = Guid.Parse("8D2F9313-357F-41B1-90CE-BC5A88F9EAC7"),
						JobId = Guid.Parse("D0639FB3-5E1E-49E1-AADA-D9FC525A34EA"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua " +
						"sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor"
					},
				new Responsibility
					{
						Id = Guid.Parse("D26C4223-D012-4EBE-8390-3CEF3613C34F"),
						JobId = Guid.Parse("A96C75FA-999B-4D83-928B-1342DBEEA32A"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua " +
						"sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor"
					},
				new Responsibility
					{
						Id = Guid.Parse("0EF84CE3-1294-4E60-81DB-7BD05DC8F226"),
						JobId = Guid.Parse("51A798E6-CAA3-4B20-A38F-ED8489265276"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua " +
						"sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor"
					},
				new Responsibility
					{
						Id = Guid.Parse("95742D20-0044-474A-B39D-6FAC3381ED4B"),
						JobId = Guid.Parse("BBC076AB-38B9-4F33-9741-C8F81DDA84EA"),
						Description = "Magna et elitr diam sed lorem. Diam diam stet erat no est est. Accusam sed lorem stet voluptua " +
						"sit sit at stet consetetur, takimata at diam kasd gubergren elitr dolor"
					},
			});
			}
			#endregion
			#region ResponsibilityDetails
			if (!await _context.ResponsibilityDetails.AnyAsync()) 
			{
				await _context.ResponsibilityDetails.AddRangeAsync(new ResponsibilityDetail[]
				{
				new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("E17E24FF-4F2A-4792-8885-9BC219F111B2"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("E17E24FF-4F2A-4792-8885-9BC219F111B2"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("E17E24FF-4F2A-4792-8885-9BC219F111B2"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("E17E24FF-4F2A-4792-8885-9BC219F111B2"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("E17E24FF-4F2A-4792-8885-9BC219F111B2"),
								Description = "Diam diam stet erat no est est"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("8D2F9313-357F-41B1-90CE-BC5A88F9EAC7"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("8D2F9313-357F-41B1-90CE-BC5A88F9EAC7"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("8D2F9313-357F-41B1-90CE-BC5A88F9EAC7"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("8D2F9313-357F-41B1-90CE-BC5A88F9EAC7"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId =Guid.Parse("8D2F9313-357F-41B1-90CE-BC5A88F9EAC7"),
								Description = "Diam diam stet erat no est est"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId =Guid.Parse("D26C4223-D012-4EBE-8390-3CEF3613C34F"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("D26C4223-D012-4EBE-8390-3CEF3613C34F"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("D26C4223-D012-4EBE-8390-3CEF3613C34F"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("D26C4223-D012-4EBE-8390-3CEF3613C34F"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
									ResponsibilityId = Guid.Parse("D26C4223-D012-4EBE-8390-3CEF3613C34F"),
								Description = "Diam diam stet erat no est est"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("0EF84CE3-1294-4E60-81DB-7BD05DC8F226"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("0EF84CE3-1294-4E60-81DB-7BD05DC8F226"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("0EF84CE3-1294-4E60-81DB-7BD05DC8F226"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("0EF84CE3-1294-4E60-81DB-7BD05DC8F226"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId =Guid.Parse("0EF84CE3-1294-4E60-81DB-7BD05DC8F226"),
								Description = "Diam diam stet erat no est est"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("95742D20-0044-474A-B39D-6FAC3381ED4B"),
								Description = "Dolor justo tempor duo ipsum accusam"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("95742D20-0044-474A-B39D-6FAC3381ED4B"),
								Description = "Elitr stet dolor vero clita labore gubergren"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("95742D20-0044-474A-B39D-6FAC3381ED4B"),
								Description = "Rebum vero dolores dolores elitr"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("95742D20-0044-474A-B39D-6FAC3381ED4B"),
								Description = "Est voluptua et sanctus at sanctus erat"
							},
							new ResponsibilityDetail
							{
								Id = Guid.NewGuid(),
								ResponsibilityId = Guid.Parse("95742D20-0044-474A-B39D-6FAC3381ED4B"),
								Description = "Diam diam stet erat no est est"
							},
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
