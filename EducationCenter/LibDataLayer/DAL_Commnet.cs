using System;
using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalCommnet
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetComment()
        {
            Cls.CreateNewSqlCommand();
            return Cls.GetData("sp_Comment_Get");
        }
        public static DataTable GetCommentAdmin(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_Comment_Get_Admin");
        }
        public static DataTable GetCommentAdminEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Comment", id);
            return Cls.GetData("sp_Comment_Get_Admin_Edit");
        }
        public static DataTable GetCommentFillter(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_Comment_Get_Admin_FillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool InsertComment(DTOComment obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_CatMain", obj.ID_CatMain);
            Cls.AddParameter("ID_Student", obj.ID_Student);
            Cls.AddParameter("ID_News", obj.ID_News);
            Cls.AddParameter("ID_Detail", obj.ID_Detail);
            Cls.AddParameter("ID_Video", obj.ID_Video);
            Cls.AddParameter("Comment_Content", obj.Comment_Content);
            Cls.ExecuteNonQuery("sp_Comment_Insert");
            return true;
        }
        public static bool UpdateComment(DTOComment obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Comment", obj.ID_Comment);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_Comment_Update");
            return true;
        }
        public static bool DeleteComment(DTOComment obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("ID_Comment", obj.ID_Comment);
            Cls.ExecuteNonQuery("sp_Comment_Delete");
            return true;
        }
        #endregion
    }
    public class DTOComment
    {
        public int ? ID_Comment { get; set; }
        public int ? ID_Student { get; set; }
        public int? ID_News { get; set; }
        public int? ID_Detail { get; set; }
        public int? ID_Video { get; set; }
        public int? ID_CatMain { get; set; }
        public string Comment_Content { get; set; }
        public DateTime DateBegin { get; set; }
        public bool IsActive { get; set; }
    }
}