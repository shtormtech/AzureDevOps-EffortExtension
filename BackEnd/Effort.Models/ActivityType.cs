using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Effort.Models
{
    [Table("activity_type")]
    public class ActivityType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(100)]
        public String Code { get; set; }
        [MaxLength(250)]
        public String Comment { get; set; }
        [Required]
        public Boolean IsDeleted { get; set; } = false;
        [Required]
        [MaxLength(30)]
        public string Color { get; set; }
    }
}
