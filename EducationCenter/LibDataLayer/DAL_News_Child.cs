using System;
using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalNewsChild
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetNewsChild(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_News_Child_Get");
        }
        public static DataTable GetNewsChildEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", id);
            return Cls.GetData("sp_News_Child_Get_Edit");
        }
        public static DataTable GetNewsChildFillter(int ID_CatPrarent)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatPrarent", ID_CatPrarent);
            return Cls.GetData("sp_News_Child_Get_Fillter");
        }
        public static DataTable GetNewsChildFillterStatus(int IsActive,int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_News_Child_Get_Fillter_Status");
        }
        public static DataTable GetNewsChildFillterIsHot(int IsHot,int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsHot", IsHot);
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_News_Child_Get_Fillter_IsHot");
        }
        public static DataTable GetCatalogParrentMain(int ID_CatMain)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", ID_CatMain);
            return Cls.GetData("sp_CatalogParrent_Main_Get");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONewsChild obj)
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
            Cls.ExecuteNonQuery("sp_News_Child_Insert");
            return true;
        }
        public static bool Update(DTONewsChild obj)
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
            Cls.ExecuteNonQuery("sp_News_Child_Update");
            return true;
        }
        public static bool Delete(DTONewsChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.ExecuteNonQuery("sp_News_Child_Delete");
            return true;
        }
        public static bool UpdateNum(DTONewsChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_News_Child_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTONewsChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_News_Child_Update_Check");
            return true;
        }
        public static bool UpdateIsHot(DTONewsChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("IsHot", obj.IsHot);
            Cls.ExecuteNonQuery("sp_News_Child_Update_IsHot");
            return true;
        }
        public static bool UpdateIsSlide(DTONewsChild obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("IsSlide", obj.IsSlide);
            Cls.ExecuteNonQuery("sp_News_Child_Update_IsSlide");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetNewsChildHomePage(string keywords, int ID_CatPrarent)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("ID_CatPrarent", ID_CatPrarent);
            return Cls.GetData("sp_NewsChild_Get_HomePage");
        }
        public static DataTable GetNewsChildHomePageTitile(int ID_Page,string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Child_Get_HomePageTitile");
        }
        public static DataTable GetNewsChildHomePageDetail(int ID_Page,string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Child_Get_HomePageDetail");
        }
        public static DataTable GetNewsChildHomePageOrder(int ID_Page,string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_News_Child_Get_HomePageOrder");
        }
        public static DataTable GetNewsChildHomePageSlide(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_NewsChild_Get_HomePageSlide");
        }
        #endregion
    }

    public class DTONewsChild
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