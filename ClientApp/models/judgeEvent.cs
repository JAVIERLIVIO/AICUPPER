using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aicupper.models
{
    public class judgeEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JudgeEventID { get; set; }
        
        [Required]
        public int JudgeID { get; set; }

        [Required]
        public Guid AICupperAccountID { get; set; }

        [Required]
        public int CuppingEventID { get; set; }

        public DateTime CreatedOn { get; set; }

        public Boolean IsEnabled { get; set; }
    }
}