using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Group5ScrumProject.Models;



namespace Group5ScrumProject.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }

            var allRooms = db.tbRooms;
            ViewBag.Rooms = allRooms;
            ViewBag.User = Session["User"];
            return View();
        }

        public ActionResult Login(string tbxName, string tbxPassword)
        {
            //Om någon försöker komma in till loginsidan när dom är inloggade så loggas dom ut
            if (Session["User"] != null)
            {
                Session.Clear();
                return View();
            }

            //Kollar användarnamn och lösenord mot databasen
            tbUser loggedInUser = (from f in db.tbUsers
                                   where f.sUserLoginName == tbxName && f.sUserPassword == tbxPassword
                                   select f).FirstOrDefault();

            //Om det finns en befintlig användare i databasen
            if (loggedInUser != null)
            {
                Session["User"] = loggedInUser;
                return RedirectToAction("Index");

            }

            //Om användaren inte fyller i alla fält
            if (tbxName != null && tbxPassword != null)
                ViewBag.Message = "Felaktigt användarnamn eller lösenord";
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            ViewBag.User = null;
            return View("index");
        }

        public ActionResult AdminViewSettings()
        {
            return View();
        }

        public ActionResult AdminUserAdd()
        {
            ViewBag.iUserRole = new SelectList(db.tbRoles, "iRoleID", "sRoleType");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminUserAdd(tbUser user)
        {

            if (ModelState.IsValid)
            {
                user.iBlocked = 0;
                user.iActivBooking = 0;

                db.tbUsers.InsertOnSubmit(user);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult AdminUserEdit()
        {
            return View();
        }

        public ActionResult AdminUserDelete()
        {


            return View();
        }

        public ActionResult AdminUserBlock()
        {
            return View();
        }

        public ActionResult AdminRoomAdd()
        {
            return View();
        }

        public ActionResult AdminRoomEdit()
        {
            return View();
        }

        public ActionResult AdminRoomDelete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminBookingAdd()
        {
            IEnumerable<SelectListItem> rooms = db.tbRooms.Select(x => new SelectListItem { Text = x.sRoomName, Value = x.iRoomId.ToString() });

            List<SelectListItem> hours = new List<SelectListItem> 
            { 
            new SelectListItem { Text = "09:00", Value = "09:00" }, 
            new SelectListItem { Text = "10:00", Value = "10:00" }, 
            new SelectListItem { Text = "11:00", Value = "11:00" } ,
            new SelectListItem { Text = "12:00", Value = "12:00" } ,
            new SelectListItem { Text = "13:00", Value = "13:00" } ,
            new SelectListItem { Text = "14:00", Value = "14:00" } ,
            new SelectListItem { Text = "15:00", Value = "15:00" } ,
            new SelectListItem { Text = "16:00", Value = "16:00" } 
            };

            ViewBag.ddlRooms = rooms;
            ViewBag.ddlTimeStart = (IEnumerable<SelectListItem>)hours;
            ViewBag.ddlTimeEnd = (IEnumerable<SelectListItem>)hours;

            return View();
        }
        [HttpPost]
        public ActionResult AdminBookingAdd(string ddlRooms, string day, TimeSpan ddlTimeStart, TimeSpan ddlTimeEnd)
        {
            //Lägg in validation så att timestart inte är större än timeend och tvärtom

            tbUser u = (tbUser)Session["User"];

            tbBooking newBooking = new tbBooking
            {
                iUserId = u.iUserId,
                iRumId = int.Parse(ddlRooms),
                dtDateDay = Convert.ToDateTime(day),
                dtTimeStart = ddlTimeStart,
                dtTimeEnd = ddlTimeEnd
            };

            var existingBooking = db.tbBookings
                .Where(b => b.iRumId == int.Parse(ddlRooms) && b.dtDateDay == newBooking.dtDateDay);

            if (existingBooking != null)
            {
                foreach (var b in existingBooking)
                {
                    //Kollar om det finns en bokning som startar samtidigt/senare och slutar samtidigt/tidigare än den nya bokningens starttid
                    //eller ..ööö  Fortsätter kommentera imorgon //Hannah

                    //Tar bort befintlig bokning
                    if ((newBooking.dtTimeStart >= b.dtTimeStart && newBooking.dtTimeStart < b.dtTimeEnd) ||
                        (newBooking.dtTimeEnd > b.dtTimeStart && newBooking.dtTimeEnd <= b.dtTimeEnd))
                    {
                        db.tbBookings.DeleteOnSubmit(b);
                    }
                }
            }
            //Lägger in ny bokning
            db.tbBookings.InsertOnSubmit(newBooking);
            db.SubmitChanges();

            return View("AdminViewSettings");
        }

        public ActionResult AdminBookingEdit()
        {
            return View();
        }

        public ActionResult AdminBookingDelete()
        {
            return View();
        }
    }
}
