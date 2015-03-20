using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllUser
    {
        #region[Get-Data]
        public DataTable GetUser(string keywords)
        {
            return DalUser.GetUser(keywords);
        }
        public DataTable GetUserLogin(string UserName, string Passwords)
        {
            return DalUser.GetUserLogin(UserName, Passwords);
        }
        public DataTable GetUserEdit(int id)
        {
            return DalUser.GetUserEdit(id);
        }
        public DataTable GetUserFillter(int Group_Id)
        {
            return DalUser.GetUserFillter(Group_Id);
        }
        public DataTable GetUserFillterStatus(int IsActive)
        {
            return DalUser.GetUserFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUser obj)
        {
            DalUser.Insert(obj);
            return true;
        }
        public static bool Update(DTOUser obj)
        {
            DalUser.Update(obj);
            return true;
        }
        public static bool UpdatePass(DTOUser obj)
        {
            DalUser.UpdatePass(obj);
            return true;
        }
        public static bool Delete(DTOUser obj)
        {
            DalUser.Delete(obj);
            return true;
        }
        public static bool UpdateCheck(DTOUser obj)
        {
            DalUser.UpdateCheck(obj);
            return true;
        }
        #endregion
    }
}