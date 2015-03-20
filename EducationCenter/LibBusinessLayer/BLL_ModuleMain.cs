using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllModuleMain
    {
        #region[Get-Data]
        public DataTable GetModuleMain(string keywords)
        {
            return DalModuleMain.GetModuleMain(keywords);
        }
        public DataTable GetModuleMainPageMaster(string keywords)
        {
            return DalModuleMain.GetModuleMainPageMaster(keywords);
        }
        public DataTable GetModuleMainEdit(int id)
        {
            return DalModuleMain.GetModuleMainEdit(id);
        }
        public DataTable GetModuleMainFillterStatus(int IsActive)
        {
            return DalModuleMain.GetModuleMainFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOModuleMain obj)
        {
            DalModuleMain.Insert(obj);
            return true;
        }
        public static bool Update(DTOModuleMain obj)
        {
            DalModuleMain.Update(obj);
            return true;
        }
        public static bool Delete(DTOModuleMain obj)
        {
            DalModuleMain.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOModuleMain obj)
        {
            DalModuleMain.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOModuleMain obj)
        {
            DalModuleMain.UpdateCheck(obj);
            return true;
        }
        #endregion
    }
}