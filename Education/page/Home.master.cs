using System;
using System.Web;
using LibBusinessLayer;

namespace page
{
    public partial class page_Home : System.Web.UI.MasterPage
    {
        #region[Define]
        protected string _htmCatalog = string.Empty;
        protected string _htmlTitilePage = string.Empty;
        protected string _htmlFooterPage = string.Empty;
        protected string _htmlFooterBottomPage = string.Empty;
        protected string _htmSlideShow = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            FormMasterHome.Action = Request.RawUrl;
            _htmCatalog = GetCatalogVn();
            _htmlTitilePage = GetLogoVn();
            _htmlFooterPage = GetFooterTop();
            _htmlFooterBottomPage = GetFooterBottom();
            _htmSlideShow = GetSlide();
            btnLanVn.Visible = false;
            var cookie = Request.Cookies["CurrentLanguage"];
            if (!IsPostBack && cookie != null && cookie.Value != null)
            {
                if (cookie.Value == "vn")
                {
                    FormMasterHome.Action = Request.RawUrl;
                    btnLanVn.Visible = false;
                    btnLanEn.Visible = true;
                   
                    _htmCatalog = GetCatalogVn();
                    _htmlTitilePage = GetLogoVn();
                    _htmlFooterPage = GetFooterTop();
                    _htmlFooterBottomPage = GetFooterBottom();
                }
                else
                {
                    FormMasterHome.Action = Request.RawUrl;
                    btnLanVn.Visible = true;
                    btnLanEn.Visible = false;

                    _htmCatalog = GetCatalogEn();
                    _htmlTitilePage = GetLogoEn();
                    _htmlFooterPage = GetFooterTop();
                    _htmlFooterBottomPage = GetFooterBottom();
                }
            }
        }
        protected void btnLanVn_Click(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("CurrentLanguage") {Value = "vn"};
            Response.SetCookie(cookie);
            Response.Redirect(Request.RawUrl);
        }
        protected void btnLanEn_Click(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("CurrentLanguage") { Value = "en-US" };
            Response.SetCookie(cookie);
            Response.Redirect(Request.RawUrl);
        }
        #endregion

