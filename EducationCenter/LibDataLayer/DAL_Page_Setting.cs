using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalPageSetting
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetPageSetting()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_Page_Setting_Get");
        }
        public static DataTable GetPageSettingEdit(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_Page_Setting_Get_Edit");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Update(DTOPageSetting obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Page_Titile", obj.Page_Titile);
            Cls.AddParameter("Page_Logo", obj.Page_Logo);
            Cls.AddParameter("Page_Banner", obj.Page_Banner);
            Cls.AddParameter("Page_Icon", obj.Page_Icon);
            Cls.AddParameter("Page_Footer", obj.Page_Footer);
            Cls.AddParameter("Page_Map", obj.Page_Map);
            Cls.AddParameter("Page_Map_Width", obj.Page_Map_Width);
            Cls.AddParameter("Page_Map_Height", obj.Page_Map_Height);
            Cls.AddParameter("Keywords_Titile", obj.Keywords_Titile);
            Cls.AddParameter("Keywords_ShortContent", obj.Keywords_ShortContent);
            Cls.AddParameter("Keywords_Descriptions", obj.Keywords_Descriptions);
            Cls.ExecuteNonQuery("sp_Page_Setting_Update");
            return true;
        }
        #endregion
    }
    public class DTOPageSetting
    {
        public int ID_Page { get; set; }
        public string Page_Titile { get; set; }
        public string Page_Logo { get; set; }
        public string Page_Banner { get; set; }
        public string Page_Icon { get; set; }
        public string Page_Footer { get; set; }
        public string Page_Map { get; set; }
        public int ? Page_Map_Width { get; set; }
        public int ? Page_Map_Height { get; set; }
        public string Keywords_Titile { get; set; }
        public string Keywords_ShortContent { get; set; }
        public string Keywords_Descriptions { get; set; }
    }
}