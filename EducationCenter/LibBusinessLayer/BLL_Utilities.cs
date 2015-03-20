using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllUtilities
    {
        #region[Get-Data]
        public DataTable GetUtilities(string keywords)
        {
            return DalUtilities.GetUtilities(keywords);
        }
        public DataTable GetUtilitiesEdit(int id)
        {
            return DalUtilities.GetUtilitiesEdit(id);
        }
        public DataTable GetUtilitiesFillterStatus(int IsActive)
        {
            return DalUtilities.GetUtilitiesFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUtilities obj)
        {
            DalUtilities.Insert(obj);
            return true;
        }
        public static bool Update(DTOUtilities obj)
        {
            DalUtilities.Update(obj);
            return true;
        }
        public static bool Delete(DTOUtilities obj)
        {
            DalUtilities.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOUtilities obj)
        {
            DalUtilities.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOUtilities obj)
        {
            DalUtilities.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetUtilitiesHomePage(string keywords)
        {
            return DalUtilities.GetUtilitiesHomePage(keywords);
        }
        #endregion
    }
}
