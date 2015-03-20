using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllFunctionPage
    {
        #region[Get-Data]
        public DataTable GetPage(string keywords)
        {
            return DalFunctionPage.GetPage(keywords);
        }
        public DataTable GetFunctionPage(string keywords)
        {
            return DalFunctionPage.GetFunctionPage(keywords);
        }
        public DataTable GetFunctionPageEdit(int id)
        {
            return DalFunctionPage.GetFunctionPageEdit(id);
        }
        public DataTable GetFunctionPageFillter(int ModunMain_Id, int ModunParent_Id, int ID_Page, int Group_Id)
        {
            return DalFunctionPage.GetFunctionPageFillter(ModunMain_Id, ModunParent_Id, ID_Page, Group_Id);
        }
        public DataTable GetFunctionPageHome(int Group_Id)
        {
            return DalFunctionPage.GetFunctionPageHome(Group_Id);
        }
        public DataTable GetFunctionPageFillterMain(int Module_Main_ID)
        {
            return DalFunctionPage.GetFunctionPageFillterMain(Module_Main_ID);
        }
        public DataTable GetFunctionPageFillterParrent(int Module_Parrent_ID)
        {
            return DalFunctionPage.GetFunctionPageFillterParrent(Module_Parrent_ID);
        }
        public DataTable GetFunctionPageFillterGroup(int Group_Id)
        {
            return DalFunctionPage.GetFunctionPageFillterGroup(Group_Id);
        }
        public DataTable GetFunctionPageFillterPage(int ID_Page)
        {
            return DalFunctionPage.GetFunctionPageFillterPage(ID_Page);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOFunctionPage obj)
        {
            DalFunctionPage.Insert(obj);
            return true;
        }
        public static bool Update(DTOFunctionPage obj)
        {
            DalFunctionPage.Update(obj);
            return true;
        }
        public static bool Delete(DTOFunctionPage obj)
        {
            DalFunctionPage.Delete(obj);
            return true;
        }
        public static bool UpdateCheck(DTOFunctionPage obj)
        {
            DalFunctionPage.UpdateCheck(obj);
            return true;
        }
        #endregion
    }
}