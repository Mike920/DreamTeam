using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DreamTeam.Models;

namespace DreamTeam.Controllers
{
    public class TeamRolesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TeamRoles
        public IQueryable<TeamRole> GetTeamRoles()
        {
            return db.TeamRoles;
        }

        // GET: api/TeamRoles/5
        [ResponseType(typeof(TeamRole))]
        public IHttpActionResult GetTeamRole(string id)
        {
            TeamRole teamRole = db.TeamRoles.Find(id);
            if (teamRole == null)
            {
                return NotFound();
            }

            return Ok(teamRole);
        }

        // PUT: api/TeamRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeamRole(string id, TeamRole teamRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamRole.Name)
            {
                return BadRequest();
            }

            db.Entry(teamRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TeamRoles
        [ResponseType(typeof(TeamRole))]
        public IHttpActionResult PostTeamRole(TeamRole teamRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamRoles.Add(teamRole);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TeamRoleExists(teamRole.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = teamRole.Name }, teamRole);
        }

        // DELETE: api/TeamRoles/5
        [ResponseType(typeof(TeamRole))]
        public IHttpActionResult DeleteTeamRole(string id)
        {
            TeamRole teamRole = db.TeamRoles.Find(id);
            if (teamRole == null)
            {
                return NotFound();
            }

            db.TeamRoles.Remove(teamRole);
            db.SaveChanges();

            return Ok(teamRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamRoleExists(string id)
        {
            return db.TeamRoles.Count(e => e.Name == id) > 0;
        }
    }
}