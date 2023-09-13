using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models;
using HotelBookingAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HotelBookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.HotelBookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.HotelBookings.Find(booking.Id);
                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.HotelBookings.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.HotelBookings.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

            _context.HotelBookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.HotelBookings.ToList();

            return new JsonResult(Ok(result));
        }

        // SqlClient
        //private readonly IConfiguration _configuration;

        //public HotelBookingDBController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //// Get all
        //[HttpGet]
        //public JsonResult SqlClientGetAll()
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("dbTestConnection").ToString());
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HotelBookings", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<HotelBooking> hotelBookingsList = new List<HotelBooking>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        HotelBooking hotelBooking = new HotelBooking();
        //        hotelBooking.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
        //        hotelBooking.RoomNumber = Convert.ToInt32(dt.Rows[i]["RoomNumber"]);
        //        hotelBooking.ClientName = Convert.ToString(dt.Rows[i]["ClientName"]);
        //        hotelBookingsList.Add(hotelBooking);
        //    }
        //    if (hotelBookingsList.Count > 0)
        //    {
        //        return new JsonResult(Ok(JsonSerializer.Serialize(hotelBookingsList)));
        //    } else
        //    {
        //        return new JsonResult(NoContent());
        //    }
        //}
    }
}

