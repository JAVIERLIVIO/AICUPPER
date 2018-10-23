using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aicupper.models
{
    public class AICupperAccount
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.Column("AICupperCustomerID")]
        public int Id { get; set; }
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
    }
}
