using System;
using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalNews
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetNews(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_News_Get");
        }
        public static DataTable GetNewsEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", id);
            return Cls.GetData("sp_News_Get_Edit");
        }
        public static DataTable GetNewsFillter(int ID_CatPrarent)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", ID_CatPrarent);
            return Cls.GetData("sp_News_Get_Fillter");
        }
        public static DataTable GetNewsFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_News_Get_Fillter_Status");
        }
        public static DataTable GetNewsFillterIsHot(int IsHot)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsHot", IsHot);
            return Cls.GetData("sp_News_Get_Fillter_IsHot");
        }
        public static DataTable GetCatalogParrentMain(int ID_CatMain)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", ID_CatMain);
            return Cls.GetData("sp_CatalogParrent_Main_Get");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Titile_Vn", obj.Titile_Vn);
            Cls.AddParameter("Titile_En", obj.Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Width", obj.Width);
            Cls.AddParameter("Height", obj.Height);
            Cls.AddParameter("Img_Thumb", obj.Img_Thumb);
            Cls.AddParameter("Width_Thumb", obj.Width_Thumb);
            Cls.AddParameter("Height_Thumb", obj.Height_Thumb);
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
            Cls.AddParameter("IsHot", obj.IsHot);
            Cls.AddParameter("IsSlide", obj.IsSlide);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            Cls.AddParameter("DateEnd", obj.DateEnd);
            Cls.ExecuteNonQuery("sp_News_Insert");
            return true;
        }
        public static bool Update(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("ID_CatPrarent", obj.ID_CatPrarent);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Titile_Vn", obj.Titile_Vn);
            Cls.AddParameter("Titile_En", obj.Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Width", obj.Width);
            Cls.AddParameter("Height", obj.Height);
            Cls.AddParameter("Img_Thumb", obj.Img_Thumb);
            Cls.AddParameter("Width_Thumb", obj.Width_Thumb);
            Cls.AddParameter("Height_Thumb", obj.Height_Thumb);
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
            Cls.AddParameter("IsHot", obj.IsHot);
            Cls.AddParameter("IsSlide", obj.IsSlide);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            Cls.AddParameter("DateEnd", obj.DateEnd);
            Cls.ExecuteNonQuery("sp_News_Update");
            return true;
        }
        public static bool Delete(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.ExecuteNonQuery("sp_News_Delete");
            return true;
        }
        public static bool UpdateNum(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_News_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_News_Update_Check");
            return true;
        }
        public static bool UpdateIsHot(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("IsHot", obj.IsHot);
            Cls.ExecuteNonQuery("sp_News_Update_IsHot");
            return true;
        }
        public static bool UpdateIsSilde(DTONews obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("IsSlide", obj.IsSlide);
            Cls.ExecuteNonQuery("sp_News_Update_IsSlide");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetNewsHomePage(string keywords, int ID_CatPrarent)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("ID_CatPrarent", ID_CatPrarent);
            return Cls.GetData("sp_News_Get_HomePage");
        }
        public static DataTable GetNewsHomePageSlide(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_News_Get_HomePageSlide");
        }
        public static DataTable GetNewsHomePageTitile(string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Get_HomePageTitile");
        }
        public static DataTable GetNewsHomePageTitile1(string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Get_HomePageTitile_1");
        }
        public static DataTable GetNewsHomePageDetail(string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Get_HomePageDetail");
        }
        public static DataTable GetNewsHomePageOrder(string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Get_HomePageOrder");
        }
        #endregion
    }

    public class DTONews
    {
        public int ID_News { get; set; }
        public int ID_CatPrarent { get; set; }
        public string Url { get; set; }
        public string Titile_Vn { get; set; }
        public string Titile_En { get; set; }
        public string Img { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Img_Thumb { get; set; }
        public int Width_Thumb { get; set; }
        public int Height_Thumb { get; set; }
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
        public bool IsHot { get; set; }
        public bool IsSlide { get; set; }
        public int Num { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}