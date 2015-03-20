using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllGroupUser
    {
        #region[Get-Data]
        public DataTable GetGroupUser(string keywords)
        {
            return DalGroupUser.GetGroupUser(keywords);
        }
        public DataTable GetGroupUserEdit(int id)
        {
            return DalGroupUser.GetGroupUserEdit(id);
        }
        public DataTable GetGroupUserFillterStatus(int IsActive)
        {
            return DalGroupUser.GetGroupUserFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOGroupUser obj)
        {
            DalGroupUser.Insert(obj);
            return true;
        }
        public static bool Update(DTOGroupUser obj)
        {
            DalGroupUser.Update(obj);
            return true;
        }
        public static bool Delete(DTOGroupUser obj)
        {
            DalGroupUser.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOGroupUser obj)
        {
            DalGroupUser.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOGroupUser obj)
        {
            DalGroupUser.UpdateCheck(obj);
            return true;
        }
        #endregion
    }
}