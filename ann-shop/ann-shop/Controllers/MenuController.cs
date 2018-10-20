using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ann_shop.Models;

namespace ann_shop.Controllers
{
    public class MenuController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Menu
        public IQueryable<tbl_Menu> GetMenu()
        {
            return db.tbl_Menu;
        }

        // GET: api/Menu/5
        [ResponseType(typeof(tbl_Menu))]
        public async Task<IHttpActionResult> GetMenu(int id)
        {
            tbl_Menu tbl_Menu = await db.tbl_Menu.FindAsync(id);
            if (tbl_Menu == null)
            {
                return NotFound();
            }

            return Ok(tbl_Menu);
        }

        // PUT: api/Menu/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMenu(int id, tbl_Menu tbl_Menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Menu.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Menu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_MenuExists(id))
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

        // POST: api/Menu
        [ResponseType(typeof(tbl_Menu))]
        public async Task<IHttpActionResult> PostMenu(tbl_Menu tbl_Menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Menu.Add(tbl_Menu);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Menu.ID }, tbl_Menu);
        }

        // DELETE: api/Menu/5
        [ResponseType(typeof(tbl_Menu))]
        public async Task<IHttpActionResult> DeleteMenu(int id)
        {
            tbl_Menu tbl_Menu = await db.tbl_Menu.FindAsync(id);
            if (tbl_Menu == null)
            {
                return NotFound();
            }

            db.tbl_Menu.Remove(tbl_Menu);
            await db.SaveChangesAsync();

            return Ok(tbl_Menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_MenuExists(int id)
        {
            return db.tbl_Menu.Count(e => e.ID == id) > 0;
        }
    }
}