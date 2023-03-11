# �������� ������ � 1. ���������� ���� ������ � �������

1. ��� ������� ��������� ������� ����������� EntityFrameworkCore. ��������� Npgsql.EntityFrameworkCore.PostgreSQL

2. � �������� �� ������ �� Otus

3. ������ ������ ��������� (Person, Student, Teacher, Course):

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
        public DateTime EnrollmentDate { get; set; } // ���� ���������
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
        public string Education { get; set; } //  ����������� 


        [MaybeNull]
        [StringLength(maximumLength: 250)]
        [Column(name: "job")]
        public string Job { get; set; } // ����� ������


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