using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Group5ScrumProject.Models;
using Group5ScrumProject;
using System.IO;


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

            if (Session["bookingConfirmed"] == null || (string)Session["bookingConfirmed"] == "")
            {
                ViewBag.BookingMessage = "";
            }
            else
            {
                ViewBag.BookingMessage = "Bokning genomförd";
                Session["bookingConfirmed"] = "";
            }

            return View();
        }
        [HttpPost]
        public ActionResult AdminBookingAdd(string ddlRooms, DateTime day, TimeSpan ddlTimeStart, TimeSpan ddlTimeEnd, bool recurrent)
        {
            if (recurrent == true)
            {
                //Lägger till en bokning med detta datum 3 månader fram i tiden
                AddBookingMethod(ddlRooms, day, ddlTimeStart, ddlTimeEnd);
                AddBookingMethod(ddlRooms, day.AddMonths(1), ddlTimeStart, ddlTimeEnd);
                AddBookingMethod(ddlRooms, day.AddMonths(2), ddlTimeStart, ddlTimeEnd);
                AddBookingMethod(ddlRooms, day.AddMonths(3), ddlTimeStart, ddlTimeEnd);
            }
            else
            {
                //Lägger endast till en bokning
                AddBookingMethod(ddlRooms, day, ddlTimeStart, ddlTimeEnd);
            }

            Session["bookingConfirmed"] = "Bokning genomförd";
            return RedirectToAction("AdminBookingAdd");
        }

        //METOD FÖR ATT LÄGGA TILL BOKNING
        public void AddBookingMethod(string ddlRooms, DateTime day, TimeSpan ddlTimeStart, TimeSpan ddlTimeEnd)
        {
            //Lägg in validation så att timestart inte är större än timeend och tvärtom

            tbUser u = (tbUser)Session["User"];

            tbBooking newBooking = new tbBooking
            {
                iUserId = u.iUserId,
                iRumId = int.Parse(ddlRooms),
                dtDateDay = day,
                dtTimeStart = ddlTimeStart,
                dtTimeEnd = ddlTimeEnd
            };

            //Kollar om det finns en bokning på samma dag och i samma rum som den nya bokningen
            var existingBooking = db.tbBookings
                .Where(b => b.iRumId == int.Parse(ddlRooms) && b.dtDateDay == newBooking.dtDateDay);

            if (existingBooking != null)
            {
                foreach (var b in existingBooking)
                {
                    //Kollar om det finns en bokning som startar samtidigt/tidigare och slutar tidigare än den nya bokningens starttid
                    //eller om det finns en bokning som börjar tidigare och slutar samtidigt samtidigt/senare än den nya bokningens sluttid                    
                    if ((newBooking.dtTimeStart >= b.dtTimeStart && newBooking.dtTimeStart < b.dtTimeEnd) ||
                        (newBooking.dtTimeEnd > b.dtTimeStart && newBooking.dtTimeEnd <= b.dtTimeEnd))
                    {
                        //Tar bort befintlig bokning
                        db.tbBookings.DeleteOnSubmit(b);
                    }
                }
            }
            //Lägger in ny bokning
            db.tbBookings.InsertOnSubmit(newBooking);
            db.SubmitChanges();
        }

        public ActionResult AdminBookingEdit()
        {
            return View();
        }

        public ActionResult AdminBookingDelete()
        {
            return View();
        }

        public ActionResult UploadFile(string Submit) //David
        {
            // Loopen is only used onces but will be good later when we can upload multiple files
            foreach (string upload in Request.Files)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";       //Sets a path to save the uploaded file to a directory on the server
                string filename = Path.GetFileName(Request.Files[upload].FileName);     //Gets the name of the uploaded file
                Request.Files[upload].SaveAs(Path.Combine(path, filename));             //Saves the uploaded file to path folder

                System.Text.Encoding enc = System.Text.Encoding.Default;                //Sets the Encoding of the file to make special characters like åäö "possible"
                StreamReader sr = new StreamReader(path + filename, enc);               //Instanciates a streamReader that wil read the file line by line

                string strline = "";                                //Will store each line found in the file
                string[] _values = null;                            //Will store each entry that is "," separated in the list
                while (!sr.EndOfStream)                             //While we have more lines in the file we will keep going troung the next line untill there are no more lines in the file
                {
                    strline = sr.ReadLine();                        //Gets the first line in the file with StreamReader
                    _values = strline.Split(',');                   //Separates the line on "," in to a list

                    tbUser user = new tbUser();                     //A tbUser database object is created to store what we have in the file 
                    {
                        user.sUserName = _values[0];                //Name is the first entry in the file on each line
                        user.sUserLoginName = _values[1];           //Login name is in second place in the file
                        user.sUserPassword = _values[2];            //Password in 3rd place
                        user.iUserRole = 1;                         //Standard value to make all added users "User" in the database
                        user.iBlocked = 0;                          //Standard value so that the user is not blocked from start
                        user.iActivBooking = 0;                     //Standard value that the user dont have any bookings to start with
                        user.sClass = _values[3];                   //4th place in the file is info about what class the user goes in
                    };

                    db.tbUsers.InsertOnSubmit(user);                //Save to database
                    db.SubmitChanges();                             //Save to database
                }
                sr.Close();                                         //Close StreamReader
            }

            return View();
        }
    }
}
