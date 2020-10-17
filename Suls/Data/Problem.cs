using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Data
{
    public class Problem
    {
        public Problem()
        {
            Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Required]
        public ushort Points { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }

  // Has an Id – a string, Primary Key
  // Has a Name – a string with min length 5 and max length 20 (required)
  //Has Points– an integer between 50 and 300 (required)

}
