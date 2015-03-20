using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllPage
    {
        #region[Get-Data]
        public DataTable GetPage(string keywords)
        {
            return DalPage.GetPage(keywords);
        }
        public DataTable GetPageEdit(int id)
        {
            return DalPage.GetPageEdit(id);
        }
        public DataTable GetPageFillterStatus(int IsActive)
        {
            return DalPage.GetPageFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOPage obj)
        {
            DalPage.Insert(obj);
            return true;
        }
        public static bool Update(DTOPage obj)
        {
            DalPage.Update(obj);
            return true;
        }
        public static bool Delete(DTOPage obj)
        {
            DalPage.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOPage obj)
        {
            DalPage.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOPage obj)
        {
            DalPage.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetPageHomePage(int ID_Page)
        {
            return DalPage.GetPageHomePage(ID_Page);
        }
        #endregion
    }
}
