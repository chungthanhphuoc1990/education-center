using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalNotify
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetNotify(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Notify_Get");
        }
        public static DataTable GetNotifyEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", id);
            return Cls.GetData("sp_Notify_Get_Edit");
        }
        public static DataTable GetNotifyFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Notify_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONotify obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Notify_Titile_Vn", obj.Notify_Titile_Vn);
            Cls.AddParameter("Notify_Titile_En", obj.Notify_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("Users_ID", obj.Users_ID);
            Cls.ExecuteNonQuery("sp_Notify_Insert");
            return true;
        }
        public static bool Update(DTONotify obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Notify_Titile_Vn", obj.Notify_Titile_Vn);
            Cls.AddParameter("Notify_Titile_En", obj.Notify_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Notify_Update");
            return true;
        }
        public static bool Delete(DTONotify obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_Notify_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTONotify obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Notify_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTONotify obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Notify_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetNotifyHomePage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Notify_Get_HomePage");
        }
        #endregion
    }

    public class DTONotify
    {
        public int ID_Notify { get; set; }
        public string Url { get; set; }
        public string Notify_Titile_Vn { get; set; }
        public string Notify_Titile_En { get; set; }
        public string Img { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public int Msg { get; set; }
        public int Users_ID { get; set; }
    }
}