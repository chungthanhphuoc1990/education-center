using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalModuleMain
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetModuleMain(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_ModuleMain_Get");
        }
        public static DataTable GetModuleMainPageMaster(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_ModuleMain_GetPageMaster");
        }
        public static DataTable GetModuleMainEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", id);
            return Cls.GetData("sp_ModuleMain_Get_Edit");
        }
        public static DataTable GetModuleMainFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_ModuleMain_GetFillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOModuleMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_Code", obj.Module_Main_Code);
            Cls.AddParameter("Module_Main_Name", obj.Module_Main_Name);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_ModuleMain_Insert");
            return true;
        }
        public static bool Update(DTOModuleMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", obj.Module_Main_ID);
            Cls.AddParameter("Module_Main_Code", obj.Module_Main_Code);
            Cls.AddParameter("Module_Main_Name", obj.Module_Main_Name);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_ModuleMain_Update");
            return true;
        }
        public static bool Delete(DTOModuleMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", obj.Module_Main_ID);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_ModuleMain_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOModuleMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", obj.Module_Main_ID);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_ModuleMain_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOModuleMain obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", obj.Module_Main_ID);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_ModuleMain_Update_Check");
            return true;
        }
        #endregion
    }
    public class DTOModuleMain
    {
        public int Module_Main_ID { get; set; }
        public string Module_Main_Code { get; set; }
        public string Module_Main_Name { get; set; }
        public string Url { get; set; }
        public  bool IsActive { get; set; }
        public int Num { get; set; }
        public int Msg { get; set; }
    }
}