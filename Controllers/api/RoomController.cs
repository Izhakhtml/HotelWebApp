using HotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApp.Controllers.api
{
    public class RoomController : ApiController
    {
        static string connectionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        static List<Room> roomsList = new List<Room>();
        // GET: api/Room
        public IHttpActionResult Get()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = @"SELECT * FROM Room";
                    SqlCommand sql = new SqlCommand(qury, connection);
                    SqlDataReader execute = sql.ExecuteReader();
                    if (execute.HasRows)
                    {
                        while (execute.Read())
                        {
                          roomsList.Add(new Room(execute.GetInt32(0),execute.GetInt32(1),execute.GetString(2),execute.GetBoolean(3),execute.GetInt32(4)));
                        }
                    }
                    connection.Close();
                    return Ok(new {roomsList});
                }
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
        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    var qury = $@"SELECT * FROM Room WHERE Id={id}";
                    SqlCommand sql = new SqlCommand(qury, connection);
                    SqlDataReader execute = sql.ExecuteReader();
                    if (execute != null)
                    {
                    while (execute.Read())
                    {
                        Room room = new Room(execute.GetInt32(0),execute.GetInt32(1),execute.GetString(2),execute.GetBoolean(3),execute.GetInt32(4));
                        connection.Close();
                        return Ok(new {room});
                    }
                    }
                    connection.Close();
                    return NotFound();    
                }
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
        // POST: api/Room
        public IHttpActionResult Post([FromBody]Room newRoom)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = $@"INSERT INTO Room(NumberRoom,RoomType,IfAvailableRoom,Price)VALUES({newRoom.NumberRoom},'{newRoom.RoomType}','{newRoom.IfAvailableRoom}',{newRoom.Price})";
                    SqlCommand sql = new SqlCommand(qury,connection);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Added successfully");
                }
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
        // PUT: api/Room/5
        public IHttpActionResult Put(int id, [FromBody] Room updateRoom)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = $@"UPDATE Room
                                  SET
                                  NumberRoom ={updateRoom.NumberRoom},
                                  RoomType = '{updateRoom.RoomType}',
                                  IfAvailableRoom ='{updateRoom.IfAvailableRoom}',
                                  Price ={updateRoom.Price}
                                  WHERE Id={id}";
                    SqlCommand sql = new SqlCommand(qury, connection);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Updated successfully");
                }
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
        // DELETE: api/Room/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = $@"DELETE FROM Room WHERE Id={id}";
                    SqlCommand sql = new SqlCommand(qury,connection);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Removed successfully");
                }
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
