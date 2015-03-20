using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalUtilities
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetUtilities(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Utilities_Get");
        }
        public static DataTable GetUtilitiesEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", id);
            return Cls.GetData("sp_Utilities_Get_Edit");
        }
        public static DataTable GetUtilitiesFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Utilities_Get_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUtilities obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Utilities_Titile_Vn", obj.Utilities_Titile_Vn);
            Cls.AddParameter("Utilities_Titile_En", obj.Utilities_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Utilities_Insert");
            return true;
        }
        public static bool Update(DTOUtilities obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", obj.ID_Utilities);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("Utilities_Titile_Vn", obj.Utilities_Titile_Vn);
            Cls.AddParameter("Utilities_Titile_En", obj.Utilities_Titile_En);
            Cls.AddParameter("Img", obj.Img);
            Cls.AddParameter("Friendly_Url_Vn", obj.Friendly_Url_Vn);
            Cls.AddParameter("Friendly_Url_En", obj.Friendly_Url_En);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Utilities_Update");
            return true;
        }
        public static bool Delete(DTOUtilities obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", obj.ID_Utilities);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_Utilities_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOUtilities obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", obj.ID_Utilities);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Utilities_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOUtilities obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", obj.ID_Utilities);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Utilities_Update_Check");
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public static DataTable GetUtilitiesHomePage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Utilities_Get_HomePage");
        }
        #endregion
    }
    public class DTOUtilities
    {
        public int ID_Utilities { get; set; }
        public string Utilities_Titile_Vn { get; set; }
        public string Utilities_Titile_En { get; set; }
        public string Url { get; set; }
        public string Friendly_Url_Vn { get; set; }
        public string Friendly_Url_En { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public string Img { get; set; }
        public int Msg { get; set; }

    }
}