namespace Attendance_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Attendance_System.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Faker;
    using FizzWare.NBuilder;
    using WebGrease.Css.Extensions;
    using Attendance_System.DTO;

    internal sealed class Configuration : DbMigrationsConfiguration<Attendance_System.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Attendance_System.Models.ApplicationDbContext context)
        {


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var institute = new List<Institute>
            {
                new Institute
                {
                    InstituteName = "eaaa",
                    ILogo = "Logo.jpg",
                    InstituteId = 1
                }
            };
            context.Institute.AddOrUpdate(i => i.InstituteId, institute.ToArray());
            context.SaveChanges();

            //Adds Courses
            var courses = new List<Course>
            {
                new Course {
                    CourseId = 1,
                    CourseName = "Backend",
                    EducationName = "PBA-WEB",
                    Start = new DateTime(2017, 11, 12),
                    End = new DateTime(2018, 03, 12),
                    },
                new Course {
                    CourseId = 2,
                    CourseName = "Frontend",
                    EducationName = "PBA-WEB",
                    Start = new DateTime(2017, 11, 12),
                    End = new DateTime(2018, 03, 12),
                    },
                new Course {
                    CourseId = 3,
                    CourseName = "Database",
                    EducationName = "PBA-WEB",
                    Start = new DateTime(2017, 11, 12),
                    End = new DateTime(2018, 03, 12),
                    },
                new Course {
                    CourseId = 4,
                    CourseName = "Interface Design",
                    EducationName = "PBA-WEB",
                    Start = new DateTime(2017, 11, 12),
                    End = new DateTime(2018, 03, 12),
                    },
                new Course {
                    CourseId = 5,
                    CourseName = "Disciplinary Showoff",
                    EducationName = "PBA-WEB",
                    Start = new DateTime(2017, 12, 15),
                    End = new DateTime(2018, 03, 12),
                    }
            };
            context.Course.AddOrUpdate(c => c.CourseId, courses.ToArray());
            context.SaveChanges();

            //Add Lectures
            var lectures = new List<Lecture>
            {
                new Lecture
                {
                    CourseId = 5,
                    StartTime = new DateTime(2017, 12, 15, 10, 30, 00),
                    EndTime = new DateTime(2017, 12, 15, 12, 30, 00),
                    LectureName = "Show-Off Presentation",
                },
                new Lecture
                {
                    CourseId = 1,
                    StartTime = new DateTime(2017, 11, 12, 8, 30, 00),
                    EndTime = new DateTime(2017, 11, 12, 12, 30, 00),
                    LectureName = "Lecture 1",
                },
                new Lecture
                {
                    CourseId = 1,
                    StartTime = new DateTime(2017, 12, 13, 8, 30, 00),
                    EndTime = new DateTime(2017, 12, 13, 12, 30, 00),
                    LectureName = "Lecture 2",
                },
                new Lecture
                {
                    CourseId = 1,
                    StartTime = new DateTime(2017, 12, 21, 8, 30, 00),
                    EndTime = new DateTime(2017, 12, 21, 12, 30, 00),
                    LectureName = "Lecture 3",
                },
                new Lecture
                {
                    CourseId = 1,
                    StartTime = new DateTime(2017, 12, 22, 8, 30, 00),
                    EndTime = new DateTime(2017, 12, 22, 12, 30, 00),
                    LectureName = "Lecture 4",
                },
                new Lecture
                {
                    CourseId = 2,
                    StartTime = new DateTime(2017, 12, 21, 8, 30, 00),
                    EndTime = new DateTime(2017, 12, 21, 12, 30, 00),
                    LectureName = "Lecture 1",
                },
                new Lecture
                {
                    CourseId = 2,
                    StartTime = new DateTime(2017, 12, 23, 8, 30, 00),
                    EndTime = new DateTime(2017, 12, 23, 12, 30, 00),
                    LectureName = "Lecture 2",
                },
                new Lecture
                {
                    CourseId = 2,
                    StartTime = new DateTime(2017, 1, 1, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 1, 12, 30, 00),
                    LectureName = "Lecture 3",
                },
                new Lecture
                {
                    CourseId = 2,
                    StartTime = new DateTime(2017, 1, 3, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 3, 12, 30, 00),
                    LectureName = "Lecture 4",
                },
                new Lecture
                {
                    CourseId = 3,
                    StartTime = new DateTime(2017, 1, 5, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 5, 12, 30, 00),
                    LectureName = "Lecture 1",
                },
                new Lecture
                {
                    CourseId = 3,
                    StartTime = new DateTime(2017, 1, 9, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 9, 12, 30, 00),
                    LectureName = "Lecture 2",
                },
                new Lecture
                {
                    CourseId = 3,
                    StartTime = new DateTime(2017, 1, 10, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 10, 12, 30, 00),
                    LectureName = "Lecture 3",
                },
                new Lecture
                {
                    CourseId = 3,
                    StartTime = new DateTime(2017, 1, 12, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 12, 12, 30, 00),
                    LectureName = "Lecture 4",
                },
                new Lecture
                {
                    CourseId = 4,
                    StartTime = new DateTime(2017, 1, 17, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 17, 12, 30, 00),
                    LectureName = "Lecture 1",
                },
                new Lecture
                {
                    CourseId = 4,
                    StartTime = new DateTime(2017, 1, 22, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 22, 12, 30, 00),
                    LectureName = "Lecture 2",
                },
                new Lecture
                {
                    CourseId = 4,
                    StartTime = new DateTime(2017, 1, 12, 8, 30, 00),
                    EndTime = new DateTime(2017, 1, 12, 12, 30, 00),
                    LectureName = "Lecture 3",
                },
                new Lecture
                {
                    CourseId = 4,
                    StartTime = new DateTime(2017, 1, 26, 8, 30, 00),
                    EndTime = new DateTime(2017, 11, 26, 12, 30, 00),
                    LectureName = "Lecture 4",
                }
            };

            context.Lecture.AddOrUpdate(l => l.LectureId, lectures.ToArray());
            context.SaveChanges();

            // Add roles to Solution
            var roleManager = new List<IdentityRole>
            {
               new IdentityRole { Id="1", Name="Admin"},
               new IdentityRole { Id="2", Name="Teacher"},
               new IdentityRole { Id="3", Name="Student" }
            };

            context.Roles.AddOrUpdate(r => r.Id, roleManager.ToArray());
            context.SaveChanges();

            // Seedint studentUsers Because of IdentityFramework Autogenrated id this is now has own AI ids for further Seed

            var studentUsers = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "6",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "7",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "8",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "9",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "10",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "11",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "12",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                    new ApplicationUser
                {
                    Id = "13",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "14",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "15",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "16",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "17",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "18",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "19",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "20",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "21",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "22",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "23",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "24",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "25",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "26",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "27",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "28",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "29",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                },
                new ApplicationUser
                {
                    Id = "30",
                    Email = Faker.Internet.Email(),
                    PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==",
                    UserName = Internet.Email(),
                    FirstName = Name.First(),
                    LastName = Name.Last()
                }
           };

            context.Users.AddOrUpdate(u => u.Id, studentUsers.ToArray());
            context.SaveChanges();

            //Adds StudentUsers to the Role Student
            foreach (ApplicationUser student in studentUsers)
            {
                manager.AddToRole(student.Id, "Student");
            }
            context.SaveChanges();


            // enrolls the studentUsers with id 6-30 
            var studentEnrollment = new List<Enrollment>
            {
              new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "6",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "6",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "6",
              },
              new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "7",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "7",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "7",
              },
              new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "8",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "8",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "8",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "9",
              },
               new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "9",
              },
                new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "9",
              },
              new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "10",
              },
               new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "10",
              },
              new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "11",
              },
              new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "11",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "12",
              },
               new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "12",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "13",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "13",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "14",
              },
               new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "14",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "15",
              },
              new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "15",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "16",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "16",
              },
              new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "17",
              },
              new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "17",
              },
              new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "18",
              },
              new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "18",
              },
               new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "18",
              },
                new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "19",
              },
                new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "19",
              },
                new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "20",
              },
                 new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "21",
              },
                new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "22",
              },
                new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "22",
              },
                new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "23",
              },
                new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "23",
              },
                new Enrollment
              {
                  CourseId = 3,
                  ApplicationUserId = "24",
              },
                new Enrollment
              {
                  CourseId = 4,
                  ApplicationUserId = "24",
              },
                new Enrollment
              {
                  CourseId = 1,
                  ApplicationUserId = "25",
              },
                new Enrollment
              {
                  CourseId = 2,
                  ApplicationUserId = "25",
              },
            };

            context.Enrollment.AddOrUpdate(e => e.EnrollmentId, studentEnrollment.ToArray());
            context.SaveChanges();


            //FixedAdmin on startup with working PASS PASS123!
            string password = "Pass123!";
            string email = "Admin@admin.dk";
            string userName = email;
            string uId = "2";

            ApplicationUserManager userMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new ApplicationUser { Email = email, UserName = userName, Id = uId }, password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, "Admin"))
            {
                userMgr.AddToRole("2", "Admin");
            }

            context.SaveChanges();

            //FixedTeacher on Startup WIth working PASS PASS123!
            string teacherPassword = "Pass123!";
            string teacherEmail = "Teacher@Teacher.dk";
            string teacherUserName = teacherEmail;
            string teacherUId = "3";

            ApplicationUser userTeacher = userMgr.FindByName(teacherUserName);
            if (userTeacher == null)
            {
                userMgr.Create(new ApplicationUser { Email = teacherEmail, UserName = teacherUserName, Id = teacherUId }, teacherPassword);
                userTeacher = userMgr.FindByName(teacherUserName);
            }
            if (!userMgr.IsInRole(userTeacher.Id, "Teacher"))
            {
                userMgr.AddToRole("3", "Teacher");
            }
            context.SaveChanges();

            //FixedTeacher on Startup WIth working PASS PASS123!
            string studentPassword = "Pass123!";
            string studentEmail = "Student@student.dk";
            string studentUserName = studentEmail;
            string studentFirstName = "Allan";
            string studentLastName = "Olesen";
            string studentUId = "4";

            ApplicationUser userStudent = userMgr.FindByName(studentUserName);
            if (userStudent == null)
            {
                userMgr.Create(new ApplicationUser { Email = studentEmail, UserName = studentUserName, Id = studentUId, FirstName = studentFirstName, LastName = studentLastName }, studentPassword);
                userStudent = userMgr.FindByName(studentUserName);
            }
            if (!userMgr.IsInRole(userStudent.Id, "Student"))
            {
                userMgr.AddToRole("4", "Student");
            }
            context.SaveChanges();

            // List of 8 Teachers Without Password or Enrollsments
            var teachers = Builder<ApplicationUser>.CreateListOfSize(4)
                .All()
                .With(s => s.Email = Faker.Name.First() + "@eaaa.com")
                .With(s => s.PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==")
                .With(s => s.SecurityStamp = "417d9850-177a-486c-9e08-4be21bad60f7")
                .With(s => s.UserName = Faker.Internet.UserName() + "_teacher")
                .With(s => s.PhoneNumber = Faker.Phone.Number())
                .With(s => s.TwoFactorEnabled = false)
            .Build();

            context.Users.AddOrUpdate(t => t.Id, teachers.ToArray());
            context.SaveChanges();

            foreach (ApplicationUser teacher in teachers)
            {
                manager.AddToRole(teacher.Id, "Teacher");
            }

            // Creates 15 Test Students/users Who are not enrolled in any course
            var students = Builder<ApplicationUser>.CreateListOfSize(15)
                .All()
                .With(s => s.Email = Faker.Name.First() + "@eaaa.dk")
                .With(s => s.PasswordHash = "AHYvI4ctMM2uaLhgi9yEBO/XdF5soAp+zk9pnV7zWumed56TMU9K0k2Y2q+KPtw9Uw==")
                .With(s => s.SecurityStamp = "417d9850-177a-486c-9e08-4be21bad60f7")
                .With(s => s.UserName = Faker.Internet.UserName() + "_student")
                .With(s => s.FirstName = Faker.Name.First())
                .With(s => s.LastName = Faker.Name.Last())
                .With(s => s.PhoneNumber = Faker.Phone.Number())
                .With(s => s.TwoFactorEnabled = false)
            .Build();

            context.Users.AddOrUpdate(s => s.Id, students.ToArray());
            context.SaveChanges();

            foreach (ApplicationUser student in students)
            {
                manager.AddToRole(student.Id, "Student");
            }

            var enrollment = new List<Enrollment>
            {
                new Enrollment
                {
                    CourseId = 1,
                    ApplicationUserId = "4",
                },
                new Enrollment
                {
                    CourseId = 2,
                    ApplicationUserId = "4",
                },
                new Enrollment
                {
                    CourseId = 3,
                    ApplicationUserId = "4",
                }
            };

            context.Enrollment.AddOrUpdate(e => e.EnrollmentId, enrollment.ToArray());
            context.SaveChanges();


            var attendances = new List<Attendance>
            {
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 38, 00),
                    ApplicationUserId = "6",
                    LectureId = 2
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 38, 00),
                    ApplicationUserId = "7",
                    LectureId = 2
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 46, 00),
                    ApplicationUserId = "8",
                    LectureId = 2
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 46, 00),
                    ApplicationUserId = "6",
                    LectureId = 1
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 38, 00),
                    ApplicationUserId = "9",
                    LectureId = 1
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 55, 00),
                    ApplicationUserId = "10",
                    LectureId = 1
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 55, 00),
                    ApplicationUserId = "12",
                    LectureId = 1
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 8, 38, 00),
                    ApplicationUserId = "6",
                    LectureId = 1
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 10, 38, 00),
                    ApplicationUserId = "10",
                    LectureId = 1
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 09, 38, 00),
                    ApplicationUserId = "6",
                    LectureId = 5
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 08, 38, 00),
                    ApplicationUserId = "25",
                    LectureId = 5
                },
                new Attendance
                {
                    ArrivalTime = new DateTime(2017, 11, 12, 09, 38, 00),
                    ApplicationUserId = "26",
                    LectureId = 5
                },
            };

                context.Attendance.AddOrUpdate(l => l.AttendanceId, attendances.ToArray());
                //   context.SaveChanges();


                int[] CoursesIds = { 1, 2, 3, 4 };
                var iDGenerator = new RandomGenerator();

            /*
            var enrollments = Builder<Enrollment>.CreateListOfSize(100)
                .All()
                .With(e => e.UserId = iDGenerator.Next(2, 60))
                .With(e => e.CourseId = iDGenerator.Next(1, 4))
            .Build();

            context.SaveChanges();
            */
        }

        private void Build()
        {
            throw new NotImplementedException();
        }
    }
}
