using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalPage
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetPage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Page_Get");
        }
        public static DataTable GetPageEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", id);
            return Cls.GetData("sp_Page_Get_Edit");
        }
        public static DataTable GetPageFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Page_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Page_Titile_Vn", obj.Page_Titile_Vn);
            Cls.AddParameter("Page_Titile_En", obj.Page_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Page_Insert");
            return true;
        }
        public static bool Update(DTOPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Page_Titile_Vn", obj.Page_Titile_Vn);
            Cls.AddParameter("Page_Titile_En", obj.Page_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Page_Update");
            return true;
        }
        public static bool Delete(DTOPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_Page_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Page_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Page_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetPageHomePage(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_Page_GetHomePage");
        }
        #endregion
    }
    public class DTOPage
    {
        public int ID_Page { get; set; }
        public string Page_Titile_Vn { get; set; }
        public string Page_Titile_En { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public int Msg { get; set; }
    }
}