using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aicupper.models
{
    public class cuppingEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CuppingEventID")]
        public int Id { get; set; }

        public Guid AICupperAccountID { get; set; }

        public int NumberOfSamples { get; set; }

        public int NumberOfJudges { get; set; }

        public string Title { get; set; }

        public string EventNotes { get; set; }

        public string EventLocation { get; set; }

        public DateTime EventDate { get; set; }
    }
}
