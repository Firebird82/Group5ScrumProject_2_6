using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Group5ScrumProject
{
    public class User
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public User(tbUser _user)
        {
            sUserName = _user.sUserName;
            iUserID = _user.iUserId;
            sUserPassWord = _user.sUserPassword;
            iUserRole = _user.iUserRole.Value;
            sUserLoginName = _user.sUserLoginName;
            sUserRole = db.tbRoles
                .Where(r => r.iRoleID == iUserRole)
                .FirstOrDefault().sRoleType;
        }

        public int iUserID { get; set; }
        public string sUserName { get; set; }
        public string sUserPassWord { get; set; }
        public int iUserRole { get; set; }
        public string sUserRole { get; set; }
        public string sUserLoginName { get; set; }
    }
}