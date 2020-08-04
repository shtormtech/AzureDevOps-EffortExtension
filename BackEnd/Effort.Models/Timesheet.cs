using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Effort.Models
{
    /// <summary>
    /// Timesheet class
    /// </summary>
    [Table("timesheet")]
    public class Timesheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(250)]
        public String UserUniqueName { get; set; }
        [Required]
        public int WorkItemId { get; set; }
        [Required]
        public int Duration { get; set; }
        [MaxLength(250)]
        public String Comment { get; set; }
        public Boolean IsDeleted { get; set; } = false;
        [ForeignKey("activity")]
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}
