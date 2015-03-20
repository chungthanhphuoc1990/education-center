using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllCatalogPrarent
    {
        #region[Get-Data]
        public DataTable GetCatalogPrarent(string keywords)
        {
            return DalCatalogPrarent.GetCatalogPrarent(keywords);
        }
        public DataTable GetCatalogPrarentEdit(int id)
        {
            return DalCatalogPrarent.GetCatalogPrarentEdit(id);
        }
        public DataTable GetCatalogPrarentFillter(int ID_CatalogMain)
        {
            return DalCatalogPrarent.GetCatalogPrarentFillter(ID_CatalogMain);
        }
        public DataTable GetCatalogPrarentFillterStatus(int IsActive)
        {
            return DalCatalogPrarent.GetCatalogPrarentFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogPrarent obj)
        {
            DalCatalogPrarent.Insert(obj);
            return true;
        }
        public static bool Update(DTOCatalogPrarent obj)
        {
            DalCatalogPrarent.Update(obj);
            return true;
        }
        public static bool Delete(DTOCatalogPrarent obj)
        {
            DalCatalogPrarent.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOCatalogPrarent obj)
        {
            DalCatalogPrarent.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOCatalogPrarent obj)
        {
            DalCatalogPrarent.UpdateCheck(obj);
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogPrarent obj)
        {
            DalCatalogPrarent.UpdateIsShow(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetCatalogParrentHomePage(int ID_CatMain)
        {
            return DalCatalogPrarent.GetCatalogParrentHomePage(ID_CatMain);
        }
        public DataTable GetCatalogParrentHomePageDetail(string Friendly_Url)
        {
            return DalCatalogPrarent.GetCatalogParrentHomePageDetail(Friendly_Url);
        }
        #endregion
    }
}