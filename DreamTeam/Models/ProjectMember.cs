using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DreamTeam.Models
{
    public class ProjectMember
    {
        public int Id { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public virtual TeamRole TeamRole { get; set; }
        [Required]
        public virtual Project Project { get; set; }
    }
}