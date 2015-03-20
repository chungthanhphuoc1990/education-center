using System.Data;
using LibDBConnect;

namespace LibDataLayer
{
    public static class DalGroupUser
    {
        private static readonly SqlHelper Cls = new SqlHelper();
        #region[Get-Data]
        public static DataTable GetGroupUser(string keywords)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("KEYWORDS", keywords);
            return Cls.GetData("sp_GroupUser_Get");
        }
        public static DataTable GetGroupUserEdit(int id)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", id);
            return Cls.GetData("sp_GroupUser_Get_Edit");
        }
        public static DataTable GetGroupUserFillterStatus(int IsActive)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("IsActive", IsActive);
            return Cls.GetData("sp_GroupUser_GetFillterStatus");
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOGroupUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Name", obj.Group_Name);
            Cls.AddParameter("Descripttion", obj.Descripttion);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_GroupUser_Insert");
            return true;
        }
        public static bool Update(DTOGroupUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("Group_Name", obj.Group_Name);
            Cls.AddParameter("Descripttion", obj.Descripttion);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_GroupUser_Update");
            return true;
        }
        public static bool Delete(DTOGroupUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", obj.Group_Id);
            obj.Msg = Cls.ExecuteNonQueryOutput("sp_GroupUser_Delete", "@Msg");
            return true;
        }
        public static bool UpdateNum(DTOGroupUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("Num", obj.Num);
            Cls.ExecuteNonQuery("sp_GroupUser_Update_Num");
            return true;
        }
        public static bool UpdateCheck(DTOGroupUser obj)
        {
            Cls.CreateNewSqlCommand();
            Cls.AddParameter("Group_Id", obj.Group_Id);
            Cls.AddParameter("IsActive", obj.IsActive);
            Cls.ExecuteNonQuery("sp_GroupUser_Update_Check");
            return true;
        }
        #endregion
    }

    public class DTOGroupUser
    {
        public int Group_Id { get; set; }
        public string Group_Name { get; set; }
        public string Descripttion { get; set; }
        public bool IsActive { get; set; }
        public int? Num { get; set; }
        public int Msg { get; set; }
    }
}