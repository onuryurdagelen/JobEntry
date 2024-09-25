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

			#region WorkPreferences
			if (!await _context.WorkPreferences.AnyAsync())
			{
				await _context.WorkPreferences.AddRangeAsync(new WorkPreference[]
				{
					new WorkPreference
					{
						Id = Guid.Parse("08AD4BB9-D737-4F86-B412-786121AC9DD2"),
						Name = "Office"
					},
                    new WorkPreference
                    {
                        Id = Guid.Parse("7F6B7AB9-6377-4FEB-87E5-B66D5C749554"),
                        Name = "Remote"
                    },
                    new WorkPreference
                    {
                        Id = Guid.Parse("CB326CAA-FB3A-4F54-A795-2E87FB41C7AB"),
                        Name = "Hybrit"
                    }
                });
			}
            #endregion
            #region Sectors
            if (!await _context.Sectors.AnyAsync())
            {
                await _context.Sectors.AddRangeAsync(new Sector[]
                {
                    new Sector
                    {
                        Id = Guid.Parse("3008E0DF-C5E7-428B-B4FF-45D4C52CEF10"),
                        Name = "IT"
                    },
                    new Sector
                    {
                        Id = Guid.Parse("5C6B4FB5-376F-489F-A0CF-7994B405715F"),
                        Name = "Production / Industrial Products"
                    },
                    new Sector
                    {
                        Id = Guid.Parse("9C70CCAF-CBE3-486D-8BE2-7E9BE0231828"),
                        Name = "Electric & Electronic"
                    },
                     new Sector
                    {
                        Id = Guid.Parse("5C58D513-3431-40CB-97A8-02442BD08A5F"),
                        Name = "Security"
                    },
                     new Sector
                    {
                        Id = Guid.Parse("D3129622-106A-48D8-A73C-45AC1A8165B8"),
                        Name = "Energy"
                    },
                     new Sector
                    {
                        Id = Guid.Parse("C21C7558-54B6-4240-80D1-CF845D68CFDB"),
                        Name = "Food"
                    },
                     new Sector
                    {
                        Id = Guid.Parse("BF727AD7-AE98-4F55-B313-EA615F121D5C"),
                        Name = "Chemical"
                    }
                });
            }
            #endregion
            #region PositionLevels
            if (!await _context.PositionLevels.AnyAsync())
            {
                await _context.PositionLevels.AddRangeAsync(new PositionLevel[]
                {
                    new PositionLevel
                    {
                        Id = Guid.Parse("54056D5E-FF7B-46B3-B882-F6EBA603D085"),
                        Name = "Senior Manager"
                    },
                    new PositionLevel
                    {
                        Id = Guid.Parse("42DF44F5-AE01-4C46-95F3-5164E6CBFF33"),
                        Name = "Mid Level Manager"
                    },
                    new PositionLevel
                    {
                        Id = Guid.Parse("4A7152EE-92D6-4C89-879E-47ACA00503A8"),
                        Name = "Management Candidate"
                    },
                     new PositionLevel
                    {
                        Id = Guid.Parse("3856E32F-70E3-48B8-A615-21592EDF44AC"),
                        Name = "Expert"
                    },
                     new PositionLevel
                    {
                        Id = Guid.Parse("9FE45B59-7077-4D20-A6AE-11CC43097390"),
                        Name = "Beginner"
                    },
                     new PositionLevel
                    {
                        Id = Guid.Parse("E7805FEA-DE6A-426F-819C-0CDB59D21AC9"),
                        Name = "Freelancer"
                    },
                     new PositionLevel
                    {
                        Id = Guid.Parse("7718DF1B-E350-419B-AA41-79854915C9CD"),
                        Name = "Worker"
                    },
                      new PositionLevel
                    {
                        Id = Guid.Parse("D2C66A1B-9C39-4487-94EC-B8D71326D5CF"),
                        Name = "Intern"
                    },
                       new PositionLevel
                    {
                        Id = Guid.Parse("9B776011-997B-465C-8685-30B231A698A9"),
                        Name = "Assistant Expert"
                    }
                });
            }
            #endregion
            #region Departments
            if (!await _context.Departments.AnyAsync())
            {
                await _context.Departments.AddRangeAsync(new Department[]
                {
                    new Department
                    {
                        Id = Guid.Parse("8C94CD34-E3C7-4FD5-9481-AB68CFE77230"),
                        Name = "Academic"
                    },
                    new Department
                    {
                        Id = Guid.Parse("973597CC-31B0-4CE5-982F-5D79DC4E0E6C"),
                        Name = "R&D"
                    },
                    new Department
                    {
                        Id = Guid.Parse("AE77B719-3527-42F6-9E8A-BD49BD5E4F72"),
                        Name = "Archive / Documentation"
                    },
                     new Department
                    {
                        Id = Guid.Parse("2594CC3A-CC87-4568-BF95-0B1824ED1D23"),
                        Name = "Maintenance / Repair"
                    },
                     new Department
                    {
                        Id = Guid.Parse("A9A7F07D-BFAD-4A18-AE21-4506DAEFE6A9"),
                        Name = "Data Processsing"
                    },
                     new Department
                    {
                        Id = Guid.Parse("42D8C071-AA6A-4DE2-9D98-0CD5C912EB7C"),
                        Name = "Education"
                    },
                     new Department
                    {
                        Id = Guid.Parse("9A2DF075-54BC-4A7E-888C-DCED9AF9AF9B"),
                        Name = "Security"
                    }
                });
            }
            #endregion
            #region WorkTypes
            if (!await _context.WorkTypes.AnyAsync())
            {
                await _context.WorkTypes.AddRangeAsync(new WorkType[]
                {
                    new WorkType
                    {
                        Id = Guid.Parse("6296EF57-AEFA-4E7A-B2A8-6791C501B619"),
                        Name = "Full Time"
                    },
                    new WorkType
                    {
                        Id = Guid.Parse("7828442A-FF56-4A05-B23B-FE8A79ABF91C"),
                        Name = "Periodical / Project Based"
                    },
                    new WorkType
                    {
                        Id = Guid.Parse("663E31BB-EC8C-4B39-A136-9C214C5DCE52"),
                        Name = "Part time"
                    },
                     new WorkType
                    {
                        Id = Guid.Parse("A0FFC5AC-2926-412E-A00B-43091C5ABAD5"),
                        Name = "Free time"
                    }
                });
            }
            #endregion
            #region EducationLevels
            if (!await _context.EducationLevels.AnyAsync())
            {
                await _context.EducationLevels.AddRangeAsync(new EducationLevel[]
                {
                    new EducationLevel
                    {
                        Id = Guid.Parse("03E18F72-C6AC-47C4-96C2-8C88C3AE1CCE"),
                        Name = "Doctora - Graduated"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("58FACBD1-36D5-49C2-A0CC-4D70B25DB2BE"),
                        Name = "Doctora - Student"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("E00D0878-4FC6-4B9D-9045-730293C837F7"),
                        Name = "Postgraduate - Graduated"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("1DE8AF65-5EF0-4007-94FB-DECD12B7763C"),
                        Name = "Postgraduate - Student"
                    },
                     new EducationLevel
                    {
                        Id = Guid.Parse("1535C788-AD4D-4134-97B9-7C823F3771D4"),
                        Name = "University - Graduated"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("0AF10C14-DE0B-4501-9F0F-CEB8AE564568"),
                        Name = "University - Student"
                    },
                     new EducationLevel
                    {
                        Id = Guid.Parse("06205A0E-2956-4D3F-BD34-B5D58FFE8510"),
                        Name = "Vocational School - Graduated"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("E2898D22-C8C9-427D-B48B-682810ED6289"),
                        Name = "Vocational School  - Student"
                    },
                     new EducationLevel
                    {
                        Id = Guid.Parse("06E28E69-FE71-4A1F-B228-ED4D5A09B930"),
                        Name = "High School - Graduated"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("C578A59C-2028-469C-AC2D-A3569D03D7BC"),
                        Name = "High School  - Student"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("88570DD2-1AE6-4C1D-95CB-D989FF979DBF"),
                        Name = "Primary School - Graduated"
                    },
                    new EducationLevel
                    {
                        Id = Guid.Parse("C0B0ACE1-972A-47D7-9A9F-92BCD725294B"),
                        Name = "Primary School  - Student"
                    }
                });
            }
            #endregion
            #region Positions
            if (!await _context.Positions.AnyAsync())
            {
                await _context.Positions.AddRangeAsync(new Position[]
                {
                    new Position
                    {
                        Id = Guid.Parse("D55E2997-137F-4C9D-8F88-5A9603AAC6DB"),
                        Name = "Accounting Expert" //muhasebe uzmanı
                    },
                    new Position
                    {
                        Id = Guid.Parse("F25572E8-665B-4FD4-93EF-39C1DFD0ECFE"),
                        Name = "Sales Consultant" //satış danışmanı
                    },
                    new Position
                    {
                        Id = Guid.Parse("089F40B5-1F5B-4C87-B9AD-88F3017803EE"),
                        Name = "Customer Representative" //müşteri temsilcisi
                    },
                    new Position
                    {
                        Id = Guid.Parse("AC364126-8011-49BC-88CA-1BC3B1BF9F2C"),
                        Name = "Sales Representative" //satış temsilcisi
                    },
                     new Position
                    {
                        Id = Guid.Parse("358B953B-3D45-4E00-954F-0521BF6A4977"),
                        Name = "Software Specialist" //yazılım uzmanı
                    },
                    new Position
                    {
                        Id = Guid.Parse("FBA1293E-AD2B-4DA7-9021-ADCD50AB5546"),
                        Name = "Accounting Staff" //muhasebe elemanı
                    },
                     new Position
                    {
                        Id = Guid.Parse("E566B8A2-E04B-4933-9B60-24AA80E304C3"),
                        Name = "Software Development Specialist" //yazılım geliştirme uzmanı
                    },
                    new Position
                    {
                        Id = Guid.Parse("7F564B56-7248-416D-A6F0-72742304DE81"),
                        Name = "Store Manager" //mağaza müdürü
                    }
                });
            }
            #endregion
            #region JobLanguages
            if (!await _context.JobLanguages.AnyAsync())
            {
                await _context.JobLanguages.AddRangeAsync(new JobLanguage[]
                {
                    new JobLanguage
                    {
                        Id = Guid.Parse("D9115449-D278-4759-AC55-16189B1F27E6"),
                        Name = "English"
                    },
                    new JobLanguage
                    {
                        Id = Guid.Parse("8031220D-D84D-4B8B-8672-02D26F7647D2"),
                        Name = "Turkish"
                    }
                });
            }
            #endregion
            #region Experiences
            if (!await _context.Experiences.AnyAsync())
            {
                await _context.Experiences.AddRangeAsync(new Experience[]
                {
                    new Experience
                    {
                        Id = Guid.Parse("E559A916-C5DA-4B8C-A747-A3CE4A544E53"),
                        Name = "Inexperienced"
                    },
                    new Experience
                    {
                        Id = Guid.Parse("1BDE149C-E4EE-4203-93EF-1B4E897F4EBA"),
                        Name = "1 year"
                    },
                      new Experience
                    {
                        Id = Guid.Parse("F9FB5940-05D9-4733-9159-9FBD2FB9A479"),
                        Name = "2 years+"
                    },
                       new Experience
                    {
                        Id = Guid.Parse("58D7EA04-4F5D-40B4-9871-8FE028005EAF"),
                        Name = "3 years+"
                    },
                       new Experience
                    {
                        Id = Guid.Parse("3D29BDEB-C5E6-418F-AF0E-62D3B36EFB34"),
                        Name = "4 years+"
                    },
                          new Experience
                    {
                        Id = Guid.Parse("A3182B90-03EF-4E3B-96F2-3AA932773040"),
                        Name = "5 years+"
                    }
                });
            }
            #endregion 
            #region DrivingLicenses
            if (!await _context.DrivingLicences.AnyAsync())
            {
                await _context.DrivingLicences.AddRangeAsync(new DrivingLicense[]
                {
                    new DrivingLicense
                    {
                        Id = Guid.Parse("921B03B0-7D66-4413-AEE6-4D90815888D5"),
                        Name = "A"
                    },
                    new DrivingLicense
                    {
                        Id = Guid.Parse("8EA85325-9363-41F0-8975-9DFA542EDB45"),
                        Name = "A1"
                    },
                      new DrivingLicense
                    {
                        Id = Guid.Parse("6E36FC03-6FB3-471E-A0A4-710EC80208F5"),
                        Name = "A2"
                    },
                       new DrivingLicense
                    {
                        Id = Guid.Parse("7A04AB5F-A7D9-453B-988C-0318EF4021F3"),
                        Name = "M"
                    },
                       new DrivingLicense
                    {
                        Id = Guid.Parse("86B41B3C-59D6-4C77-817A-963F846F1E08"),
                        Name = "B"
                    },
                          new DrivingLicense
                    {
                        Id = Guid.Parse("D89C49C7-64E2-4DE3-B948-06B14FA252C5"),
                        Name = "B1"
                    }
                });
            }
            #endregion
            #region Military Statuses
            if (!await _context.MilitaryStatus.AnyAsync())
            {
                await _context.MilitaryStatus.AddRangeAsync(new MilitaryStatus[]
                {
                    new MilitaryStatus
                    {
                        Id = Guid.Parse("81C3313F-979B-4675-B29B-FFAF683D0F0A"),
                        Name = "Postponed" //tecilli
                    },
                    new MilitaryStatus
                    {
                        Id = Guid.Parse("EC555755-2F0F-4B4B-8CB2-2563FD6ADA8C"),
                        Name = "Done" //yapıldı
                    },
                      new MilitaryStatus
                    {
                        Id = Guid.Parse("261BBAB3-B5DF-4B24-A98D-2C174EAE8758"),
                        Name = "Exempt" //muaf
                    },
                       new MilitaryStatus
                    {
                        Id = Guid.Parse("BA969451-A01C-4834-A55C-D91D789C7E09"),
                        Name = "Not Done"
                    }
                });
            }
            #endregion
            #region Criterions
            if (!await _context.Criterions.AnyAsync())
            {
                await _context.Criterions.AddRangeAsync(new Criterion[]
                {
                    new Criterion
                    {
                        Id = Guid.Parse("080BAED9-2979-412E-BE8C-35FE7AFABAF8"),
                        DrivingLicenseId = Guid.Parse("86B41B3C-59D6-4C77-817A-963F846F1E08"),
						EducationLevelId = Guid.Parse("1535C788-AD4D-4134-97B9-7C823F3771D4"),
						ExperienceId = Guid.Parse("58D7EA04-4F5D-40B4-9871-8FE028005EAF"),
						MilitaryStatusId = Guid.Parse("EC555755-2F0F-4B4B-8CB2-2563FD6ADA8C"),

                    }
                });
            }
            #endregion
            #region LocationTypes
            if (!await _context.LocationTypes.AnyAsync())
            {
                await _context.LocationTypes.AddRangeAsync(new LocationType[]
                {
                    new LocationType
                    {
                        Id = Guid.Parse("9BE00933-CC44-4035-BCF9-CCB23454724F"),
                        Name = "Abroad" //yurt dışı
                    },
                    new LocationType
                    {
                        Id = Guid.Parse("B2E0A149-3DCF-42F1-91B1-632294BAEBCF"),
                        Name = "Türkiye" 
                    },
                      new LocationType
                    {
                        Id = Guid.Parse("31FD421B-BD5A-458D-8652-A93871D0DB03"),
                        Name = "KKTC"
                    }
                });
            }
            #endregion
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
			#region Jobs
			if(!await _context.Jobs.AnyAsync())
			{
				await _context.Jobs.AddRangeAsync(new Job[]
				{
					new Job
				{
					Id = Guid.Parse("9C2069FC-0535-4D04-B1BA-08ECEC4F125F"),
					Title = "Software Engineer",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
					Country = "USA",
					Province = "New York",
					District  = "Brooklyn",
					Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("5461BBC7-6540-4FFD-BD1B-428ADD2CD4AB"),
					CriterionId = Guid.Parse("080BAED9-2979-412E-BE8C-35FE7AFABAF8"),

                },
				new Job
				{
					Id = Guid.Parse("D0639FB3-5E1E-49E1-AADA-D9FC525A34EA"),
					Title = "Marketing Manager",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
                    Country = "USA",
                    Province = "California",
                    District  = "San Francisco",
                    Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("413B3F4B-ADBC-40CB-8ECD-3D4D07FFE83C"),

				},
				new Job
				{
					Id = Guid.Parse("A96C75FA-999B-4D83-928B-1342DBEEA32A"),
					Title = "Product Designer",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
                    Country = "USA",
                    Province = "California",
                    District  = "Los Angeles",
                    Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("72A35046-26F2-4E86-A623-8EE152F93CE3"),

				},
				new Job
				{
					Id = Guid.Parse("51A798E6-CAA3-4B20-A38F-ED8489265276"),
					Title = "Creative Director",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
                    Country = "USA",
                    Province = "California",
                    District  = "Sacramento",
                    Description = "Dolor justo tempor duo ipsum accusam rebum gubergren erat. Elitr stet dolor vero clita labore gubergren. Kasd sed ipsum elitr clita rebum ut sea diam tempor. " +
					"Sadipscing nonumy vero labore invidunt dolor sed, eirmod dolore amet aliquyam consetetur lorem, amet elitr clita et sed consetetur dolore accusam. Vero kasd nonumy justo rebum stet. " +
					"Ipsum amet sed lorem sea magna. Rebum vero dolores dolores elitr vero dolores magna, stet sea sadipscing stet et. Est voluptua et sanctus at sanctus erat vero sed sed, amet duo no diam " +
					"clita rebum duo, accusam tempor takimata clita stet nonumy rebum est invidunt stet, dolor.",
					CompanyId = Guid.Parse("B880972D-AAE5-457F-B2DB-5AB19476000F"),

				},
				new Job
				{
					Id = Guid.Parse("BBC076AB-38B9-4F33-9741-C8F81DDA84EA"),
					Title = "Wordpress Developer",
					SalaryStart =123,
					SalaryEnd = 456,
					DateLine = DateTime.Now.AddYears(1),
                     Country = "USA",
                    Province = "California",
                    District  = "San Diego",
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
