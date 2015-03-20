using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllUtilitiesDetail
    {
        #region[Get-Data]
        public DataTable GetUtilitiesDetail(string keywords)
        {
            return DalUtilitiesDetail.GetUtilitiesDetail(keywords);
        }
        public DataTable GetUtilitiesDetailEdit(int id)
        {
            return DalUtilitiesDetail.GetUtilitiesDetailEdit(id);
        }
        public DataTable GetUtilitiesDetailFillter(int ID_CatalogMain)
        {
            return DalUtilitiesDetail.GetUtilitiesDetailFillter(ID_CatalogMain);
        }
        public DataTable GetUtilitiesDetailFillterStatus(int IsActive)
        {
            return DalUtilitiesDetail.GetUtilitiesDetailFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Insert(DTOUtilitiesDetail obj)
        {
            DalUtilitiesDetail.Insert(obj);
            return true;
        }
        public static bool Update(DTOUtilitiesDetail obj)
        {
            DalUtilitiesDetail.Update(obj);
            return true;
        }
        public static bool Delete(DTOUtilitiesDetail obj)
        {
            DalUtilitiesDetail.Delete(obj);
            return true;
        }
        public static bool UpdateNum(DTOUtilitiesDetail obj)
        {
            DalUtilitiesDetail.UpdateNum(obj);
            return true;
        }
        public static bool UpdateCheck(DTOUtilitiesDetail obj)
        {
            DalUtilitiesDetail.UpdateCheck(obj);
            return true;
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetUtilitiesDetailHome(string keywords, string Friendly_Url)
        {
            return DalUtilitiesDetail.GetUtilitiesDetailHome(keywords, Friendly_Url);
        }
        #endregion
    }
}
