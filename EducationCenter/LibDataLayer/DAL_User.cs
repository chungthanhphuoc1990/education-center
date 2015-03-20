using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalUser
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetUser(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_User_Get");
        }
        public static DataTable GetUserLogin(string UserName, string Passwords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("UserName", UserName);
            Cls.AddParameter("Passwords", Passwords);
            return Cls.GetData("sp_User_GetLogin");
        }
        public static DataTable GetUserEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Login_Id", id);
            return Cls.GetData("sp_User_Get_Edit");
        }
        public static DataTable GetUserFillter(int Group_Id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", Group_Id);
            return Cls.GetData("sp_User_GetFillter");
        }
        public static DataTable GetUserFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_User_GetFillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("UserName", obj.UserName);
            Cls.AddParameter("Passwords", obj.Passwords);
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("IsUsed", obj.IsUsed);
            Cls.AddParameter("Lock", obj.Lock);
            Cls.ExecuteNonQuery("sp_User_Insert");
            return true;
        }
        public static bool Update(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Login_Id", obj.Login_Id);
            Cls.AddParameter("UserName", obj.UserName);
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("IsUsed", obj.IsUsed);
            Cls.ExecuteNonQuery("sp_User_Update");
            return true;
        }
        public static bool UpdatePass(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Login_Id", obj.Login_Id);
            Cls.AddParameter("Passwords", obj.Passwords);
            Cls.ExecuteNonQuery("sp_User_UpdatePass");
            return true;
        }
        public static bool Delete(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Login_Id", obj.Login_Id);
            return Cls.ExecuteNonQuery("sp_User_Delete");
        }
        public static bool UpdateCheck(DTOUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Login_Id", obj.Login_Id);
            Cls.AddParameter("IsActive", obj.Lock);
            Cls.ExecuteNonQuery("sp_User_Update_Check");
            return true;
        }
        #endregion
    }
    public class DTOUser
    {
        public int Login_Id { get; set; }
        public string UserName { get; set; }
        public string Passwords { get; set; }
        public int Group_Id { get; set; }
        public int? IsUsed { get; set; }
        public bool Lock { get; set; }
    }
}