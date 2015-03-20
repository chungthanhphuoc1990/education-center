using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllAdv
    {
        #region[Get-Data]
        public DataTable GetAdv(string keywords)
        {
            return DalAdv.GetAdv(keywords);
        }
        public DataTable GetAdvEdit(int id)
        {
            return DalAdv.GetAdvEdit(id);
        }
        public DataTable GetAdvFillterStatus(int IsActive)
        {
            return DalAdv.GetAdvFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOAdv obj)
        {
            DalAdv.Insert(obj);
            return true;
        }
        public static bool Update(DTOAdv obj)
        {
            DalAdv.Update(obj);
            return true;
        }
        public static bool Delete(DTOAdv obj)
        {
            DalAdv.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOAdv obj)
        {
            DalAdv.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOAdv obj)
        {
            DalAdv.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetAdvHomePage(string keywords)
        {
            return DalAdv.GetAdvHomePage(keywords);
        }
        #endregion
    }
}
