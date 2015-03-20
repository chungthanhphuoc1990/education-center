using System.Data;
using LibDataLayer;

namespace LibBusinessLayer
{
    public class BllPageSetting
    {
        #region[Get-Data]
        public DataTable GetPageSetting()
        {
            return DalPageSetting.GetPageSetting();
        }
        public DataTable GetPageSettingEdit(int ID_Page)
        {
            return DalPageSetting.GetPageSettingEdit(ID_Page);
        }
        #endregion

        #region[Update]
        public static bool Update(DTOPageSetting obj)
        {
            DalPageSetting.Update(obj);
            return true;
        }
        #endregion
    }
}