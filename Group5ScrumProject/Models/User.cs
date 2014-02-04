using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject
{
    public class User 
    {
        public User(string _sUserName, string _sUserLoginName, int _iUserID, string _sUserPassword, string _sUserRole)
        {
            sUserName = _sUserName;
            iUserID = _iUserID;
            sUserPassWord = _sUserPassword;
            sUserRole = _sUserRole;
            sUserLoginName = _sUserLoginName;
        }

        public int iUserID { get; set; }
        public string  sUserName { get; set; }
        public string  sUserPassWord { get; set; }
        public string sUserRole { get; set; }
        public string sUserLoginName { get; set; }
    }
}