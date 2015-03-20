using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllVideoChild
    {
        #region[Get-Data]
        public DataTable GetVideoChild(string keywords)
        {
            return DalVideoChild.GetVideoChild(keywords);
        }
        public DataTable GetVideoChildEdit(int id)
        {
            return DalVideoChild.GetVideoChildEdit(id);
        }
        public DataTable GetVideoChildFillter(int ID_Page)
        {
            return DalVideoChild.GetVideoChildFillter(ID_Page);
        }
        public DataTable GetVideoChildFillterStatus(int IsActive,int ID_Page)
        {
            return DalVideoChild.GetVideoChildFillterStatus(IsActive, ID_Page);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOVideoChild obj)
        {
            DalVideoChild.Insert(obj);
            return true;
        }
        public static bool Update(DTOVideoChild obj)
        {
            DalVideoChild.Update(obj);
            return true;
        }
        public static bool Delete(DTOVideoChild obj)
        {
            DalVideoChild.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOVideoChild obj)
        {
            DalVideoChild.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOVideoChild obj)
        {
            DalVideoChild.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetVideoChildHomePage(string keywords)
        {
            return DalVideoChild.GetVideoChildHomePage(keywords);
        }
        #endregion
    }
}
