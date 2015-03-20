using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllNotifyDetail
    {
        #region[Get-Data]
        public DataTable GetNotifyDetail(string keywords)
        {
            return DalNotifyDetail.GetNotifyDetail(keywords);
        }
        public DataTable GetNotifyDetailEdit(int id)
        {
            return DalNotifyDetail.GetNotifyDetailEdit(id);
        }
        public DataTable GetNotifyDetailFillter(int ID_CatalogMain)
        {
            return DalNotifyDetail.GetNotifyDetailFillter(ID_CatalogMain);
        }
        public DataTable GetNotifyDetailFillterStatus(int IsActive)
        {
            return DalNotifyDetail.GetNotifyDetailFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONotifyDetail obj)
        {
            DalNotifyDetail.Insert(obj);
            return true;
        }
        public static bool Update(DTONotifyDetail obj)
        {
            DalNotifyDetail.Update(obj);
            return true;
        }
        public static bool Delete(DTONotifyDetail obj)
        {
            DalNotifyDetail.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTONotifyDetail obj)
        {
            DalNotifyDetail.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTONotifyDetail obj)
        {
            DalNotifyDetail.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetNotifyDetailHomePage(int ID_Notify)
        {
            return DalNotifyDetail.GetNotifyDetailHomePage(ID_Notify);
        }
        public DataTable GetNotifyDetailHomePageDetail(string Friendly_Url)
        {
            return DalNotifyDetail.GetNotifyDetailHomePageDetail(Friendly_Url);
        }
        public DataTable GetNotifyDetailHomePageOrder(string keywords, string Friendly_Url)
        {
            return DalNotifyDetail.GetNotifyDetailHomePageOrder(keywords, Friendly_Url);
        }
        #endregion
    }
}
