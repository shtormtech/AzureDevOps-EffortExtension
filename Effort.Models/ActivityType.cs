using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Effort.Models
{
    [Table("activity_type")]
    public class ActivityType
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(100)]
        public String Code { get; set; }
        [MaxLength(250)]
        public String Comment { get; set; }
        [Required]
        public Boolean Deleted { get; set; } = false;
    }
}
