
using hm1_db;
using hm1_db.Entities;

using (OtusContext db = new OtusContext())
{

    Student[] students = new Student[]
    {
        new Student { FirstName = "Иван", LastName = "Иванов", SurName = "Иванович", Email = "ivanov_ii@mail.ru", EnrollmentDate = DateTime.Parse(s:"2021-01-01") },
        new Student { FirstName = "Петр", LastName = "Петров", SurName = "Петрович", Email = "petrov_pp@mail.ru", EnrollmentDate = DateTime.Parse(s:"2022-11-01")  },
        new Student { FirstName = "Алексей", LastName = "Алексеев", SurName = "Алексеевич", Email = "alekseev_aa@mail.ru", EnrollmentDate = DateTime.Parse(s:"2021-12-01")  },
        new Student { FirstName = "Семен", LastName = "Семенов", SurName = "Семенович", Email = "semenov_ss@mail.ru", EnrollmentDate = DateTime.Parse(s:"2022-10-01")  },
        new Student { FirstName = "Роман", LastName = "Романов", SurName = "Романович", Email = "romanov_rr@mail.ru", EnrollmentDate = DateTime.Parse(s:"2023-02-01")  }
    };

    db.Students.AddRange(entities: students);
    db.SaveChanges();

    Teacher[] teachers = new Teacher[]
    {
        new Teacher { FirstName = "Иван", LastName = "Сидоров", SurName = "Петрович", Email = "ivanov_ii@mail.ru", Education = "Кандидат технических наук", Job = "Яндекс" },
        new Teacher { FirstName = "Петр", LastName = "Кузнецов", SurName = "Александрович", Email = "petrov_pp@mail.ru",  Education = "Кандидат технических наук", Job = "Сбербанк"   },
        new Teacher { FirstName = "Алексей", LastName = "Соколов", SurName = "Петрович", Email = "alekseev_aa@mail.ru",  Education = "Кандидат технических наук", Job = "Отус"  },
        new Teacher { FirstName = "Семен", LastName = "Смирнов", SurName = "Иванович", Email = "semenov_ss@mail.ru",  Education = "Кандидат технических наук" , Job = "Майл РУ"  },
        new Teacher { FirstName = "Романов", LastName = "Попов", SurName = "Михайлович", Email = "romanov_rr@mail.ru",  Education = "Кандидат технических наук", Job = "ВТБ"   }
    };

    db.Students.AddRange(entities: students);
    db.SaveChanges();
}
