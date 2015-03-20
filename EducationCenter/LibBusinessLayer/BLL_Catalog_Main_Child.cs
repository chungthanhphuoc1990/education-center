using System.Data;
using LibDataLayer;
namespace LibBusinessLayer
{
    public class BllCatalogMainChild
    {
        #region[Get-Data]
        public DataTable GetCatalogMain(string keywords)
        {
            return DalCatalogMainChild.GetCatalogMain(keywords);
        }
        public DataTable GetCatalogMainEdit(int id)
        {
            return DalCatalogMainChild.GetCatalogMainEdit(id);
        }
        public DataTable GetCatalogMainFillterStatus(int IsActive,int ID_Page)
        {
            return DalCatalogMainChild.GetCatalogMainFillterStatus(IsActive, ID_Page);
        }
        public DataTable GetCatalogMainFillterPage(int ID_Page)
        {
            return DalCatalogMainChild.GetCatalogMainFillterPage(ID_Page);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogMainChild obj)
        {
            DalCatalogMainChild.Insert(obj);
            return true;
        }
        public static bool Update(DTOCatalogMainChild obj)
        {
            DalCatalogMainChild.Update(obj);
            return true;
        }
        public static bool Delete(DTOCatalogMainChild obj)
        {
            DalCatalogMainChild.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOCatalogMainChild obj)
        {
            DalCatalogMainChild.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOCatalogMainChild obj)
        {
            DalCatalogMainChild.UpdateCheck(obj);
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogMainChild obj)
        {
            DalCatalogMainChild.UpdateIsShow(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetCatalogMainHomePage(int ID_Page)
        {
            return DalCatalogMainChild.GetCatalogMainHomePage(ID_Page);
        }
        public DataTable GetCatalogMainHomePageDetail(int ID_Page, string Friendly_Url_Vn)
        {
            return DalCatalogMainChild.GetCatalogMainHomePageDetail(ID_Page,Friendly_Url_Vn);
        }
        #endregion
    }
}