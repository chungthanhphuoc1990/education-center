using System;
using System.Data;
using LibDBConnect;


namespace LibDataLayer
{
    public class DalGalleryDetail
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetGalleryDetail(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_GalleryDetail_Get");
        }
        public static DataTable GetGalleryDetailEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", id);
            return Cls.GetData("sp_GalleryDetail_Get_Edit");
        }
        public static DataTable GetGalleryDetailFillter(int ID_Gallery)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", ID_Gallery);
            return Cls.GetData("sp_GalleryDetail_Get_Fillter");
        }
        public static DataTable GetGalleryDetailFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_GalleryDetail_Get_Fillter_Status");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOGalleryDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", obj.ID_Gallery);
            Cls.AddParameter("Gallery_Titile_Vn", obj.Gallery_Titile_Vn);
            Cls.AddParameter("Gallery_Titile_En", obj.Gallery_Titile_En);
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
            Cls.ExecuteNonQuery("sp_GalleryDetail_Insert");
            return true;
        }
        public static bool Update(DTOGalleryDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("ID_Gallery", obj.ID_Gallery);
            Cls.AddParameter("Gallery_Titile_Vn", obj.Gallery_Titile_Vn);
            Cls.AddParameter("Gallery_Titile_En", obj.Gallery_Titile_En);
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
            Cls.ExecuteNonQuery("sp_GalleryDetail_Update");
            return true;
        }
        public static bool Delete(DTOGalleryDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.ExecuteNonQuery("sp_GalleryDetail_Delete");
            return true;
        }
        public static bool UpdateNum(DTOGalleryDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Gallery_Detail_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOGalleryDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Gallery_Detail_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetGalleryDetailHomePage(int ID_Gallery)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", ID_Gallery);
            return Cls.GetData("sp_GalleryDetail_Get_HomePage");
        }
        public static DataTable GetGalleryDetailHomePageShowAll()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_GalleryDetail_Get_HomePageShowAll");
        }
        #endregion
    }
    public class DTOGalleryDetail
    {
        public int ID_Detail { get; set; }
        public int? ID_Gallery { get; set; }
        public string Gallery_Titile_Vn { get; set; }
        public string Gallery_Titile_En { get; set; }
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