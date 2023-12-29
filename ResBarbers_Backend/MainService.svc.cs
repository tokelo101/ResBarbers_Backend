using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ResBarbers_Backend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MainService.svc or MainService.svc.cs at the Solution Explorer and start debugging.
    
    public class MainService : IMainService
    {
        MainDataClassesDataContext db = new MainDataClassesDataContext();

        public bool RegisterUser(USER_ user)
        {
            //var us = new USER_
            //{
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    UserDOB = user.UserDOB,
            //    Email = user.Email,
            //    Phone = user.Phone,
            //    University = user.University,
            //    Campus = user.Campus,
            //    Province = user.Province,
            //    City = user.City,
            //    ResidenceName = user.ResidenceName,
            //    Addressline1 = user.Addressline1,
            //    Addressline2 = user.Addressline2,
            //    Addressline3 = user.Addressline3,
            //    UserType = user.UserType,

            //    UserPicture = user.UserPicture,
            //    UserName = user.UserName,
            //    About = user.About,
            //    PassPhrase = user.PassPhrase

            //};

            db.USER_s.InsertOnSubmit(user);

            if(user!=null)
            {
                db.SubmitChanges();
                return true;
            }else{
                return false;
            }
        }

        public int Login(string email, string password)
        {
            var user = (from u in db.USER_s where u.Email.Equals(email) && u.PassPhrase.Equals(password) select u).FirstOrDefault();

            if (user != null)
            {
                return user.UserID;
            }
            else
            {
                return 0;
            }

        }

        public string GetUserType(int UserID)
        {
            var user = (from u in db.USER_s where u.UserID.Equals(UserID) select u).FirstOrDefault();

            if (user != null)
            {
                return user.UserType;
            }
            else{
                return null;
            }

        }

        public bool AddHairstyle(MenuItem Hairstyle)
        {
            
            db.MenuItems.InsertOnSubmit(Hairstyle);
            
            if (Hairstyle != null)
            {
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveHairstyle(int StyleID)
        {
            var hairstyle = (from h in db.MenuItems where h.StyleID.Equals(StyleID) select h).FirstOrDefault();
            if (hairstyle != null)
            {
                db.MenuItems.DeleteOnSubmit(hairstyle);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditHairstyle(int StyleID, MenuItem Hairstyle)
        {
            var hairstyle = (from h in db.MenuItems where h.StyleID.Equals(StyleID) select h).FirstOrDefault();

            if (hairstyle != null)
            {

                hairstyle.StyleName = Hairstyle.StyleName;
                hairstyle.StylePrice = Hairstyle.StylePrice;
                hairstyle.StyleDescription = Hairstyle.StyleDescription;
                hairstyle.StyleImage = Hairstyle.StyleImage;

                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public List<MenuItem> GetBarberHairstyles(int BarberID)
        {
            IEnumerable<dynamic> hairstyles = (from m in db.MenuItems where m.BarberID.Equals(BarberID) select m);

            if (!hairstyles.Any())
            {
                return null;
            }
            else
            {
                List<MenuItem> barberhairstyles = new List<MenuItem>();
                foreach (MenuItem h in hairstyles)
                {
                    var newhairstyle = new MenuItem
                    {
                        StyleID = h.StyleID,
                        BarberID = h.BarberID,
                        StyleName = h.StyleName,
                        StyleDescription = h.StyleDescription,
                        StylePrice = h.StylePrice,
                        StyleImage = h.StyleImage
                    };
                    barberhairstyles.Add(newhairstyle);
                }
                return barberhairstyles;
            }
        }

        public MenuItem GetHairstyle(int StyleID)
        {
            var hairstyle = (from m in db.MenuItems where m.StyleID.Equals(StyleID) select m).FirstOrDefault();

            if (hairstyle != null)
            {
                var retrievedHairstyle = new MenuItem
                {
                    StyleName = hairstyle.StyleName,
                    StyleDescription = hairstyle.StyleDescription,
                    StylePrice = hairstyle.StylePrice,
                    StyleImage = hairstyle.StyleImage
                };

                return retrievedHairstyle;
            }
            else
            {
                return null;
            }
        }

        public USER_ GetUser(int UserID)
        {
            var user = (from u in db.USER_s where u.UserID.Equals(UserID) select u).FirstOrDefault();

            if (user != null)
            {
                USER_ returnUser = new USER_
                {
                    UserName = user.UserName,
                    Gender = user.Gender,
                    University = user.University,
                    Campus = user.Campus,
                    About = user.About,
                    UserPicture = user.UserPicture
                };
                return returnUser;
            }
            else
            {
                return null;
            }
        }

        public List<USER_> GetUsers(string UserType)
        {
            IEnumerable<dynamic> users = (from u in db.USER_s where u.UserType.Equals(UserType) select u);

            if (users.Any())
            {
                List<USER_> returnUsers = new List<USER_>();
                foreach(USER_ u in users)
                {
                    USER_ newUser = new USER_
                    {
                        UserID = u.UserID,
                        UserName = u.UserName,
                        Gender = u.Gender,
                        University = u.University,
                        Campus = u.Campus,
                        About = u.About,
                        UserPicture = u.UserPicture
                    };
                    returnUsers.Add(newUser);
                }
                
                return returnUsers;
            }
            else
            {
                return null;
            }
        }

        public List<MenuItem> GetAllHairstyles()
        {
            IEnumerable<dynamic> hairstyles = (from m in db.MenuItems select m);

            if (!hairstyles.Any())
            {
                return null;
            }
            else
            {
                List<MenuItem> barberhairstyles = new List<MenuItem>();
                foreach (MenuItem h in hairstyles)
                {
                    var newhairstyle = new MenuItem
                    {
                        StyleID = h.StyleID,
                        BarberID = h.BarberID,
                        StyleName = h.StyleName,
                        StyleDescription = h.StyleDescription,
                        StylePrice = h.StylePrice,
                        StyleImage = h.StyleImage
                    };
                    barberhairstyles.Add(newhairstyle);
                }
                return barberhairstyles;
            }
        }

        public bool MakeAppointment(Appointment NewAppointment)
        {
            db.Appointments.InsertOnSubmit(NewAppointment);

            if (NewAppointment != null)
            {
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Appointment GetAppointment(int AppointmentID)
        {
            var appointment = (from a in db.Appointments where (a.AppointmentID.Equals(AppointmentID)) select a).FirstOrDefault();
            
            if (appointment != null)
            {
                Appointment newAppointment = new Appointment
                {
                    AppointmentID = appointment.AppointmentID,
                    ClientID = appointment.ClientID,
                    BarberID = appointment.BarberID,
                    StyleID = appointment.StyleID,
                    AppointmentDate = appointment.AppointmentDate,
                    AppointmentTime = appointment.AppointmentTime,
                    AppointmentStatus = appointment.AppointmentStatus
                };
                return newAppointment;
            }
            else
            {
                return null;
            }
        }

        public List<Appointment> GetAppointments(int BarberID, string AppointmentStatus)
        {
            IEnumerable<dynamic> appointments = (from a in db.Appointments where (a.BarberID.Equals(BarberID) && a.AppointmentStatus.Equals(AppointmentStatus)) select a);
            
            if (!appointments.Any())
            {
                return null;
            }
            else
            {
                List<Appointment> retrievedAppointments = new List<Appointment>();
                foreach (Appointment a in appointments)
                {
                    var newAppointment = new Appointment
                    {
                        AppointmentID = a.AppointmentID,
                        ClientID = a.ClientID,
                        BarberID = a.BarberID,
                        StyleID = a.StyleID,
                        AppointmentDate = a.AppointmentDate,
                        AppointmentTime = a.AppointmentTime,
                        AppointmentStatus = a.AppointmentStatus
                    };
                    retrievedAppointments.Add(newAppointment);
                }
                return retrievedAppointments;
            }
        }

        public bool UpdateAppointment(int AppointmentID, string AppointmentStatus)
        {
            var appointment = (from a in db.Appointments where a.AppointmentID.Equals(AppointmentID) select a).FirstOrDefault();

            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus;

                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
