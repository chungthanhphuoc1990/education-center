using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllNotifyChild
    {
        #region[Get-Data]
        public DataTable GetNotifyChild(string keywords)
        {
            return DalNotifyChild.GetNotifyChild(keywords);
        }
        public DataTable GetNotifyChildEdit(int id)
        {
            return DalNotifyChild.GetNotifyChildEdit(id);
        }
        public DataTable GetNotifyChildFillter(int ID_CatalogMain)
        {
            return DalNotifyChild.GetNotifyChildFillter(ID_CatalogMain);
        }
        public DataTable GetNotifyChildFillterStatus(int IsActive,int ID_Page)
        {
            return DalNotifyChild.GetNotifyChildFillterStatus(IsActive, ID_Page);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTONotifyChild obj)
        {
            DalNotifyChild.Insert(obj);
            return true;
        }
        public static bool Update(DTONotifyChild obj)
        {
            DalNotifyChild.Update(obj);
            return true;
        }
        public static bool Delete(DTONotifyChild obj)
        {
            DalNotifyChild.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTONotifyChild obj)
        {
            DalNotifyChild.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTONotifyChild obj)
        {
            DalNotifyChild.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetNotifyChildHomePage(int ID_Page)
        {
            return DalNotifyChild.GetNotifyChildHomePage(ID_Page);
        }
        public DataTable GetNotifyChildHomePageDetail(int ID_Page,string Friendly_Url)
        {
            return DalNotifyChild.GetNotifyChildHomePageDetail(ID_Page,Friendly_Url);
        }
        public DataTable GetNotifyChildHomePageOrder(int ID_Page, string Friendly_Url)
        {
            return DalNotifyChild.GetNotifyChildHomePageOrder(ID_Page, Friendly_Url);
        }
        #endregion
    }
}