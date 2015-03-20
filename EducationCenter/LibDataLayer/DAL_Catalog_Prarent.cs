using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalCatalogPrarent
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetCatalogPrarent(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_CatalogPrarent_Get");
        }
        public static DataTable GetCatalogPrarentEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", id);
            return Cls.GetData("sp_CatalogPrarent_Get_Edit");
        }
        public static DataTable GetCatalogPrarentFillter(int ID_CatalogMain)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", ID_CatalogMain);
            return Cls.GetData("sp_CatalogPrarent_Get_Fillter");
        }
        public static DataTable GetCatalogPrarentFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_CatalogPrarent_Get_Fillter_Status");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogPrarent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("Catalog_Prarent_Titile_Vn", obj.Catalog_Prarent_Titile_Vn);
            Cls.AddParameter("Catalog_Prarent_Titile_En", obj.Catalog_Prarent_Titile_En);
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
            Cls.ExecuteNonQuery("sp_CatalogPrarent_Insert");
            return true;
        }
        public static bool Update(DTOCatalogPrarent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("Catalog_Prarent_Titile_Vn", obj.Catalog_Prarent_Titile_Vn);
            Cls.AddParameter("Catalog_Prarent_Titile_En", obj.Catalog_Prarent_Titile_En);
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
            Cls.ExecuteNonQuery("sp_CatalogPrarent_Update");
            return true;
        }
        public static bool Delete(DTOCatalogPrarent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_CatalogPrarent_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOCatalogPrarent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_CatalogPrarent_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOCatalogPrarent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_CatalogPrarent_Update_Check");
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogPrarent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            Cls.AddParameter("IsShow", obj.IsShow);
            Cls.ExecuteNonQuery("sp_CatalogPrarent_Update_IsShow");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetCatalogParrentHomePage(int ID_CatMain)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", ID_CatMain);
            return Cls.GetData("sp_CatalogParrentHome_Get");
        }
        public static DataTable GetCatalogParrentHomePageDetail(string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_CatalogParrentHomeDetail_Get");
        }
        #endregion
    }
    public class DTOCatalogPrarent
    {
        public int ID_CatPrarent { get; set; }
        public int ID_CatMain { get; set; }
        public string Url { get; set; }
        public string Catalog_Prarent_Titile_Vn { get; set; }
        public string Catalog_Prarent_Titile_En { get; set; }
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
        public int Msg { get; set; }
    }
}