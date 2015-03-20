using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllNotify
    {
        #region[Get-Data]
        public DataTable GetNotify(string keywords)
        {
            return DalNotify.GetNotify(keywords);
        }
        public DataTable GetNotifyEdit(int id)
        {
            return DalNotify.GetNotifyEdit(id);
        }
        public DataTable GetNotifyFillterStatus(int IsActive)
        {
            return DalNotify.GetNotifyFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONotify obj)
        {
            DalNotify.Insert(obj);
            return true;
        }
        public static bool Update(DTONotify obj)
        {
            DalNotify.Update(obj);
            return true;
        }
        public static bool Delete(DTONotify obj)
        {
            DalNotify.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTONotify obj)
        {
            DalNotify.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTONotify obj)
        {
            DalNotify.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetNotifyHomePage(string keywords)
        {
            return DalNotify.GetNotifyHomePage(keywords);
        }
        #endregion
    }
}
