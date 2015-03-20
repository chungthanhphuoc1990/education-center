using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalModuleParrent
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetModuleParrent(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_ModuleParrent_Get");
        }
        public static DataTable GetModuleParrentPageMaster(int Module_Main_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", Module_Main_ID);
            return Cls.GetData("sp_ModuleParrent_GetPageMaster");
        }
        public static DataTable GetModuleParrentEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Parrent_ID", id);
            return Cls.GetData("sp_ModuleParrent_Get_Edit");
        }
        public static DataTable GetModuleParrentFillter(int Module_Main_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", Module_Main_ID);
            return Cls.GetData("sp_ModuleParrent_GetFillter");
        }
        public static DataTable GetModuleParrentFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_ModuleParrent_GetFillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOModuleParrent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", obj.Module_Main_ID);
            Cls.AddParameter("Module_Parrent_Code", obj.Module_Parrent_Code);
            Cls.AddParameter("Module_Parrent_Name", obj.Module_Parrent_Name);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_ModuleParrent_Insert");
            return true;
        }
        public static bool Update(DTOModuleParrent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Parrent_ID", obj.Module_Parrent_ID);
            Cls.AddParameter("Module_Main_ID", obj.Module_Main_ID);
            Cls.AddParameter("Module_Parrent_Code", obj.Module_Parrent_Code);
            Cls.AddParameter("Module_Parrent_Name", obj.Module_Parrent_Name);
            Cls.AddParameter("Url", obj.Url);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_ModuleParrent_Update");
            return true;
        }
        public static bool Delete(DTOModuleParrent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Parrent_ID", obj.Module_Parrent_ID);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_ModuleParrent_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOModuleParrent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Parrent_ID", obj.Module_Parrent_ID);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_ModuleParrent_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOModuleParrent obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Parrent_ID", obj.Module_Parrent_ID);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_ModuleParrent_Update_Check");
            return true;
        }
        #endregion
    }
    public class DTOModuleParrent
    {
        public int Module_Parrent_ID { get; set; }
        public int Module_Main_ID { get; set; }
        public string Module_Parrent_Code { get; set; }
        public string Module_Parrent_Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Num { get; set; }
        public int Msg { get; set; }
    }
}