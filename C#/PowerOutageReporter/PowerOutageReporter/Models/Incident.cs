using System;
using System.ComponentModel.DataAnnotations;

namespace PowerOutageReporter.Models
{
	public class Incident
	{
		[Key, Required]
		public int Id { get; set; }
        [Required, StringLength(255)]
        public required string Address { get; set; }
		[Required]
		public Reason Reason { get; set; } = Reason.UnKnown;
        [Required]
        public DateTime ReportedOn { get; set; } = DateTime.UtcNow;
	}

	public enum Reason
	{
		UnKnown = 0,
		WindDamage = 1,
		WaterDamage = 2,
		TreeDamage = 3,
		DownPowerLine = 4
	}
}

