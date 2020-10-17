using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Data
{
    public class Submission
    {
        public Submission()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(800)]
        [Required]
        public string Code { get; set; }

        [Required]
        public uint Results { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }
        public Problem Problem { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
   // Has an Id – a string, Primary Key
   // Has Code – a string with min length 30 and max length 800 (required)
   // Has Achieved Result – an integer between 0 and 300 (required)
   // Has a Created On – a DateTime object (required)
   // Has Problem – a Problem object
   // Has User – a User object   
}
