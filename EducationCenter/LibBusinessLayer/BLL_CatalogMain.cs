using System.Data;
using LibDataLayer;
namespace LibBusinessLayer
{
    public class BllCatalogMain
    {
        #region[Get-Data]
        public DataTable GetCatalogMain(string keywords)
        {
            return DalCatalogMain.GetCatalogMain(keywords);
        }
        public DataTable GetCatalogMainEdit(int id)
        {
            return DalCatalogMain.GetCatalogMainEdit(id);
        }
        public DataTable GetCatalogMainFillterStatus(int IsActive)
        {
            return DalCatalogMain.GetCatalogMainFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogMain obj)
        {
            DalCatalogMain.Insert(obj);
            return true;
        }
        public static bool Update(DTOCatalogMain obj)
        {
            DalCatalogMain.Update(obj);
            return true;
        }
        public static bool Delete(DTOCatalogMain obj)
        {
            DalCatalogMain.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOCatalogMain obj)
        {
            DalCatalogMain.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOCatalogMain obj)
        {
            DalCatalogMain.UpdateCheck(obj);
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogMain obj)
        {
            DalCatalogMain.UpdateIsShow(obj);
            return true;
        }
        public static bool UpdateIsGrid(DTOCatalogMain obj)
        {
            DalCatalogMain.UpdateIsGrid(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetCatalogMainHomePage(string keywords)
        {
            return DalCatalogMain.GetCatalogMainHomePage(keywords);
        }
        public DataTable GetCatalogMainHomePageDetail(string Friendly_Url_Vn)
        {
            return DalCatalogMain.GetCatalogMainHomePageDetail(Friendly_Url_Vn);
        }
        public DataTable GetCatalogMainHomePageDetail1(string Friendly_Url_Vn)
        {
            return DalCatalogMain.GetCatalogMainHomePageDetail1(Friendly_Url_Vn);
        }
        #endregion
    }
}