        #region[Method]
        private string GetCatalogVn()
        {
            string _html = string.Empty;
            var _clsGetCatalogMain = new BllCatalogMain();
            var _clsGetCatalogParrent = new BllCatalogPrarent();
            var _dtGetCatlogMain = _clsGetCatalogMain.GetCatalogMainHomePage(string.Empty);
            if (_dtGetCatlogMain != null && _dtGetCatlogMain.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGetCatlogMain.Rows.Count; i++)
                {
                    if (i == 9)
                        break;
                    var _dtGetCatalogParrent =
                        _clsGetCatalogParrent.GetCatalogParrentHomePage(
                            int.Parse(_dtGetCatlogMain.Rows[i]["ID_CatMain"].ToString()));
                    if (_dtGetCatalogParrent != null && _dtGetCatalogParrent.Rows.Count > 0)
                    {
                        _html += "<li class='dropdown'>";
                        _html +=
                            "<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'>" +
                            _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_Vn"] + "<span class='caret'></span></a>";
                        _html += "<ul class='dropdown-menu' role='menu'>";
                        for (int j = 0; j < _dtGetCatalogParrent.Rows.Count; j++)
                        {
                            _html += "<li>";
                            //Detail
                            if (_dtGetCatalogParrent.Rows[j]["ShortContent_Vn"].ToString() != string.Empty ||
                             _dtGetCatalogParrent.Rows[j]["ShortContent_En"].ToString() != string.Empty ||
                             _dtGetCatalogParrent.Rows[j]["Descriptions_Vn"].ToString() != string.Empty ||
                             _dtGetCatalogParrent.Rows[j]["Descriptions_En"].ToString() != string.Empty)
                            {
                                _html += "<a href='/detail/" + _dtGetCatalogParrent.Rows[j]["Friendly_Url_Vn"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_Vn"] + "</span></a>";
                            }
                            else
                            {
                                if (_dtGetCatalogParrent.Rows[j]["Url"].ToString() == string.Empty ||
                                    _dtGetCatalogParrent.Rows[j]["Url"] == DBNull.Value)
                                {
                                    if ((bool) _dtGetCatlogMain.Rows[i]["IsGrid"])
                                    {
                                        _html += "<a href='/news-thumb/" + _dtGetCatalogParrent.Rows[j]["Friendly_Url_Vn"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_Vn"] + "</span></a>";
                                    }
                                    else
                                    {
                                        _html += "<a href='/news/" + _dtGetCatalogParrent.Rows[j]["Friendly_Url_Vn"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_Vn"] + "</span></a>";
                                    }
                                }
                                else
                                {
                                    _html += "<a href='" + _dtGetCatalogParrent.Rows[j]["Url"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_Vn"] + "</span></a>";
                                }
                            }
                            _html += "</li>";
                        }
                        _html += "</ul>";
                        _html += "</li>";
                    }
                    else
                    {
                        _html += "<li>";
                        if (String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["ShortContent_Vn"].ToString())
                            || String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["ShortContent_En"].ToString())
                            || String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["Descriptions_Vn"].ToString())
                            || String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["Descriptions_En"].ToString()))
                        {
                            if (String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["Url"].ToString()))
                            {
                                _html += "<a href='/'>";
                                _html += _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_Vn"];
                                _html += "</a>";
                            }
                            else
                            {
                                _html += "<a href='" + _dtGetCatlogMain.Rows[i]["Url"] + "'>";
                                _html += _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_Vn"];
                                _html += "</a>";
                            }

                        }
                        else
                        {
                            _html += "<a href='/detail/" + _dtGetCatlogMain.Rows[i]["Friendly_Url_Vn"] + "'>";
                            _html += _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_Vn"];
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                }
            }
            return _html;
        }
        private string GetCatalogEn()
        {
            string _html = string.Empty;
            var _clsGetCatalogMain = new BllCatalogMain();
            var _clsGetCatalogParrent = new BllCatalogPrarent();
            var _dtGetCatlogMain = _clsGetCatalogMain.GetCatalogMainHomePage(string.Empty);
            if (_dtGetCatlogMain != null && _dtGetCatlogMain.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGetCatlogMain.Rows.Count; i++)
                {
                    if (i == 9)
                        break;
                    var _dtGetCatalogParrent =
                        _clsGetCatalogParrent.GetCatalogParrentHomePage(
                            int.Parse(_dtGetCatlogMain.Rows[i]["ID_CatMain"].ToString()));
                    if (_dtGetCatalogParrent != null && _dtGetCatalogParrent.Rows.Count > 0)
                    {
                        _html += "<li class='dropdown'>";
                        _html +=
                            "<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'>" +
                            _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_En"] + "<span class='caret'></span></a>";
                        _html += "<ul class='dropdown-menu' role='menu'>";
                        for (int j = 0; j < _dtGetCatalogParrent.Rows.Count; j++)
                        {
                            _html += "<li>";
                            //Detail
                            if (_dtGetCatalogParrent.Rows[j]["ShortContent_En"].ToString() != string.Empty ||
                             _dtGetCatalogParrent.Rows[j]["ShortContent_En"].ToString() != string.Empty ||
                             _dtGetCatalogParrent.Rows[j]["Descriptions_En"].ToString() != string.Empty ||
                             _dtGetCatalogParrent.Rows[j]["Descriptions_En"].ToString() != string.Empty)
                            {
                                _html += "<a href='/detail/" + _dtGetCatalogParrent.Rows[j]["Friendly_Url_En"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_En"] + "</span></a>";
                            }
                            else
                            {
                                if (_dtGetCatalogParrent.Rows[j]["Url"].ToString() == string.Empty ||
                               _dtGetCatalogParrent.Rows[j]["Url"] == DBNull.Value)
                                {
                                    if ((bool)_dtGetCatlogMain.Rows[i]["IsGrid"])
                                    {
                                        _html += "<a href='/news-thumb/" + _dtGetCatalogParrent.Rows[j]["Friendly_Url_Vn"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_En"] + "</span></a>";
                                    }
                                    else
                                    {
                                        _html += "<a href='/news/" + _dtGetCatalogParrent.Rows[j]["Friendly_Url_Vn"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_En"] + "</span></a>";
                                    }
                                }
                                else
                                {
                                    _html += "<a href='" + _dtGetCatalogParrent.Rows[j]["Url"] + "'><span>" + _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_En"] + "</span></a>";
                                }
                            }
                            _html += "</li>";
                        }
                        _html += "</ul>";
                        _html += "</li>";
                    }
                    else
                    {
                        _html += "<li>";
                        if (String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["ShortContent_En"].ToString())
                            || String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["ShortContent_En"].ToString())
                            || String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["Descriptions_En"].ToString())
                            || String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["Descriptions_En"].ToString()))
                        {
                            if (String.IsNullOrEmpty(_dtGetCatlogMain.Rows[i]["Url"].ToString()))
                            {
                                _html += "<a href='/'>";
                                _html += _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_En"];
                                _html += "</a>";
                            }
                            else
                            {
                                _html += "<a href='" + _dtGetCatlogMain.Rows[i]["Url"] + "'>";
                                _html += _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_En"];
                                _html += "</a>";
                            }

                        }
                        else
                        {
                            _html += "<a href='/detail/" + _dtGetCatlogMain.Rows[i]["Friendly_Url_En"] + "'>";
                            _html += _dtGetCatlogMain.Rows[i]["Catalog_Main_Titile_En"];
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                }
            }
            return _html;
        }
        private string GetLogoVn()
        {
            var _html = string.Empty;
            var _clsGetPage = new BllPageSetting();
            var _dtGetPage = _clsGetPage.GetPageSetting();
            if (_dtGetPage != null && _dtGetPage.Rows.Count > 0)
            {
                _html += "<div class='col-sm-12 col-md-6 col-lg-4'>";
                    _html += "<a href='/'>";
                        _html += "<img alt='" + _dtGetPage.Rows[0]["Page_Titile"] + "' src='" +
                         _dtGetPage.Rows[0]["Page_Logo"] +
                         "'style='margin-left: 80px; margin-top: 14px;'/>";
                    _html += "</a>";
                _html += "</div>";

                _html += "<div id='hide'>";
                    _html += "<a href='/'>";
                    _html += "<img alt='" + _dtGetPage.Rows[0]["Page_Titile"] + "' src='" +
                         _dtGetPage.Rows[0]["Page_Banner"] +
                         "'style='margin-left: -175px; margin-top: 35px;'/>";
                    _html += "</a>";
                _html += "</div>";                
            }
            return _html;
        }
        private string GetLogoEn()
        {
            var _html = string.Empty;
            var _clsGetPage = new BllPageSetting();
            var _dtGetPage = _clsGetPage.GetPageSetting();
            if (_dtGetPage != null && _dtGetPage.Rows.Count > 0)
            {
                _html += "<div class='col-sm-12 col-md-6 col-lg-4'>";
                _html += "<a href='/'>";
                _html += "<img alt='" + _dtGetPage.Rows[0]["Page_Titile"] + "' src='" +
                           _dtGetPage.Rows[0]["Page_Logo"] + "'style='margin-left: 80px; margin-top: 14px;'/>";
                _html += "</a>";
                _html += "</div>";

                _html += "<div id='hide'>";
                _html += "<a href='/'>";
                _html += "<img alt='" + _dtGetPage.Rows[0]["Page_Titile"] + "' src='" +
                           _dtGetPage.Rows[0]["Page_Icon"] + "'style='margin-left: -175px; margin-top: 35px;'/>";
                _html += "</a>";
                _html += "</div>";
            }
            return _html;
        }
        private string GetFooterTop()
        {
            var _html = string.Empty;
            var _clsGetFooter = new BllPageSetting();
            var _dtGetFooter = _clsGetFooter.GetPageSetting();
            if (_dtGetFooter != null && _dtGetFooter.Rows.Count > 0)
            {
                _html += "<p style='font-size: 11px;color: #777;  float: left;line-height: 18px;'>";
                _html += _dtGetFooter.Rows[0]["Page_Footer"].ToString();
                _html += "</p>";
            }
            return _html;
        }
        private string GetFooterBottom()
        {
            var _html = string.Empty;
            var _clsGetFooter = new BllPageSetting();
            var _dtGetFooterBottom = _clsGetFooter.GetPageSetting();
            if (_dtGetFooterBottom != null && _dtGetFooterBottom.Rows.Count > 0)
            {
                _html += "<p style='padding-top: 7px'>";
                _html += _dtGetFooterBottom.Rows[0]["Page_Footer"].ToString();
                _html += "</p>";
            }
            return _html;
        }
        private string GetSlide()
        {
            string _html = string.Empty;
            var _clsGetSlide = new BllNews();
            var _dtGetSlide = _clsGetSlide.GetNewsHomePageSlide(string.Empty);
            if (_dtGetSlide != null && _dtGetSlide.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGetSlide.Rows.Count; i++)
                {
                    if ((bool)_dtGetSlide.Rows[i]["IsSlide"])
                    {
                        _html += "<div class='item'>";
                            _html += "<a href='/detail/" + _dtGetSlide.Rows[i]["Friendly_Url_Vn"] + "'title='" +
                                     _dtGetSlide.Rows[i]["Titile_Vn"] +
                                     "' target='_blank'>";
                            _html += "<img src='" + _dtGetSlide.Rows[i]["Img"] + "' style='width: " +
                                     _dtGetSlide.Rows[i]["Width"] + "%" + ";height:" +
                                     _dtGetSlide.Rows[i]["Height"] + "px'/>";

                            _html += "</a>";
                        _html += "</div>";
                    }
                }
            }
            return _html;
        }
        #endregion
    }
}