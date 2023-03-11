
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace hm1_db.Entities
{
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
}
