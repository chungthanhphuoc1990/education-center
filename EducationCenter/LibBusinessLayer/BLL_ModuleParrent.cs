using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllModuleParrent
    {
        #region[Get-Data]
        public DataTable GetModuleParrent(string keywords)
        {
            return DalModuleParrent.GetModuleParrent(keywords);
        }
        public DataTable GetModuleParrentEdit(int id)
        {
            return DalModuleParrent.GetModuleParrentEdit(id);
        }
        public DataTable GetModuleParrentPageMaster(int Module_Main_ID)
        {
            return DalModuleParrent.GetModuleParrentPageMaster(Module_Main_ID);
        }
        public DataTable GetModuleParrentFillter(int Module_Main_ID)
        {
            return DalModuleParrent.GetModuleParrentFillter(Module_Main_ID);
        }
        public DataTable GetModuleParrentFillterStatus(int IsActive)
        {
            return DalModuleParrent.GetModuleParrentFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOModuleParrent obj)
        {
            DalModuleParrent.Insert(obj);
            return true;
        }
        public static bool Update(DTOModuleParrent obj)
        {
            DalModuleParrent.Update(obj);
            return true;
        }
        public static bool Delete(DTOModuleParrent obj)
        {
            DalModuleParrent.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOModuleParrent obj)
        {
            DalModuleParrent.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOModuleParrent obj)
        {
            DalModuleParrent.UpdateCheck(obj);
            return true;
        }
        #endregion
    }
}