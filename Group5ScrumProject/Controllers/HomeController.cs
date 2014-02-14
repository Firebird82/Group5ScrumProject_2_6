using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Group5ScrumProject.Models;
using Group5ScrumProject;
using System.IO;


namespace Group5ScrumProject.Controllers
{//
    public class HomeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index(DateTime? day, int ddlChairs = 0, string ddlRooms = "")
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }

            ViewBag.User = Session["User"];
            ViewBag.ddlRooms = new SelectList(db.tbRooms.OrderBy(c => c.sRoomName), "sRoomName", "sRoomName");
            ViewBag.ddlChairs = new SelectList(db.tbRooms.OrderBy(c => c.iRoomChairs), "iRoomChairs", "iRoomChairs");

            if (day == null)
            {
                ViewBag.Date = DateTime.Now;
                ViewBag.StringDate = DateTime.Today.ToString("yyyy/MM/dd");
            }
            else
            {
                ViewBag.Date = day;
                string stringDay = day.ToString();
                stringDay = stringDay.Remove(stringDay.Length - 8);
                ViewBag.StringDate = stringDay;
            }

            ViewBag.nrOfRows = 5;
            ViewBag.Rooms = getRooms();

            if (ddlRooms != "" || ddlChairs != 0)
            {
                List<Room> rooms = (from f in db.tbRooms
                                    where f.sRoomName == ddlRooms || f.iRoomChairs == ddlChairs

                                    select new Room(f)).ToList();

                ViewBag.Rooms = rooms;
                return View("Index", getRooms());
            }
            return View("Index", getRooms());
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
            ViewBag.iUserRole = new SelectList(db.tbRoles, "iRoleID", "sRoleType");
            try
            {
                if (ModelState.IsValid)
                {
                    user.iBlocked = 0;

                    db.tbUsers.InsertOnSubmit(user);
                    db.SubmitChanges();

                    ViewBag.Message = "Du har lagt till " + user.sUserName;
                    ViewBag.iUserRole = new SelectList(db.tbRoles, "iRoleID", "sRoleType");
                    ModelState.Clear();
                    return View("AdminUserAdd");
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Va en goding och fyll i alla fält";
                return View();
            }

            return View(user);
        }

        public List<tbUser> Searching = new List<tbUser>();
        public ActionResult AdminUserEdit(string searchTerm = null)
        {
            {
                Searching = (from m in db.tbUsers
                             where
                                 m.sUserLoginName.Contains(searchTerm) || m.sUserName.Contains(searchTerm)
                                 || searchTerm == null
                             orderby m.sUserName
                             select m).ToList();

                if (Request.IsAjaxRequest())
                {

                    return PartialView("_UsersEdit", Searching);
                }
            }

            return View("AdminUserEdit", Searching);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var v = (from m in db.tbUsers
                     where m.iUserId == id
                     select m).FirstOrDefault();

            return View("Edit", v);
        }

        [HttpPost]
        public ActionResult Edit(tbUser users, int id)
        {
            var v = (from m in db.tbUsers
                     where m.iUserId == id
                     select m).FirstOrDefault();

            if (users.sUserName != null && users.sUserLoginName != null && users.sUserPassword != null)
            {
                var user = (from m in db.tbUsers
                            where m.iUserId == users.iUserId
                            select m).FirstOrDefault();

                user.sUserName = users.sUserName;
                user.sUserLoginName = users.sUserLoginName;
                user.sUserPassword = users.sUserPassword;
                user.sClass = users.sClass;
                user.Email = users.Email;
                user.iBlocked = users.iBlocked;

                db.SubmitChanges();


                ViewBag.Message = "Dina ändringar är sparade";
                return View("Edit", v);
            }

            ViewBag.Message = "Vissa fält är tomma och måste fyllas i";
            return View("Edit", v);
        }

        [HttpGet]
        public ActionResult AdminUserDelete()
        {
            try
            {
                var UserDel = db.tbUsers;
                ViewBag.UserDel = UserDel;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Klicka på den användare du vill ta bort";
                return View();
            }

        }

        [HttpPost]
        public ActionResult AdminUserDelete(int id)
        {
            try
            {
                var User2Delete = (from f in db.tbUsers
                                   where f.iUserId == id
                                   select f).FirstOrDefault();

                db.tbUsers.DeleteOnSubmit(User2Delete);
                db.SubmitChanges();

                ViewBag.Message = "Du har tagit bort " + User2Delete.sUserName;
            }
            catch
            {
                return View("AdminViewSettings");
            }

            var UserDel = db.tbUsers;
            ViewBag.UserDel = UserDel;

            return View("AdminUserDelete");
        }

        public ActionResult CheckIn(int id)
        {
            var a = db.tbBookings.Where(b => b.iBookingID == id).FirstOrDefault();

            a.iCheckIn = 1;
            db.SubmitChanges();

            return RedirectToAction("UserBookings");
        }


        public ActionResult AdminUserBlock()
        {
            return View();
        }

        private List<Room> getRooms()
        {
            List<Room> rooms = new List<Room>();
            db.tbRooms.ToList().ForEach(room => { rooms.Add(new Room(room)); });

            //rooms = (from f in db.tbRooms
            //         select new Room(f)).ToList();

            return rooms;
        }
        public ActionResult AdminRoomAdd(string Namn, string Chairs, string Rumsbeskrivning)
        {
            bool status = false; // Meddelande indikator
            List<Room> rooms = getRooms();
            if (Namn != null)
            {
                if (Namn == "")
                {
                    @ViewBag.status = "Du måste ange ett rumsnamn.";
                    status = true;
                }
                if (Chairs == null || Chairs == "")
                {
                    Chairs = "0";
                }
                if (Rumsbeskrivning == null || Rumsbeskrivning == "")
                {
                    Rumsbeskrivning = "";
                }
                if (!status)
                    foreach (var room in db.tbRooms)
                        if (room.sRoomName.ToLower() == Namn.ToLower())
                        {
                            status = true;
                            @ViewBag.status = "Rummet finns redan, Välj ett annat namn.";
                        }
                if (!status)
                {
                    tbRoom room = new tbRoom
                    {
                        sRoomName = Namn,
                        iRoomChairs = isInt(Chairs),
                        sRoomDesc = Rumsbeskrivning
                    };

                    db.tbRooms.InsertOnSubmit(room);
                    db.SubmitChanges();
                    @ViewBag.status = "Rummet är skapat!";
                    status = true;
                    // Uppdatera det nya rummet i listan för att visa användare.
                    rooms = getRooms();
                }
            }
            ViewBag.nrOfRows = db.tbRooms.Count(); // Skickar med antal rader till webgrid
            ViewBag.message = status; // Säg till userland :) om vi har meddelande till användaren.
            return View("AdminRoomAdd", rooms);
        }

        public ActionResult AdminRoomEdit()
        {
            ViewBag.nrOfRows = db.tbRooms.Count(); // Skickar med antal rader till webgrid
            ViewBag.message = false;
            return View("AdminRoomEdit", getRooms());
        }

        // Tvingar returvärdet från en sträng till intvärdet 0 ifall strängen inte är en int
        private int isInt(string s)
        {
            int ret;
            if (int.TryParse(s, out ret))
                return ret;
            return 0;
        }
        public ActionResult AdminRoomEditUpdate(string id, string RoomName, string Chairs, string RoomDescription)
        {
            bool status = false; // Meddelande indikator
            ViewBag.nrOfRows = db.tbRooms.Count(); // Skickar med antal rader till webgrid
            if (RoomName != null)
            {
                // felhantering
                if (RoomName == "")
                {
                    status = true;
                    @ViewBag.status = "Du måste ange ett rumsnamn.";
                }
                if (!status)
                    foreach (var room in db.tbRooms)
                        if (room.sRoomName.ToLower() == RoomName.ToLower() && room.iRoomId != int.Parse(id))
                        {
                            status = true;
                            @ViewBag.status = "Rummet finns redan, Välj ett annat namn.";
                        }
                if (!status)
                {
                    Chairs = (String.IsNullOrEmpty(Chairs) ? "0" : Chairs);
                    RoomDescription = (String.IsNullOrEmpty(RoomDescription) ? "" : RoomDescription);

                    var rum = db.tbRooms.Where(r => r.iRoomId == int.Parse(id)).FirstOrDefault();
                    rum.sRoomName = RoomName;
                    rum.iRoomChairs = isInt(Chairs);
                    rum.sRoomDesc = RoomDescription;
                    db.SubmitChanges();
                }
            }
            ViewBag.message = status; // Säg till frontend om vi har meddelande till användaren.
            return View("AdminRoomEdit", getRooms());
        }

        [HttpGet]
        public ActionResult AdminRoomDelete()
        {
            try
            {
                var DeleteRooms = db.tbRooms;
                ViewBag.Rooms = DeleteRooms;
                ViewBag.User = Session["User"];

                return View();
            }
            catch (Exception)
            {
                return View("AdminViewSettings");
            }
        }

        [HttpPost]
        public ActionResult AdminRoomDelete(int id)
        {
            var DeleteRooms = db.tbRooms;
            ViewBag.Rooms = DeleteRooms;
            ViewBag.User = Session["User"];

            try
            {
                var Room2Delete = (from f in db.tbRooms
                                   where f.iRoomId == id
                                   select f).FirstOrDefault();

                db.tbRooms.DeleteOnSubmit(Room2Delete);
                db.SubmitChanges();

                ViewBag.Message = "Rum " + Room2Delete.sRoomName + " är borttaget";
                return View();
            }
            catch
            {
                ViewBag.Message = "Oj oj.... Något har gått fel :(";
                return View();
            }
        }

        [HttpGet]
        public ActionResult AdminBookingAdd(string time = "", string date = "", string roomId = "")
        {
            //Skriver ut alla rum
            IEnumerable<SelectListItem> rooms = db.tbRooms.Select(x => new SelectListItem { Text = x.sRoomName, Value = x.iRoomId.ToString() });

            //Skriver ut en lista med tider
            IEnumerable<SelectListItem> hours = new List<SelectListItem> 
                { 
                    new SelectListItem { Text = "09:00", Value = "09:00" },
                    new SelectListItem { Text = "10:00", Value = "10:00" },
                    new SelectListItem { Text = "11:00", Value = "11:00" },
                    new SelectListItem { Text = "12:00", Value = "12:00" },
                    new SelectListItem { Text = "13:00", Value = "13:00" },
                    new SelectListItem { Text = "14:00", Value = "14:00" },
                    new SelectListItem { Text = "15:00", Value = "15:00" },
                    new SelectListItem { Text = "16:00", Value = "16:00" } 
                };

            //Skriver ut endast det valda rummet. Inga tider innan vald tid visas
            if (roomId != "" && time != "" && date != "")
            {
                rooms = rooms.Where(r => r.Value == roomId);
                hours = hours.Where(h => Convert.ToDateTime(h.Value) >= Convert.ToDateTime(time));
                ViewBag.Date = date;
            }
            else
            {
                ViewBag.Date = DateTime.Today.ToString("yyyy/MM/dd");
            }

            if (Session["bookingConfirmed"] == null || (string)Session["bookingConfirmed"] == "")
            {

                ModelState.AddModelError(string.Empty, (string)Session["ErrorMessage"]);
                Session["ErrorMessage"] = "";
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Bokning genomförd");
                Session["bookingConfirmed"] = "";
                Session["ErrorMessage"] = "";
            }

            tbUser u = (tbUser)Session["User"];
            ViewBag.userRole = u.iUserRole;

            ViewBag.ddlRooms = rooms;
            ViewBag.ddlTimeStart = (IEnumerable<SelectListItem>)hours;
            ViewBag.ddlTimeEnd = (IEnumerable<SelectListItem>)hours;

            return View();
        }
        [HttpPost]
        public ActionResult AdminBookingAdd(string ddlRooms, DateTime day, TimeSpan ddlTimeStart, TimeSpan ddlTimeEnd, bool recurrent = false)
        {
            tbUser u = (tbUser)Session["User"];

            if (u.iUserRole == 2 && db.tbBookings.Where(b => b.iUserId == u.iUserId)
                                    .Where(b => b.dtDateDay.DayOfYear >= DateTime.Today.DayOfYear)
                                    .FirstOrDefault() != null) //Om användaren har en befintlig bokning
            {
                Session["ErrorMessage"] = "Du har redan en aktiv bokning.";
            }
            else if (u.iUserRole == 2 && ((ddlTimeEnd.Hours - ddlTimeStart.Hours) > 4)) //Om en användare försöker boka mer än 4 timmar
            {
                Session["ErrorMessage"] = "Du kan endast boka 4 timmar åt gången.";
            }
            else if (u.iUserRole == 2 && (day.DayOfYear - DateTime.Today.DayOfYear) > 7) //Om användaren försöker boka en tid längre fram i tiden än 7 dagar
            {
                Session["ErrorMessage"] = "Du kan endast boka en vecka fram i tiden.";
            }

            else if (ddlTimeStart.Hours == ddlTimeEnd.Hours)
            {
                Session["ErrorMessage"] = "Starttid och sluttid kan ej vara samma tid.";
            }
            else if (ddlTimeStart.Hours > ddlTimeEnd.Hours)
            {
                Session["ErrorMessage"] = "Sluttid kan inte inträffa innan starttid.";
            }
            else if (day.DayOfYear < DateTime.Today.DayOfYear)  //Om användaren försöker boka bakåt i tiden
            {
                Session["ErrorMessage"] = "Du kan endast boka tider framåt i tiden.";
            }
            else  //Bokning genomförs
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
            }
            return RedirectToAction("AdminBookingAdd");
        }

        //METOD FÖR ATT LÄGGA TILL BOKNING
        public void AddBookingMethod(string ddlRooms, DateTime day, TimeSpan ddlTimeStart, TimeSpan ddlTimeEnd)
        {
            tbUser u = (tbUser)Session["User"];

            if (Session["User"] == null)
            {
                RedirectToAction("Login");
            }

            tbBooking newBooking = new tbBooking
            {
                iUserId = u.iUserId,
                iRumId = int.Parse(ddlRooms),
                dtDateDay = day,
                dtTimeStart = ddlTimeStart,
                dtTimeEnd = ddlTimeEnd,
                iCheckIn = 0
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

            //Skickar mail till användaren med bokningsbekräftelse
            SendMessage(u.iUserId, "Bokningsbekräftelse", "Hej " + u.sUserName + ". \n Du har bokat projektrum " + newBooking.iRumId + ". \nDatum: " + newBooking.dtDateDay.ToString("yyyy/MM/dd") + ".\n Starttid: " + newBooking.dtTimeStart.ToString("hh\\:mm")
                  + ". \nSluttid: " + newBooking.dtTimeEnd.ToString("hh\\:mm") + ". \nGlöm inte att checka in senast 2 timmar innan bokningen startar.");
            Session["bookingConfirmed"] = "Bokning genomförd";
        }

        //Metod som skickar bokningsbekräftelse till användaren
        public void SendMessage(int id, string subject, string messageBody)
        {
            tbUser u = db.tbUsers.Where(x => x.iUserId == id)
                .FirstOrDefault();
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(u.Email);
                message.Subject = subject;
                message.From = new System.Net.Mail.MailAddress("teknikhogskolangroup5@gmail.com");
                message.Body = messageBody;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("teknikhogskolangroup5", "losenordgrupp5");

                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            catch
            {
                return;
            }

        }

        public ActionResult AdminBookingEdit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminBookingDelete()
        {
            try
            {
                List<Booking> bookings = db.tbBookings.Select(f => new Booking(f)).ToList();

                return View(bookings);
            }
            catch
            {
                return View("AdminViewSettings");
            }
        }

        [HttpPost]
        public ActionResult AdminBookingDelete(int id)
        {
            var bookingsAll = db.tbBookings;
            ViewBag.Bookings = bookingsAll;

            try
            {
                var bookings = db.tbBookings
                    .Where(b => b.iBookingID == id)
                    .FirstOrDefault();

                tbUser u = db.tbUsers.Where(x => x.iUserId == bookings.iUserId).FirstOrDefault();

                SendMessage(u.iUserId, "Bokning borttagen", "Hej " + u.sUserName + ". \nDin bokning har blivit borttagen. Kontakta administratören.");

                db.tbBookings.DeleteOnSubmit(bookings);
                db.SubmitChanges();

                return View("AdminViewSettings");

            }
            catch (Exception)
            {
                return View("AdminBookingDelete");
            }
        }
        [HttpGet]
        public ActionResult UserBookings()//Björn
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }


            tbUser u = (tbUser)Session["User"];

            ViewBag.Bokningar = (from f in db.tbBookings
                                 where f.iUserId == u.iUserId
                                 select f).ToList();

            var användare = (from f in db.tbUsers
                             where f.iUserId == u.iUserId
                             select f).FirstOrDefault();



            return View("UserBookings", new User(användare));
        }

        [HttpPost]
        public ActionResult UserBookings(string id)
        {
            tbUser u = (tbUser)Session["User"];

            var bookingsAll = (from f in db.tbBookings
                               where f.iUserId == u.iUserId
                               select f).ToList();
            ViewBag.Bokningar = bookingsAll;

            try
            {



                var användare = (from f in db.tbUsers
                                 where f.iUserId == u.iUserId
                                 select f).FirstOrDefault();

                var bookings = db.tbBookings
                    .Where(b => b.iBookingID == int.Parse(id))
                    .FirstOrDefault();

                db.tbBookings.DeleteOnSubmit(bookings);
                db.SubmitChanges();
                return View("UserBookings", new User(användare));


            }
            catch (Exception)
            {
                tbUser g = (tbUser)Session["User"];

                var användare = (from f in db.tbUsers
                                 where f.iUserId == g.iUserId
                                 select f).FirstOrDefault();

                return View("UserBookings", new User(användare));
            }
        }

        public ActionResult UploadFile(string Submit)
        {
            int loops = 0;

            try
            {
                foreach (string upload in Request.Files)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";       //Sets a path to save the uploaded file to a directory on the server
                    string filename = Path.GetFileName(Request.Files[upload].FileName);     //Gets the name of the uploaded file
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));             //Saves the uploaded file to path folder

                    System.Text.Encoding enc = System.Text.Encoding.Default;                //Sets the Encoding of the file to make special characters like åäö "possible"
                    StreamReader sr = new StreamReader(path + filename, enc);               //Instanciates a streamReader that wil read the file line by line

                    string strline = "";                                //Will store each line found in the file
                    string[] _values = null;                            //Will store each entry that is "," separated in the list

                    while (!sr.EndOfStream)                            //While we have more lines in the file we will keep going troung the next line untill there are no more lines in the file
                    {
                        loops = loops + 1;
                        strline = sr.ReadLine();                        //Gets the first line in the file with StreamReader
                        _values = strline.Split(',');                   //Separates the line on "," in to a list

                        tbUser user = new tbUser();                     //A tbUser database object is created to store what we have in the file 
                        {
                            user.sUserName = _values[0];                //Name is the first entry in the file on each line
                            user.sUserLoginName = _values[1];           //Login name is in second place in the file
                            user.sUserPassword = _values[2];            //Password in 3rd place
                            user.iUserRole = 2;                         //Standard value to make all added users "User" in the database
                            user.iBlocked = 0;                          //Standard value so that the user is not blocked from start
                            user.Email = _values[3];                    //4th place in the file is mail info
                            user.sClass = _values[4];                   //5th place in the file is info about what class the user goes in
                        };

                        db.tbUsers.InsertOnSubmit(user);                //Save to database
                        db.SubmitChanges();                             //Save to database
                    }
                    sr.Close();                                         //Close StreamReader
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Du har laddat upp en fil som inte funkar :(";

                return View();
            }

            // Loopen is only used onces but will be good later when we can upload multiple files
            if (loops != 0)
            {
                ViewBag.Message = "Du har lagt till " + loops + " personer";
            }
            return View();
        }

        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(int id, string subject, string messageToUser)
        {
            SendMessage(id, subject, messageToUser);

            return RedirectToAction("AdminUserEdit");
        }

        public ActionResult AdminBookingHistories()
        {
            return View("AdminBookingHistories");
        }

        public ActionResult _AdminBookingHistoriesddl()
        {
            var users = new SelectList(db.tbUsers, "iUserId", "sUserName").ToList();
            users.Insert(0, new SelectListItem());
            users[0].Value = "0";
            users[0].Text = "Användare";
            ViewBag.users = users;
            ViewBag.nrOfRows = db.tbRooms.Count(); // Skickar med antal rader till webgrid
            return View("_AdminBookingHistoriesddl");
        }

        public ActionResult _AdminBookingHistoriesWebGrid(string id)
        {
            List<BookingHistory> history =
                db.tbBookings.Where(c => c.iUserId == int.Parse(id)).Select(x => new BookingHistory(x)).ToList();

            if (history.Count <= 0)
                return View("AdminBookingHistoriesNoResult");
            ViewBag.nrOfRows = history.Count; // Skickar med antal rader till webgrid
            return View("_AdminBookingHistoriesWebGrid", history);
        }
    }
}
