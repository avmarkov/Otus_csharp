# Домашняя работа № 1. Подключаем базы данных к проекту
### 1. Создать базу данных PostgreSQL для одной из компаний на выбор: Авито, СберБанк, Otus или eBay. Написать скрипт создания 3 таблиц, которые должны иметь первичные ключи и быть соединены внешними ключами.

* Для решения домашнего задания использовал EntityFrameworkCore. Установил Npgsql.EntityFrameworkCore.PostgreSQL

* В качестве БД выбрал БД Otus

* Создал классы сущностей (Person, Student, Teacher, Course).

Классы Student и Teacher наследуются от Person. Реализовал связь "один ко многим" для таблиц Course, Student, Teacher.
Т.е. у одного курса много студентов и преподавателей.

```cs
public class Person
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Required] // Not null
        [StringLength(maximumLength: 200)]
        [Column(name: "firstname")]
        public string FirstName { get; set; }


        [Required] // Not null
        [StringLength(maximumLength: 200)]
        [Column(name: "lastname")]
        public string LastName { get; set; }

        [MaybeNull]
        [Column(name: "surname")]
        public string SurName { get; set; }

        [MaybeNull]
        [Column(name: "phone")]
        public string Phone { get; set; }

        [MaybeNull]
        [Column(name: "email")]
        public string Email { get; set; }
    }
```

```cs
public class Student : Person
    {
        [MaybeNull]
        [Column(name: "enrollmentdate")]      
        public DateTime EnrollmentDate { get; set; } // дата зачиления
                                                     // 

        [MaybeNull]
        public Course? Course { get; set; }


        [MaybeNull]
        [Column(name: "courseid")]
        public int? CourseId { get; set; }

    }
```

```cs
public class Teacher: Person
    {
        [MaybeNull]
        [StringLength(maximumLength: 250)]
        [Column(name: "education")]
        public string Education { get; set; } //  образование 


        [MaybeNull]
        [StringLength(maximumLength: 250)]
        [Column(name: "job")]
        public string Job { get; set; } // место работы


        [MaybeNull]
        public Course? Course { get; set; }


        [MaybeNull]        
        [Column(name: "courseid")]
        public int? CourseId { get; set; }

    }
```

```cs
public class Course
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "name")]
        [Required]
        public string Name { get; set; }

        [MaybeNull]
        [Column(name: "datestart")]
        public DateTime DateStart { get; set; }

        [MaybeNull]
        [Column(name: "dateend")]
        public DateTime DateEnd { get; set; }

        [MaybeNull]
        [Column(name: "price")]
        public double Price { get; set; }

        [MaybeNull]
        [Column(name: "studentid")]
        public ICollection<Student> StudentId { get; set; } = new List<Student>();

        [MaybeNull]
        [Column(name: "teacherid")]
        public ICollection<Teacher> TeacherId { get; set; }
    }
```

4. Далее создал класс OtusContext - наследник от DbContext:
```cs
public class OtusContext : DbContext
    {
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public OtusContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable(name: "student");
            modelBuilder.Entity<Teacher>().ToTable(name: "teacher"); 
            modelBuilder.Entity<Course>().ToTable(name: "course");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=otus;Username=postgres;Password=admin");
        }       
    }
```

В результате создалась такая БД:

> <image src="images/db_shema.png" alt="db_shema">

### 2. Написать скрипт заполнения таблиц данными, минимум по пять строк в каждую.
Заполнение таблиц данными по 5 в каждую таблице реализовано в методе FillTables(db):

```cs
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
```

### 3. Создать консольную программу, которая выводит содержимое всех таблиц.
Содержимое таблиц выводится в методе PrintTables(OtusContext db)

```cs
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
```

Результат вывода содержимого таблиц:

> <image src="images/print_tables.png" alt="print_tables">

### 4. Добавить в программу возможность добавления в таблицу на выбор.
Для добавления я выбрал таблицу student. Добавление реализовано в функции AddNewStudent(OtusContext db)

```cs
static bool AddNewStudent(OtusContext db)
{
    bool res = true;
    Console.WriteLine();

    Console.WriteLine("Для добавления данных в таблицу student нажмите клавишу \"Пробел\". Для выхода - \"Enter\"");

    var key = Console.ReadKey().Key;
    Console.WriteLine();
    Console.WriteLine("Нажата клавиша " + key.ToString());
    if (key == ConsoleKey.Spacebar)
    {
        Student student = new Student();

        Console.WriteLine("Введите фамилию: ");
        var lastName = Console.ReadLine();
        student.LastName = lastName;

        Console.WriteLine("Введите имя: ");
        var firstName = Console.ReadLine();
        student.FirstName = firstName;

        Console.WriteLine("Введите отчетство: ");
        var surName = Console.ReadLine();
        student.SurName = surName;

        Console.WriteLine("Введите телефон: ");
        var phone = Console.ReadLine();
        student.Phone = phone;

        Console.WriteLine("Введите элетронную почту: ");
        var email = Console.ReadLine();
        student.Email = email;

        Console.WriteLine("Введите дату зачисления: ");
        var enrollmentDate = Console.ReadLine();
        student.EnrollmentDate = DateTime.Parse(s: enrollmentDate);

        try
        {
            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("Новый студент добавлен в БД.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! " + e.Message);
            res = false;
        }


    }
    return res;
}
```

Результат:

> <image src="images/add_student.png" alt="add_student">
