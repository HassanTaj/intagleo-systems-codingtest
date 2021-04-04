namespace CodingAssignment.Infrastructure.Migrations {
    using CodingAssignment.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingAssignment.Infrastructure.AppDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodingAssignment.Infrastructure.AppDbContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Enumerable.Range(1, 10).ToList().ForEach(x => {
                context.Courses.Add(new Course {
                    Name = $"Course - {x}",
                    CourseNo = $"C-{x}"
                });
            });
            context.SaveChanges();

            var courses = context.Courses.ToList().ToArray();
            Trace.WriteLine(courses.Length);
            context.Students.AddOrUpdate(new Student {
                Name = $"Jhone Doe",
                Address = $"44 Avinue, Imagination Town",
                Phone = "00000000",
                Email = "jd@somemail.com",
                RollNo = $"FIN-1",
                StudentCourses = new List<StudentCourse> {
                    new StudentCourse {
                        Course = courses[1],
                        ObtainedMarks = 95
                    },
                    new StudentCourse {
                        Course = courses[2],
                        ObtainedMarks = 95
                    },
                    new StudentCourse {
                        Course = courses[3],
                        ObtainedMarks = 95
                    }
                }
            },
            new Student {
                Name = $"Travis Bulgard",
                Address = $"45 Avinue, Imagination Town",
                Phone = "00000001",
                Email = "tb@somemail.com",
                RollNo = $"FIN-2",
                StudentCourses = new List<StudentCourse> {
                    new StudentCourse {
                        Course = courses[4],
                        ObtainedMarks = 80
                    },
                    new StudentCourse {
                        Course = courses[5],
                        ObtainedMarks = 80
                    },
                    new StudentCourse {
                        Course = courses[6],
                        ObtainedMarks = 80
                    }
                }
            },
            new Student {
                Name = $"Jean Micheal",
                Address = $"48 Avinue, Imagination Town",
                Phone = "00000002",
                Email = "jm@somemail.com",
                RollNo = $"FIN-3",
                StudentCourses = new List<StudentCourse> {
                    new StudentCourse {
                        Course = courses[7],
                        ObtainedMarks = 50
                    },
                    new StudentCourse {
                        Course = courses[8],
                        ObtainedMarks = 60
                    },
                    new StudentCourse {
                        Course = courses[9],
                        ObtainedMarks = 60
                    }
                }
            },
            new Student {
                Name = $"Jhony Bravo",
                Address = $"68 Avinue, Imagination Town",
                Phone = "00000003",
                Email = "bravo@somemail.com",
                RollNo = $"FIN-4",
                StudentCourses = new List<StudentCourse> {
                    new StudentCourse {
                        Course = courses[7],
                        ObtainedMarks = 30
                    },
                    new StudentCourse {
                        Course = courses[8],
                        ObtainedMarks = 30
                    },
                    new StudentCourse {
                        Course = courses[9],
                        ObtainedMarks = 20
                    }
                }
            },
            new Student {
                Name = $"Jhon Cena",
                Address = $"68 Avinue, Imagination Town",
                Phone = "00000004",
                Email = "bravo@somemail.com",
                RollNo = $"FIN-5"
            });
            context.SaveChanges();

        }
    }
}
