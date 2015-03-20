using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllNews
    {
        #region[Get-Data]
        public DataTable GetNews(string keywords)
        {
            return DalNews.GetNews(keywords);
        }
        public DataTable GetNewsEdit(int id)
        {
            return DalNews.GetNewsEdit(id);
        }
        public DataTable GetNewsFillter(int ID_CatalogMain)
        {
            return DalNews.GetNewsFillter(ID_CatalogMain);
        }
        public DataTable GetNewsFillterStatus(int IsActive)
        {
            return DalNews.GetNewsFillterStatus(IsActive);
        }
        public DataTable GetNewsFillterIsHot(int IsHot)
        {
            return DalNews.GetNewsFillterIsHot(IsHot);
        }
        public DataTable GetCatalogParrentMain(int ID_CatPrarent)
        {
            return DalNews.GetCatalogParrentMain(ID_CatPrarent);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONews obj)
        {
            DalNews.Insert(obj);
            return true;
        }
        public static bool Update(DTONews obj)
        {
            DalNews.Update(obj);
            return true;
        }
        public static bool Delete(DTONews obj)
        {
            DalNews.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTONews obj)
        {
            DalNews.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTONews obj)
        {
            DalNews.UpdateCheck(obj);
            return true;
        }
        public static bool UpdateIsHot(DTONews obj)
        {
            DalNews.UpdateIsHot(obj);
            return true;
        }
        public static bool UpdateIsSilde(DTONews obj)
        {
            DalNews.UpdateIsSilde(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetNewsHomePage(string keywords, int ID_CatPrarent)
        {
            return DalNews.GetNewsHomePage(keywords, ID_CatPrarent);
        }
        public DataTable GetNewsHomePageSlide(string keywords)
        {
            return DalNews.GetNewsHomePageSlide(keywords);
        }
        public DataTable GetNewsHomePageTitile(string keywords, string Friendly_Url)
        {
            return DalNews.GetNewsHomePageTitile(keywords, Friendly_Url);
        }
        public DataTable GetNewsHomePageDetail(string keywords, string Friendly_Url)
        {
            return DalNews.GetNewsHomePageDetail(keywords, Friendly_Url);
        }
        public DataTable GetNewsHomePageOrder(string keywords, string Friendly_Url)
        {
            return DalNews.GetNewsHomePageOrder(keywords, Friendly_Url);
        }
        #endregion
    }
}