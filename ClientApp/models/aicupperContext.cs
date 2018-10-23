using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace aicupper.models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        { }
        public DbSet<country> Countries { get; set; }
        public DbSet<judge> Judges { get; set; }
        public DbSet<cuppingEvent> CuppingEvents { get; set; }
        public DbSet<AICupperAccount> AICupperAccounts { get; set; }
        public DbSet<judgeEvent> JudgeCuppingEvents { get; set; }        
    }
}