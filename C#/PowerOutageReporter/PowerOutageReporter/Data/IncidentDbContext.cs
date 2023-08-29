using System;
using Microsoft.EntityFrameworkCore;
using PowerOutageReporter.Models;

namespace PowerOutageReporter.Data
{
	public class IncidentDbContext: DbContext
	{
		public IncidentDbContext(DbContextOptions<IncidentDbContext> options) : base (options)
		{
		}

		public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Incident>().ToTable("Incidents");
			modelBuilder.Entity<Incident>(entity =>
			{
				entity.HasKey(incident => incident.Id);
				entity.Property(incident => incident.Address);
                entity.Property(incident => incident.Reason).HasConversion<int>();
                entity.Property(incident => incident.ReportedOn);
            });
        }
    }
}

