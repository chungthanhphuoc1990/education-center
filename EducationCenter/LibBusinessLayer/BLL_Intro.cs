using System.Data;
using LibDataLayer;
namespace LibBusinessLayer
{
    public class BllIntro
    {
        #region[Get-Data]
        public DataTable GetIntro(string keywords)
        {
            return DalIntro.GetIntro(keywords);
        }
        public DataTable GetIntroEdit(int id)
        {
            return DalIntro.GetIntroEdit(id);
        }
        public DataTable GetIntroFillterStatus(int IsActive)
        {
            return DalIntro.GetIntroFillterStatus(IsActive);
        }
        #endregion

        #region[Insert-Update-Delete]
        public static bool Update(DTOIntro obj)
        {
            return DalIntro.Update(obj);
        }
        public static bool Delete(DTOIntro obj)
        {
            return DalIntro.Delete(obj);
        }
        public static bool UpdateNum(DTOIntro obj)
        {
            return DalIntro.UpdateNum(obj);
        }
        public static bool UpdateCheck(DTOIntro obj)
        {
            return DalIntro.UpdateCheck(obj);
        }
        #endregion

        #region[Get-Data-HomePage]
        public DataTable GetIntroHomePage(string Position)
        {
            return DalIntro.GetIntroHomePage(Position);
        }
        public DataTable GetIntroHomePageDetail(string Friendly_Url_Vn)
        {
            return DalIntro.GetIntroHomePageDetail(Friendly_Url_Vn);
        }
        #endregion
    }
}