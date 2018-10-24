using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aicupper.models
{
    public class judge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JudgeID { get; set; }

        [Required]
        public Guid AICupperAccountID { get; set; }

        [Required]
        public string JudgeName { get; set; }

        public string KnownAs { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public Boolean IsEnabled { get; set; }

        public ICollection<judgeEvent> CuppingEvents { get; set; }
    }
}
