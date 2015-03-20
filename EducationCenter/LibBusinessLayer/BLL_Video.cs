using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllVideo
    {
        #region[Get-Data]
        public DataTable GetVideo(string keywords)
        {
            return DalVideo.GetVideo(keywords);
        }
        public DataTable GetVideoEdit(int id)
        {
            return DalVideo.GetVideoEdit(id);
        }
        public DataTable GetVideoFillterStatus(int IsActive)
        {
            return DalVideo.GetVideoFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOVideo obj)
        {
            DalVideo.Insert(obj);
            return true;
        }
        public static bool Update(DTOVideo obj)
        {
            DalVideo.Update(obj);
            return true;
        }
        public static bool Delete(DTOVideo obj)
        {
            DalVideo.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOVideo obj)
        {
            DalVideo.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOVideo obj)
        {
            DalVideo.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetVideoHomePage(string keywords)
        {
            return DalVideo.GetVideoHomePage(keywords);
        }
        #endregion
    }
}
