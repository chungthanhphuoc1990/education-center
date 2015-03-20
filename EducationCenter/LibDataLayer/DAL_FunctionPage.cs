using System.Data;
using LibDBConnect;
namespace LibDataLayer
{
    public static class DalFunctionPage
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetPage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Page_GetFunctionPage");
        }
        public static DataTable GetFunctionPage(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_FunctionPage_Get");
        }
        public static DataTable GetFunctionPageEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Function_Id", id);
            return Cls.GetData("sp_FunctionPage_Get_Edit");
        }
        public static DataTable GetFunctionPageFillter(int ModunMain_Id, int ModunParent_Id,int ID_Page, int Group_Id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ModunMain_Id", ModunMain_Id);
            Cls.AddParameter("ModunParent_Id", ModunParent_Id);
            Cls.AddParameter("ID_Page", ID_Page);
            Cls.AddParameter("Group_Id", Group_Id);
            return Cls.GetData("sp_FunctionPage_GetFillter");
        }
        public static DataTable GetFunctionPageHome(int Group_Id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", Group_Id);
            return Cls.GetData("sp_FunctionPage_GetHomePage");
        }
        public static DataTable GetFunctionPageFillterMain(int Module_Main_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Main_ID", Module_Main_ID);
            return Cls.GetData("sp_FunctionPage_GetFillterModule_Main");
        }
        public static DataTable GetFunctionPageFillterParrent(int Module_Parrent_ID)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Module_Parrent_ID", Module_Parrent_ID);
            return Cls.GetData("sp_FunctionPage_GetFillterModule_Parrent");
        }
        public static DataTable GetFunctionPageFillterGroup(int Group_Id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", Group_Id);
            return Cls.GetData("sp_FunctionPage_GetFillterGroupUser");
        }
        public static DataTable GetFunctionPageFillterPage(int ID_Page)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Page", ID_Page);
            return Cls.GetData("sp_FunctionPage_GetFillterPage");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOFunctionPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ModunMain_Id", obj.ModunMain_Id);
            Cls.AddParameter("ModunParent_Id", obj.ModunParent_Id);
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("IsbtnAddNew", obj.IsbtnAddNew);
            Cls.AddParameter("IsbtnEdit", obj.IsbtnEdit);
            Cls.AddParameter("IsbtnUpdate", obj.IsbtnUpdate);
            Cls.AddParameter("IstbtnDel", obj.IstbtnDel);
            Cls.AddParameter("IsbtnRefesh", obj.IsbtnRefesh);
            Cls.AddParameter("IsUsedPageMain", obj.IsUsedPageMain);
            Cls.AddParameter("IsUsedPageParrent", obj.IsUsedPageParrent);
            Cls.AddParameter("IsUsedPage", obj.IsUsedPage);
            Cls.AddParameter("Descripttion", obj.Descripttion);
            Cls.ExecuteNonQuery("sp_FunctionPage_Insert");
            return true;
        }
        public static bool Update(DTOFunctionPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Function_Id", obj.Function_Id);
            Cls.AddParameter("ModunMain_Id", obj.ModunMain_Id);
            Cls.AddParameter("ModunParent_Id", obj.ModunParent_Id);
            Cls.AddParameter("ID_Page", obj.ID_Page);
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("IsbtnAddNew", obj.IsbtnAddNew);
            Cls.AddParameter("IsbtnEdit", obj.IsbtnEdit);
            Cls.AddParameter("IsbtnUpdate", obj.IsbtnUpdate);
            Cls.AddParameter("IstbtnDel", obj.IstbtnDel);
            Cls.AddParameter("IsbtnRefesh", obj.IsbtnRefesh);
            Cls.AddParameter("IsUsedPageMain", obj.IsUsedPageMain);
            Cls.AddParameter("IsUsedPageParrent", obj.IsUsedPageParrent);
            Cls.AddParameter("IsUsedPage", obj.IsUsedPage);
            Cls.AddParameter("Descripttion", obj.Descripttion);
            Cls.ExecuteNonQuery("sp_FunctionPage_Update");
            return true;
        }
        public static bool Delete(DTOFunctionPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Function_Id", obj.Function_Id);
            Cls.ExecuteNonQuery("sp_FunctionPage_Delete");
            return true;
        }
        public static bool UpdateCheck(DTOFunctionPage obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Function_Id", obj.Function_Id);
            Cls.AddParameter("IsbtnAddNew", obj.IsbtnAddNew);
            Cls.AddParameter("IsbtnEdit", obj.IsbtnEdit);
            Cls.AddParameter("IsbtnUpdate", obj.IsbtnUpdate);
            Cls.AddParameter("IstbtnDel", obj.IstbtnDel);
            Cls.AddParameter("IsbtnRefesh", obj.IsbtnRefesh);
            Cls.AddParameter("IsUsedPageMain", obj.IsUsedPageMain);
            Cls.AddParameter("IsUsedPageParrent", obj.IsUsedPageParrent);
            Cls.AddParameter("IsUsedPage", obj.IsUsedPage);
            Cls.ExecuteNonQuery("sp_FunctionPage_Update_Check");
            return true;
        }
        #endregion
    }
    public class DTOFunctionPage
    {
        public int Function_Id { get; set; }
        public int? ModunMain_Id { get; set; }
        public int? ModunParent_Id { get; set; }
        public int? ID_Page { get; set; }
        public int? Group_Id { get; set; }
        public bool IsbtnAddNew { get; set; }
        public bool IsbtnEdit { get; set; }
        public bool IsbtnUpdate { get; set; }
        public bool IstbtnDel { get; set; }
        public bool IsbtnRefesh { get; set; }
        public bool IsUsedPageMain { get; set; }
        public bool IsUsedPageParrent { get; set; }
        public bool IsUsedPage { get; set; }
        public string Descripttion { get; set; }
    }
}