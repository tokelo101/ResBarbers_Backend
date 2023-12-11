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
        
    }
}
