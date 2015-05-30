using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DreamTeam.Models
{
    public class Project
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public virtual List<TeamRole> TeamRoles { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public virtual ApplicationUser Owner { get; set; }
        [ScaffoldColumn(false)]
        public virtual List<ProjectMember> ProjectMembers { get; set; }


    }
}