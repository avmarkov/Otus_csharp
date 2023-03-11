using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm1_db.Entities
{
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


    }
}
