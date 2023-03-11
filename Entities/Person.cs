using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hm1_db.Entities
{
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
}
