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
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        static string connectionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        DataClassesDataContext dataContext = new DataClassesDataContext();
        public IHttpActionResult Get()
        {
            try 
            {
                return Ok(new { dataContext.Orders });
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

        // GET: api/Orders/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Order order = dataContext.Orders.First(item => item.Id == id);
                return Ok(new {order});
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

        // POST: api/Orders
        public IHttpActionResult Post([FromBody]Order newOrder)
        {
            try
            {
                dataContext.Orders.InsertOnSubmit(newOrder);
                dataContext.SubmitChanges();
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

        // PUT: api/Orders/5
        public IHttpActionResult Put(int id, [FromBody] Order UpdateOrder)
        {
            try
            {
                Order order = dataContext.Orders.First(item => item.Id == id);
                order.InvitingId = UpdateOrder.InvitingId;
                order.WorkerNumberTakeOrder = UpdateOrder.WorkerNumberTakeOrder;
                order.DateOrder = UpdateOrder.DateOrder;
                order.paidMoney = UpdateOrder.paidMoney;
                order.TotalMoney = UpdateOrder.TotalMoney;
                dataContext.SubmitChanges();
                return Ok("Updated successfully");
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

        // DELETE: api/Orders/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
              Order orderDelete = dataContext.Orders.First(item => item.Id == id);
                dataContext.Orders.DeleteOnSubmit(orderDelete);
                dataContext.SubmitChanges();
                return Ok("Removed successfully");
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
