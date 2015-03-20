using System;
using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalIntro
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetIntro(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Intro_Get");
        }
        public static DataTable GetIntroEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Intro", id);
            return Cls.GetData("sp_Intro_Get_Edit");
        }
        public static DataTable GetIntroFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Intro_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Update(DTOIntro obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Intro", obj.ID_Intro);
            Cls.AddParameter("Titile_Vn", obj.Titile_Vn);
            Cls.AddParameter("Titile_En", obj.Titile_En);
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
            Cls.AddParameter("Position", obj.Position);
            Cls.AddParameter("DateBegin", obj.DateBegin);
            Cls.AddParameter("DateEnd", obj.DateEnd);
            Cls.AddParameter("Width", obj.Width);
            Cls.AddParameter("Height", obj.Height);
            return Cls.ExecuteNonQuery("sp_Intro_Update");
        }
        public static bool Delete(DTOIntro obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Intro", obj.ID_Intro);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_Intro_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOIntro obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Intro", obj.ID_Intro);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Intro_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOIntro obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Intro", obj.ID_Intro);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Intro_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetIntroHomePage(string Position)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Position", Position);
            return Cls.GetData("sp_Intro_Get_HomePage");
        }
        public static DataTable GetIntroHomePageDetail(string Friendly_Url_Vn)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url_Vn);
            return Cls.GetData("sp_Intro_Get_HomePageDetail");
        }
        #endregion
    }
    public class DTOIntro
    {
        public int ID_Intro { get; set; }
        public string Titile_Vn { get; set; }
        public string Titile_En { get; set; }
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
        public string Position { get; set; }
        public int Num { get; set; }
        public string Url { get; set; }
        public int Msg { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}