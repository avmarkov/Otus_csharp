
using hm1_db;
using hm1_db.Entities;

using (OtusContext db = new OtusContext())
{
    FillTables(db);
    PrintTables(db);
    Console.ReadLine(); 

}

static bool FillTables(OtusContext db)
{
    bool res = true;
    try
    {
        Course[] courses = new Course[]
        {
            new Course { Name = "C# Developer. Professional", DateStart = DateTime.Parse(s:"2023-01-31"), DateEnd = DateTime.Parse(s:"2023-09-11"), Price = 67000 },
            new Course { Name = "PostgreSQL для администраторов баз данных и разработчиков", DateStart = DateTime.Parse(s:"2022-10-17"), DateEnd = DateTime.Parse(s:"2023-03-17"), Price = 100000 },
            new Course { Name = "C# ASP.NET Core разработчик", DateStart = DateTime.Parse(s:"2023-05-31"), DateEnd = DateTime.Parse(s:"2023-10-31"), Price = 100000  },
            new Course { Name = "PostgreSQL Cloud Solutions",  DateStart = DateTime.Parse(s:"2023-04-27"), DateEnd = DateTime.Parse(s:"2023-09-27"), Price = 65000  },
            new Course { Name = "C# Developer. Basic", DateStart = DateTime.Parse(s:"2023-04-26"), DateEnd = DateTime.Parse(s:"2023-09-25"), Price = 50000  }
        };
        db.Courses.AddRange(entities: courses);


        

        Student[] students = new Student[]
        {
            new Student { FirstName = "Иван", LastName = "Иванов", SurName = "Иванович", Email = "ivanov_ii@mail.ru", EnrollmentDate = DateTime.Parse(s:"2021-01-01"), Course = courses[0]},
            new Student { FirstName = "Петр", LastName = "Петров", SurName = "Петрович", Email = "petrov_pp@mail.ru", EnrollmentDate = DateTime.Parse(s:"2022-11-01"), Course = courses[1]},
            new Student { FirstName = "Алексей", LastName = "Алексеев", SurName = "Алексеевич", Email = "alekseev_aa@mail.ru", EnrollmentDate = DateTime.Parse(s:"2021-12-01"), Course = courses[0]},
            new Student { FirstName = "Семен", LastName = "Семенов", SurName = "Семенович", Email = "semenov_ss@mail.ru", EnrollmentDate = DateTime.Parse(s:"2022-10-01"), Course = courses[2]  },
            new Student { FirstName = "Роман", LastName = "Романов", SurName = "Романович", Email = "romanov_rr@mail.ru", EnrollmentDate = DateTime.Parse(s:"2023-02-01"), Course = null  }
        };

        db.Students.AddRange(entities: students);


        Teacher[] teachers = new Teacher[]
        {
            new Teacher { FirstName = "Иван", LastName = "Сидоров", SurName = "Петрович", Email = "sidorov_ip@mail.ru", Education = "Кандидат технических наук", Job = "Яндекс", Course = courses[0] },
            new Teacher { FirstName = "Петр", LastName = "Кузнецов", SurName = "Александрович", Email = "kuznetzov_pf@mail.ru",  Education = "Кандидат технических наук", Job = "Сбербанк", Course = courses[1]   },
            new Teacher { FirstName = "Алексей", LastName = "Соколов", SurName = "Петрович", Email = "sokolov_ap@mail.ru",  Education = "Кандидат технических наук", Job = "Отус", Course = courses[2]  },
            new Teacher { FirstName = "Семен", LastName = "Смирнов", SurName = "Иванович", Email = "smirnov_si@mail.ru",  Education = "Кандидат технических наук" , Job = "Майл РУ", Course = courses[3]  },
            new Teacher { FirstName = "Романов", LastName = "Попов", SurName = "Михайлович", Email = "romanov_pm@mail.ru",  Education = "Кандидат технических наук", Job = "ВТБ", Course = null   }
        };

        db.Teachers.AddRange(entities: teachers);
        db.SaveChanges();
    }
    catch (Exception e)
    {
        res = false;
        Console.WriteLine("Error " + e.Message);
    }

    return res;
}

static bool PrintTables(OtusContext db)
{
    bool res = true;
    try
    {
        Console.WriteLine("Print Student table...");
        var studentList = db.Students.ToList();
        foreach (var student in studentList)
        {
            Console.WriteLine($"ФИО: {student.LastName} {student.FirstName} {student.SurName},  email: {student.Email},  курс: {student.Course?.Name} ");
        }

        Console.WriteLine();
        Console.WriteLine("Print Teacher table...");
        var teacherList = db.Teachers.ToList();
        foreach (var teacher in teacherList)
        {
            Console.WriteLine($"ФИО: {teacher.LastName} {teacher.FirstName} {teacher.SurName},  email: {teacher.Email},  место работы: {teacher.Job},  курс: {teacher.Course?.Name} ");
        }

        Console.WriteLine();
        Console.WriteLine("Print Course table...");
        var courseList = db.Courses.ToList();
        foreach (var course in courseList)
        {
            Console.WriteLine($"Курс: {course.Name},  стоимость: {course.Price},  дата старта: {course.DateStart.ToShortDateString()},  дата окончания: {course.DateEnd.Date.ToShortDateString()} ");
        }

    }
    catch (Exception e)
    {
        res = false;
        Console.WriteLine("Error " + e.Message);
    }

    return res;
}
