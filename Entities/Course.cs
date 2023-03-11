using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace hm1_db.Entities
{
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
}
