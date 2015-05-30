using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DreamTeam.Models
{
    public class TeamRole
    {
        [Required]
        [Key]
        public string Name { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}