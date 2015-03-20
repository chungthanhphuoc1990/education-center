using System.Data;
using LibDBConnect;


namespace LibDataLayer
{
    public static class DalGallery
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetGallery(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Gallery_Get");
        }
        public static DataTable GetGalleryEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", id);
            return Cls.GetData("sp_Gallery_Get_Edit");
        }
        public static DataTable GetGalleryFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Gallery_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOGallery obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Gallery_Titile_Vn", obj.Gallery_Titile_Vn);
            Cls.AddParameter("Gallery_Titile_En", obj.Gallery_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.AddParameter("Users_ID", obj.Users_ID);
            Cls.ExecuteNonQuery("sp_Gallery_Insert");
            return true;
        }
        public static bool Update(DTOGallery obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", obj.ID_Gallery);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Gallery_Titile_Vn", obj.Gallery_Titile_Vn);
            Cls.AddParameter("Gallery_Titile_En", obj.Gallery_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Gallery_Update");
            return true;
        }
        public static bool Delete(DTOGallery obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", obj.ID_Gallery);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_Gallery_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOGallery obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", obj.ID_Gallery);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Gallery_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOGallery obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Gallery", obj.ID_Gallery);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Gallery_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetGalleryHomePage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Gallery_Get_HomePage");
        }
        #endregion
    }
    public class DTOGallery
    {
        public int ID_Gallery { get; set; }
        public string Url { get; set; }
        public string Gallery_Titile_Vn { get; set; }
        public string Gallery_Titile_En { get; set; }
        public string Img { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public int Msg { get; set; }
        public int Users_ID { get; set; }
    }
}