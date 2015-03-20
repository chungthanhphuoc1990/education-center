using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllCatalogPrarentChild
    {
        #region[Get-Data]
        public DataTable GetCatalogPrarentChild(string keywords)
        {
            return DalCatalogPrarentChild.GetCatalogPrarentChild(keywords);
        }
        public DataTable GetCatalogPrarentChildEdit(int id)
        {
            return DalCatalogPrarentChild.GetCatalogPrarentChildEdit(id);
        }
        public DataTable GetCatalogPrarentChildFillter(int ID_CatalogMain)
        {
            return DalCatalogPrarentChild.GetCatalogPrarentChildFillter(ID_CatalogMain);
        }
        public DataTable GetCatalogPrarentChildFillterStatus(int IsActive,int ID_Page)
        {
            return DalCatalogPrarentChild.GetCatalogPrarentChildFillterStatus(IsActive, ID_Page);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOCatalogPrarentChild obj)
        {
            DalCatalogPrarentChild.Insert(obj);
            return true;
        }
        public static bool Update(DTOCatalogPrarentChild obj)
        {
            DalCatalogPrarentChild.Update(obj);
            return true;
        }
        public static bool Delete(DTOCatalogPrarentChild obj)
        {
            DalCatalogPrarentChild.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOCatalogPrarentChild obj)
        {
            DalCatalogPrarentChild.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOCatalogPrarentChild obj)
        {
            DalCatalogPrarentChild.UpdateCheck(obj);
            return true;
        }
        public static bool UpdateIsShow(DTOCatalogPrarentChild obj)
        {
            DalCatalogPrarentChild.UpdateIsShow(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetCatalogParrentHomePage(int ID_CatMain)
        {
            return DalCatalogPrarentChild.GetCatalogParrentHomePage(ID_CatMain);
        }
        public DataTable GetCatalogParrentHomePageDetail(int ID_Page,string Friendly_Url)
        {
            return DalCatalogPrarentChild.GetCatalogParrentHomePageDetail(ID_Page,Friendly_Url);
        }
        #endregion
    }
}