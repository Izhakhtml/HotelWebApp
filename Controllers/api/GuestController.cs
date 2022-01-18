using HotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelWebApp.Controllers.api
{
    public class GuestController : ApiController
    {
        // GET: api/Guest
        HotelModel dbContext = new HotelModel();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new {dbContext.Guests});
            }
            catch(SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Guest/5
        public async  Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Guest GetById = await dbContext.Guests.FindAsync(id);
                if (GetById != null)
                {
                    return Ok(new { GetById });
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: api/Guest
        public async Task<IHttpActionResult> Post([FromBody]Guest newGuest)
        {
            try
            {
                dbContext.Guests.Add(newGuest);
                await dbContext.SaveChangesAsync();
                return Ok("Added successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Guest/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Guest updateGuest)
        {
            try
            {
                Guest CatchId = await dbContext.Guests.FindAsync(id);
                if (CatchId != null)
                {
                    CatchId.FirstName = updateGuest.FirstName;
                    CatchId.LastName = updateGuest.LastName;
                    CatchId.Gender = updateGuest.Gender;
                    CatchId.BirthYear = updateGuest.BirthYear;
                    CatchId.ChackIn = updateGuest.ChackIn;
                    await dbContext.SaveChangesAsync();
                    return Ok("Updated successfully");
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Guest/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Guest deleteGuest = await dbContext.Guests.FindAsync(id);
                if (deleteGuest != null)
                {
                dbContext.Guests.Remove(deleteGuest);
                await dbContext.SaveChangesAsync();
                return Ok("Removed successfully");
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
