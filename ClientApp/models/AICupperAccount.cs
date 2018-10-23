using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aicupper.models
{
    public class AICupperAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AICupperCustomerID { get; set; }
        public Guid AICupperAccountID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string CompanyAddress { get; set; }
        
        public string UserName { get; set; }

        public string SaltedPassword { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Boolean? IsActive { get; set; }

        public List<judge> Judges { get; set; }

        public List<cuppingEvent> CuppingEvents { get; set; }
    }
}
