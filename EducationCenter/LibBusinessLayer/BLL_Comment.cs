using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllComment
    {
        #region[Get-Data]
        public DataTable GetComment()
        {
            return DalCommnet.GetComment();
        }
        public DataTable GetCommentAdmin(string keywords)
        {
            return DalCommnet.GetCommentAdmin(keywords);
        }
        public DataTable GetCommentAdminEdit(int id)
        {
            return DalCommnet.GetCommentAdminEdit(id);
        }
        public DataTable GetCommentFillter(int id)
        {
            return DalCommnet.GetCommentFillter(id);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool InsertComment(DTOComment obj)
        {
            DalCommnet.InsertComment(obj);
            return true;
        }
        public static bool UpdateComment(DTOComment obj)
        {
            DalCommnet.UpdateComment(obj);
            return true;
        }
        public static bool DeleteComment(DTOComment obj)
        {
            DalCommnet.DeleteComment(obj);
            return true;
        }
        #endregion
    }
}