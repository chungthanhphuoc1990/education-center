using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalCatalogMainChild
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetCatalogMain(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_CatalogMainChild_Get");
        }
        public static DataTable GetCatalogMainEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", id);
            return Cls.GetData("sp_CatalogMainChild_Get_Edit");
        }
        public static DataTable GetCatalogMainFillterStatus(int IsActive, int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_CatalogMainChild_Get_FillterStatus");
        }
        public static DataTable GetCatalogMainFillterPage(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_CatalogMainChild_Get_FillterPage");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogMainChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Catalog_Main_Titile_Vn", obj.Catalog_Main_Titile_Vn);
            Cls.AddParameter("Catalog_Main_Titile_En", obj.Catalog_Main_Titile_En);
            Cls.AddParameter("Img", obj.Img);
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
            Cls.AddParameter("Url", obj.Url);
            Cls.ExecuteNonQuery("sp_CatalogMainChild_Insert");
            return true;
        }
        public static bool Update(DTOCatalogMainChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Catalog_Main_Titile_Vn", obj.Catalog_Main_Titile_Vn);
            Cls.AddParameter("Catalog_Main_Titile_En", obj.Catalog_Main_Titile_En);
            Cls.AddParameter("Img", obj.Img);
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
            Cls.AddParameter("Url", obj.Url);
            Cls.ExecuteNonQuery("sp_CatalogMainChild_Update");
            return true;
        }
        public static bool Delete(DTOCatalogMainChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_CatalogMainChild_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOCatalogMainChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_CatalogMainChild_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOCatalogMainChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_CatalogMainChild_Update_Check");
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogMainChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("IsShow", obj.IsShow);
            Cls.ExecuteNonQuery("sp_CatalogMainChild_Update_IsShow");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetCatalogMainHomePage(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_CatalogMainChild_Get_HomePage");
        }
        public static DataTable GetCatalogMainHomePageDetail(int ID_Page, string Friendly_Url_Vn)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url_Vn);
            return Cls.GetData("sp_CatalogMainChildHomeDetail_Get");
        }
        #endregion
    }
    public class DTOCatalogMainChild
    {
        public int ID_CatMain { get; set; }
        public int ? ID_Page { get; set; }
        public string Catalog_Main_Titile_Vn { get; set; }
        public string Catalog_Main_Titile_En { get; set; }
        public string Img { get; set; }
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
        public bool IsShow { get; set; }
        public int Num { get; set; }
        public string Url { get; set; }
        public int Msg { get; set; }
    }
}