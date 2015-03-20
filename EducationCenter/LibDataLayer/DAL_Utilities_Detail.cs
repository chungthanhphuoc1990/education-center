using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public class DalUtilitiesDetail
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetUtilitiesDetail(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_UtilitiesDetail_Get");
        }
        public static DataTable GetUtilitiesDetailEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", id);
            return Cls.GetData("sp_Utilities_Detail_Get_Edit");
        }
        public static DataTable GetUtilitiesDetailFillter(int ID_Utilities)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", ID_Utilities);
            return Cls.GetData("sp_UtilitiesDetail_Get_Fillter");
        }
        public static DataTable GetUtilitiesDetailFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_UtilitiesDetail_Get_Fillter_Status");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUtilitiesDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Utilities", obj.ID_Utilities);
            Cls.AddParameter("Utilities_Titile_Vn", obj.Utilities_Titile_Vn);
            Cls.AddParameter("Utilities_Titile_En", obj.Utilities_Titile_En);
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
            Cls.ExecuteNonQuery("sp_UtilitiesDetail_Insert");
            return true;
        }
        public static bool Update(DTOUtilitiesDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("ID_Utilities", obj.ID_Utilities);
            Cls.AddParameter("Utilities_Titile_Vn", obj.Utilities_Titile_Vn);
            Cls.AddParameter("Utilities_Titile_En", obj.Utilities_Titile_En);
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
            Cls.ExecuteNonQuery("sp_Utilities_Detail_Update");
            return true;
        }
        public static bool Delete(DTOUtilitiesDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.ExecuteNonQuery("sp_Utilities_Detail_Delete");
            return true;
        }
        public static bool UpdateNum(DTOUtilitiesDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_Utilities_Detail_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOUtilitiesDetail obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Utilities_Detail_Update_Check");
            return true;
        }
        #endregion

        #region[Get-HomePage]
        public static DataTable GetUtilitiesDetailHome(string keywords, string Friendly_Url)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            Cls.AddParameter("Friendly_Url_Vn", Friendly_Url);
            return Cls.GetData("sp_UtilitiesDetail_Get_HomePage");
        }
        #endregion
    }

    public class DTOUtilitiesDetail
    {
        public int ID_Detail { get; set; }
        public int ID_Utilities { get; set; }
        public string Utilities_Titile_Vn { get; set; }
        public string Utilities_Titile_En { get; set; }
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
    }
}
