using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllGalleryDetail
    {
        #region[Get-Data]
        public DataTable GetGalleryDetail(string keywords)
        {
            return DalGalleryDetail.GetGalleryDetail(keywords);
        }
        public DataTable GetGalleryDetailEdit(int id)
        {
            return DalGalleryDetail.GetGalleryDetailEdit(id);
        }
        public DataTable GetGalleryDetailFillter(int ID_CatalogMain)
        {
            return DalGalleryDetail.GetGalleryDetailFillter(ID_CatalogMain);
        }
        public DataTable GetGalleryDetailFillterStatus(int IsActive)
        {
            return DalGalleryDetail.GetGalleryDetailFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOGalleryDetail obj)
        {
            DalGalleryDetail.Insert(obj);
            return true;
        }
        public static bool Update(DTOGalleryDetail obj)
        {
            DalGalleryDetail.Update(obj);
            return true;
        }
        public static bool Delete(DTOGalleryDetail obj)
        {
            DalGalleryDetail.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOGalleryDetail obj)
        {
            DalGalleryDetail.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOGalleryDetail obj)
        {
            DalGalleryDetail.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetGalleryDetailHomePage(int ID_Gallery)
        {
            return DalGalleryDetail.GetGalleryDetailHomePage(ID_Gallery);
        }
        public DataTable GetGalleryDetailHomePageShowAll()
        {
            return DalGalleryDetail.GetGalleryDetailHomePageShowAll();
        }
        #endregion
    }
}