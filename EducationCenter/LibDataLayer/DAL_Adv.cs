using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalAdv
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetAdv(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Adv_Get");
        }
        public static DataTable GetAdvEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Adv", id);
            return Cls.GetData("sp_Adv_Get_Edit");
        }
        public static DataTable GetAdvFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Adv_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOAdv obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Adv_Titile_Vn", obj.Adv_Titile_Vn);
            Cls.AddParameter("Adv_Titile_En", obj.Adv_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Adv_Insert");
            return true;
        }
        public static bool Update(DTOAdv obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Adv", obj.ID_Adv);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Adv_Titile_Vn", obj.Adv_Titile_Vn);
            Cls.AddParameter("Adv_Titile_En", obj.Adv_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Adv_Update");
            return true;
        }
        public static bool Delete(DTOAdv obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Adv", obj.ID_Adv);
            Cls.ExecuteNonQuery("sp_Adv_Delete");
            return true;
        }
        public static bool UpdateNum(DTOAdv obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Adv", obj.ID_Adv);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Adv_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOAdv obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Adv", obj.ID_Adv);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Adv_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetAdvHomePage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Adv_Get_HomePage");
        }
        #endregion
    }
    public class DTOAdv
    {
        public int ID_Adv { get; set; }
        public string Adv_Titile_Vn { get; set; }
        public string Adv_Titile_En { get; set; }
        public string Url { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public string Img { get; set; }
        public int Msg { get; set; }

    }
}