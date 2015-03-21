using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalCatalogMain
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetCatalogMain(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_CatalogMain_Get");
        }
        public static DataTable GetCatalogMainEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", id);
            return Cls.GetData("sp_CatalogMain_Get_Edit");
        }
        public static DataTable GetCatalogMainFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_CatalogMain_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogMain obj)
        {
            Cls.CreateNewSqlCommand();
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
            Cls.ExecuteNonQuery("sp_CatalogMain_Insert");
            return true;
        }
        public static bool Update(DTOCatalogMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
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
            Cls.ExecuteNonQuery("sp_CatalogMain_Update");
            return true;
        }
        public static bool Delete(DTOCatalogMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_CatalogMain_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOCatalogMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_CatalogMain_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOCatalogMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_CatalogMain_Update_Check");
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("IsShow", obj.IsShow);
            Cls.ExecuteNonQuery("sp_CatalogMain_Update_IsShow");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetCatalogMainHomePage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_CatalogMain_GetHomePage");
        }
        public static DataTable GetCatalogMainHomePageDetail(string Friendly_Url_Vn)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url_Vn);
            return Cls.GetData("sp_CatalogMainHomeDetail_Get");
        }
        public static DataTable GetCatalogMainHomePageDetail1(string Friendly_Url_Vn)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url_Vn);
            return Cls.GetData("sp_CatalogParrentHomeDetail_Get_1");
        }
        #endregion
    }
    public class DTOCatalogMain
    {
        public int ID_CatMain { get; set; }
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
