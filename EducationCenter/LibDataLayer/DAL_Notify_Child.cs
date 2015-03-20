using System;
using System.Data;
using LibDBConnect;


namespace LibDataLayer
{
    public static class DalNotifyChild
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetNotifyChild(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_NotifyChild_Get");
        }
        public static DataTable GetNotifyChildEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", id);
            return Cls.GetData("sp_NotifyChild_Get_Edit");
        }
        public static DataTable GetNotifyChildFillter(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_NotifyChild_GetFillter");
        }
        public static DataTable GetNotifyChildFillterStatus(int IsActive,int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_NotifyChild_Get_Fillter_Status");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONotifyChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Notify_Titile_Vn", obj.Notify_Titile_Vn);
            Cls.AddParameter("Notify_Titile_En", obj.Notify_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("ShortContent_Vn", obj.ShortContent_Vn);
            Cls.AddParameter("ShortContent_En", obj.ShortContent_En);
            Cls.AddParameter("Descriptions_Vn", obj.Descriptions_Vn);
            Cls.AddParameter("Descriptions_En", obj.Descriptions_En);
            Cls.AddParameter("Keywords_Titile", obj.Keywords_Titile);
            Cls.AddParameter("Keywords_ShortContent", obj.Keywords_ShortContent);
            Cls.AddParameter("Keywords_Descriptions", obj.Keywords_Descriptions);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            Cls.AddParameter("DateEnd", obj.DateEnd);
            Cls.ExecuteNonQuery("sp_NotifyChild_Insert");
            return true;
        }
        public static bool Update(DTONotifyChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Notify_Titile_Vn", obj.Notify_Titile_Vn);
            Cls.AddParameter("Notify_Titile_En", obj.Notify_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("ShortContent_Vn", obj.ShortContent_Vn);
            Cls.AddParameter("ShortContent_En", obj.ShortContent_En);
            Cls.AddParameter("Descriptions_Vn", obj.Descriptions_Vn);
            Cls.AddParameter("Descriptions_En", obj.Descriptions_En);
            Cls.AddParameter("Keywords_Titile", obj.Keywords_Titile);
            Cls.AddParameter("Keywords_ShortContent", obj.Keywords_ShortContent);
            Cls.AddParameter("Keywords_Descriptions", obj.Keywords_Descriptions);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            Cls.AddParameter("DateEnd", obj.DateEnd);
            Cls.ExecuteNonQuery("sp_NotifyChild_Update");
            return true;
        }
        public static bool Delete(DTONotifyChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.ExecuteNonQuery("sp_NotifyChild_Delete");
            return true;
        }
        public static bool UpdateNum(DTONotifyChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Notify_Child_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTONotifyChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Notify", obj.ID_Notify);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Notify_Child_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetNotifyChildHomePage(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_NotifyChild_Get_HomePage");
        }
        public static DataTable GetNotifyChildHomePageDetail(int ID_Page,string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_NotifyChild_Get_HomePageDetail");
        }
        public static DataTable GetNotifyChildHomePageOrder(int ID_Page, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("Friendly_Url", Friendly_Url);
            return Cls.GetData("sp_NotifyChild_Get_HomePageOrder");
        }
        #endregion
    }
    public class DTONotifyChild
    {
        public int ID_Notify { get; set; }
        public int? ID_Page { get; set; }
        public string Notify_Titile_Vn { get; set; }
        public string Notify_Titile_En { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public string AttFile { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public string ShortContent_Vn { get; set; }
        public string ShortContent_En { get; set; }
        public string Descriptions_Vn { get; set; }
        public string Descriptions_En { get; set; }
        public string Keywords_Titile { get; set; }
        public string Keywords_ShortContent { get; set; }
        public string Keywords_Descriptions { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public int Users_ID { get; set; }
        public int Flag { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}