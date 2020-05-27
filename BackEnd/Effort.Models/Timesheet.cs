using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Effort.Models
{
    [Table("timesheet")]
    public class Timesheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("activity")]
        public long ActivityTypeId { get; set; }
        [Required]
        [MaxLength(250)]
        public String UserId { get; set; }
        [Required]
        public int WorkItemId { get; set; }
        [Required]
        public long Duration { get; set; }
        [MaxLength(250)]
        public String Comment { get; set; }
        public Boolean Deleted { get; set; } = false;
    }
}
