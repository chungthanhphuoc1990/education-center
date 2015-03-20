using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllNewsChild
    {
        #region[Get-Data]
        public DataTable GetNewsChild(string keywords)
        {
            return DalNewsChild.GetNewsChild(keywords);
        }
        public DataTable GetNewsChildEdit(int id)
        {
            return DalNewsChild.GetNewsChildEdit(id);
        }
        public DataTable GetNewsChildFillter(int ID_CatalogMain)
        {
            return DalNewsChild.GetNewsChildFillter(ID_CatalogMain);
        }
        public DataTable GetNewsChildFillterStatus(int IsActive,int ID_Page)
        {
            return DalNewsChild.GetNewsChildFillterStatus(IsActive, ID_Page);
        }
        public DataTable GetNewsChildFillterIsHot(int IsHot,int ID_Page)
        {
            return DalNewsChild.GetNewsChildFillterIsHot(IsHot, ID_Page);
        }
        public DataTable GetCatalogParrentMain(int ID_CatPrarent)
        {
            return DalNewsChild.GetCatalogParrentMain(ID_CatPrarent);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONewsChild obj)
        {
            DalNewsChild.Insert(obj);
            return true;
        }
        public static bool Update(DTONewsChild obj)
        {
            DalNewsChild.Update(obj);
            return true;
        }
        public static bool Delete(DTONewsChild obj)
        {
            DalNewsChild.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTONewsChild obj)
        {
            DalNewsChild.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTONewsChild obj)
        {
            DalNewsChild.UpdateCheck(obj);
            return true;
        }
        public static bool UpdateIsHot(DTONewsChild obj)
        {
            DalNewsChild.UpdateIsHot(obj);
            return true;
        }
        public static bool UpdateIsSlide(DTONewsChild obj)
        {
            DalNewsChild.UpdateIsSlide(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetNewsChildHomePage(string keywords, int ID_CatPrarent)
        {
            return DalNewsChild.GetNewsChildHomePage(keywords, ID_CatPrarent);
        }
        public DataTable GetNewsChildHomePageTitile(int ID_Page,string keywords, string Friendly_Url)
        {
            return DalNewsChild.GetNewsChildHomePageTitile(ID_Page,keywords, Friendly_Url);
        }
        public DataTable GetNewsChildHomePageDetail(int ID_Page,string keywords, string Friendly_Url)
        {
            return DalNewsChild.GetNewsChildHomePageDetail(ID_Page,keywords, Friendly_Url);
        }
        public DataTable GetNewsChildHomePageOrder(int ID_Page, string keywords, string Friendly_Url)
        {
            return DalNewsChild.GetNewsChildHomePageOrder(ID_Page, keywords, Friendly_Url);
        }
        public DataTable GetNewsChildHomePageSlide(int ID_Page)
        {
            return DalNewsChild.GetNewsChildHomePageSlide(ID_Page);
        }
        #endregion
    }
}