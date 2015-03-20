using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalVideoChild
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetVideoChild(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Video_Child_Get");
        }
        public static DataTable GetVideoChildEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Video", id);
            return Cls.GetData("sp_Video_Child_Get_Edit");
        }
        public static DataTable GetVideoChildFillter(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_Video_Child_GetFillter");
        }
        public static DataTable GetVideoChildFillterStatus(int IsActive,int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_Video_Child_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOVideoChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Video_Titile_Vn", obj.Video_Titile_Vn);
            Cls.AddParameter("Video_Titile_En", obj.Video_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("width", obj.width);
            Cls.AddParameter("height", obj.height);
            Cls.ExecuteNonQuery("sp_Video_Child_Insert");
            return true;
        }
        public static bool Update(DTOVideoChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Video", obj.ID_Video);
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Video_Titile_Vn", obj.Video_Titile_Vn);
            Cls.AddParameter("Video_Titile_En", obj.Video_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("width", obj.width);
            Cls.AddParameter("height", obj.height);
            Cls.ExecuteNonQuery("sp_Video_Child_Update");
            return true;
        }
        public static bool Delete(DTOVideoChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Video", obj.ID_Video);
            Cls.ExecuteNonQuery("sp_Video_Child_Delete");
            return true;
        }
        public static bool UpdateNum(DTOVideoChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Video", obj.ID_Video);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Video_Child_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOVideoChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Video", obj.ID_Video);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Video_Child_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetVideoChildHomePage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Video_Child_Get_HomePage");
        }
        #endregion
    }
    public class DTOVideoChild
    {
        public int ID_Video { get; set; }
        public int? ID_Page { get; set; }
        public string Video_Titile_Vn { get; set; }
        public string Video_Titile_En { get; set; }
        public string Url { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public string Img { get; set; }
        public int Msg { get; set; }
        public int ? width { get; set; }
        public int ? height { get; set; }
    }
}