using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllGallery
    {
        #region[Get-Data]
        public DataTable GetGallery(string keywords)
        {
            return DalGallery.GetGallery(keywords);
        }
        public DataTable GetGalleryEdit(int id)
        {
            return DalGallery.GetGalleryEdit(id);
        }
        public DataTable GetGalleryFillterStatus(int IsActive)
        {
            return DalGallery.GetGalleryFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOGallery obj)
        {
            DalGallery.Insert(obj);
            return true;
        }
        public static bool Update(DTOGallery obj)
        {
            DalGallery.Update(obj);
            return true;
        }
        public static bool Delete(DTOGallery obj)
        {
            DalGallery.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOGallery obj)
        {
            DalGallery.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOGallery obj)
        {
            DalGallery.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetGalleryHomePage(string keywords)
        {
            return DalGallery.GetGalleryHomePage(keywords);
        }
        #endregion
    }
}
