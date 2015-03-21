using System;
using System.Web.UI.HtmlControls;
using LibBusinessLayer;

namespace page
{
    public partial class page_info : System.Web.UI.Page
    {
        #region[Define]
        protected string _htmlDetail = string.Empty;
        private const int _maxLength = 90;
        protected string _htmlGetMenu = string.Empty;
        protected int _htmlIDMenuParrent = 0;
        protected string _htmlTitile = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["CurrentLanguage"];
            _htmlGetMenu = GetMenuVn();
            if (!IsPostBack && cookie != null && cookie.Value != null && Request.Params["id"] != null)
            {
                _htmlDetail = GetDetailVn(Request.Params["id"]);
                if (cookie.Value == "vn")
                {
                    _htmlDetail = GetDetailVn(Request.Params["id"]);
                    _htmlGetMenu = GetMenuVn();
                }
                else
                {
                    _htmlDetail = GetDetailEn(Request.Params["id"]);
                    _htmlGetMenu = GetMenuEn();
                }
            }
        }
        #endregion

        #region[Method]
        private string GetDetailVn(string Friendly_Url)
        {
            var _html = string.Empty;
            var _clsGetNewsDetail = new BllNews();
            var _clsGetParrentDetail = new BllCatalogPrarent();
            var _clsGetCatalogDetail = new BllCatalogMain();
            var _dtGetNewDetail = _clsGetNewsDetail.GetNewsHomePageDetail(string.Empty, Friendly_Url);
            var _dtGetNewOrder = _clsGetNewsDetail.GetNewsHomePageOrder(string.Empty, Friendly_Url);
            var _dtGetParrentDetail = _clsGetParrentDetail.GetCatalogParrentHomePageDetail(Friendly_Url);
            var _dtGetCatalogDetail = _clsGetCatalogDetail.GetCatalogMainHomePageDetail(Friendly_Url);
            #region[GetNewsDetail]
            if (_dtGetNewDetail != null && _dtGetNewDetail.Rows.Count > 0)
            {
                Page.Title = _dtGetNewDetail.Rows[0]["Titile_Vn"].ToString();
                _htmlTitile = _dtGetNewDetail.Rows[0]["Catalog_Prarent_Titile_Vn"].ToString();
                _htmlIDMenuParrent = int.Parse(_dtGetNewDetail.Rows[0]["ID_CatMain"].ToString());
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetNewDetail.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetNewDetail.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                _html += "<div class='col-md-12'>";
                    _html += "<div class='titile-news'>";
                        _html += _dtGetNewDetail.Rows[0]["Titile_Vn"].ToString();
                    _html += "</div>";
                        _html += "<p class='short-content-news'>";
                            _html += _dtGetNewDetail.Rows[0]["Descriptions_Vn"].ToString();
                        _html += "</p>";
                _html += "<div class='clr'></div>";
                _html += "<hr class='hr'/>";
                _html += "<div class='order-new-titile'>";
                if (_dtGetNewOrder != null && _dtGetNewOrder.Rows.Count > 0)
                {
                    _html += "<h2 class='order-new-titile'>Bài viết liên quan</h2>";
                    for (int i = 0; i < _dtGetNewOrder.Rows.Count; i++)
                    {
                        if (i == 10)
                            break;
                        if (_dtGetNewOrder.Rows[i]["Titile_Vn"].ToString().Length >= _maxLength)
                        {
                            _html += "<a data-toggle='tooltip' data-placement='bottom' title='" + _dtGetNewOrder.Rows[i]["Titile_Vn"] + "' href='/detail/" + _dtGetNewOrder.Rows[i]["Friendly_Url_Vn"] + "' class='order-news-titile-link'>";
                            _html +=
                                "<img src='../img/red-next-icon.png' style='width: 12px;margin-right:5px;vertical-align: initial'/>";
                            _html += _dtGetNewOrder.Rows[i]["Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/detail/" + _dtGetNewOrder.Rows[i]["Friendly_Url_Vn"] + "' class='order-news-titile-link'>";
                            _html +=
                                "<img src='../img/red-next-icon.png' style='width: 12px;margin-right:5px;vertical-align: initial'/>";
                            _html += _dtGetNewOrder.Rows[i]["Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                    }
                }
                _html += "</div>";
            }
            #endregion
            #region[GetCatalogParrent]
            else if (_dtGetParrentDetail != null && _dtGetParrentDetail.Rows.Count > 0)
            {
                Page.Title = _dtGetParrentDetail.Rows[0]["Catalog_Prarent_Titile_Vn"].ToString();
                _htmlTitile = _dtGetParrentDetail.Rows[0]["Catalog_Prarent_Titile_Vn"].ToString();
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetParrentDetail.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetParrentDetail.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                _htmlIDMenuParrent = int.Parse(_dtGetParrentDetail.Rows[0]["ID_CatMain"].ToString());
                _html += "<div class='col-md-12'>";
                _html += "<div class='titile-news'>";
                _html += _dtGetParrentDetail.Rows[0]["Catalog_Prarent_Titile_Vn"].ToString();
                _html += "</div>";
                _html += "<p class='short-content-news'>";
                _html += _dtGetParrentDetail.Rows[0]["Descriptions_Vn"].ToString();
                _html += "</p>";
                _html += "<div class='clr'></div>";
            }
            #endregion
            #region[GetCatalogMain]
            else if (_dtGetCatalogDetail != null && _dtGetCatalogDetail.Rows.Count > 0)
            {
                Page.Title = _dtGetCatalogDetail.Rows[0]["Catalog_Main_Titile_Vn"].ToString();
                _htmlTitile = _dtGetCatalogDetail.Rows[0]["Catalog_Prarent_Titile_Vn"].ToString();
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetCatalogDetail.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetCatalogDetail.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                _htmlIDMenuParrent = int.Parse(_dtGetCatalogDetail.Rows[0]["ID_CatMain"].ToString());
                _html += "<div class='col-md-12'>";
                _html += "<div class='titile-news'>";
                _html += _dtGetCatalogDetail.Rows[0]["Catalog_Main_Titile_Vn"].ToString();
                _html += "</div>";
                _html += "<p class='short-content-news'>";
                _html += _dtGetCatalogDetail.Rows[0]["Descriptions_Vn"].ToString();
                _html += "</p>";
                _html += "<div class='clr'></div>";
            }
            #endregion
            return _html;
        }
        private string GetDetailEn(string Friendly_Url)
        {
            var _html = string.Empty;
            var _clsGetNewsDetail = new BllNews();
            var _clsGetParrentDetail = new BllCatalogPrarent();
            var _clsGetCatalogDetail = new BllCatalogMain();
            var _dtGetNewDetail = _clsGetNewsDetail.GetNewsHomePageDetail(string.Empty, Friendly_Url);
            var _dtGetNewOrder = _clsGetNewsDetail.GetNewsHomePageOrder(string.Empty, Friendly_Url);
            var _dtGetParrentDetail = _clsGetParrentDetail.GetCatalogParrentHomePageDetail(Friendly_Url);
            var _dtGetCatalogDetail = _clsGetCatalogDetail.GetCatalogMainHomePageDetail(Friendly_Url);
            #region[GetNewsDetail]
            if (_dtGetNewDetail != null && _dtGetNewDetail.Rows.Count > 0)
            {
                Page.Title = _dtGetNewDetail.Rows[0]["Titile_En"].ToString();
                _htmlTitile = _dtGetNewDetail.Rows[0]["Catalog_Prarent_Titile_En"].ToString();
                _htmlIDMenuParrent = int.Parse(_dtGetNewDetail.Rows[0]["ID_CatMain"].ToString());
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetNewDetail.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetNewDetail.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                _html += "<div class='col-md-12'>";
                _html += "<div class='titile-news'>";
                _html += _dtGetNewDetail.Rows[0]["Titile_En"].ToString();
                _html += "</div>";
                _html += "<p class='short-content-news'>";
                _html += _dtGetNewDetail.Rows[0]["Descriptions_En"].ToString();
                _html += "</p>";
                _html += "<div class='clr'></div>";
                _html += "<hr class='hr'/>";
                _html += "<div class='order-new-titile'>";
                if (_dtGetNewOrder != null && _dtGetNewOrder.Rows.Count > 0)
                {
                    _html += "<h2 class='order-new-titile'>Bài viết liên quan</h2>";
                    for (int i = 0; i < _dtGetNewOrder.Rows.Count; i++)
                    {
                        if (i == 10)
                            break;
                        if (_dtGetNewOrder.Rows[i]["Titile_En"].ToString().Length >= _maxLength)
                        {
                            _html += "<a data-toggle='tooltip' data-placement='bottom' title='" + _dtGetNewOrder.Rows[i]["Titile_En"] + "' href='/detail/" + _dtGetNewOrder.Rows[i]["Friendly_Url_Vn"] + "' class='order-news-titile-link'>";
                            _html +=
                                "<img src='../img/red-next-icon.png' style='width: 12px;margin-right:5px;vertical-align: initial'/>";
                            _html += _dtGetNewOrder.Rows[i]["Titile_En"].ToString();
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/detail/" + _dtGetNewOrder.Rows[i]["Friendly_Url_Vn"] + "' class='order-news-titile-link'>";
                            _html +=
                                "<img src='../img/red-next-icon.png' style='width: 12px;margin-right:5px;vertical-align: initial'/>";
                            _html += _dtGetNewOrder.Rows[i]["Titile_En"].ToString();
                            _html += "</a>";
                        }
                    }
                }
                _html += "</div>";
            }
            #endregion
            #region[GetCatalogParrent]
            else if (_dtGetParrentDetail != null && _dtGetParrentDetail.Rows.Count > 0)
            {
                Page.Title = _dtGetParrentDetail.Rows[0]["Catalog_Prarent_Titile_En"].ToString();
                _htmlTitile = _dtGetParrentDetail.Rows[0]["Catalog_Prarent_Titile_En"].ToString();
                _htmlIDMenuParrent = int.Parse(_dtGetParrentDetail.Rows[0]["ID_CatMain"].ToString());
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetParrentDetail.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetParrentDetail.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                _html += "<div class='col-md-12'>";
                _html += "<div class='titile-news'>";
                _html += _dtGetParrentDetail.Rows[0]["Catalog_Prarent_Titile_En"].ToString();
                _html += "</div>";
                _html += "<p class='short-content-news'>";
                _html += _dtGetParrentDetail.Rows[0]["Descriptions_En"].ToString();
                _html += "</p>";
                _html += "<div class='clr'></div>";
            }
            #endregion
            #region[GetCatalogMain]
            else if (_dtGetCatalogDetail != null && _dtGetCatalogDetail.Rows.Count > 0)
            {
                Page.Title = _dtGetCatalogDetail.Rows[0]["Catalog_Main_Titile_En"].ToString();
                _htmlTitile = _dtGetCatalogDetail.Rows[0]["Catalog_Prarent_Titile_En"].ToString();
                _htmlIDMenuParrent = int.Parse(_dtGetCatalogDetail.Rows[0]["ID_CatMain"].ToString());
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetCatalogDetail.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetCatalogDetail.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                _html += "<div class='col-md-12'>";
                _html += "<div class='titile-news'>";
                _html += _dtGetCatalogDetail.Rows[0]["Catalog_Main_Titile_En"].ToString();
                _html += "</div>";
                _html += "<p class='short-content-news'>";
                _html += _dtGetCatalogDetail.Rows[0]["Descriptions_En"].ToString();
                _html += "</p>";
                _html += "<div class='clr'></div>";
            }
            #endregion
            return _html;
        }
        private string GetMenuVn()
        {
            var _html = string.Empty;
            var _clsGetCatalogParrent = new BllCatalogPrarent();
            var _dtGetCatalogParrent = _clsGetCatalogParrent.GetCatalogParrentHomePage(_htmlIDMenuParrent);
            if (_dtGetCatalogParrent != null && _dtGetCatalogParrent.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGetCatalogParrent.Rows.Count; i++)
                {
                    if (_dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString() == _htmlTitile)
                    {
                        _html += "<li class='active' role='presentation'>";
                        if ((bool) _dtGetCatalogParrent.Rows[i]["IsGrid"])
                        {
                            _html += "<a href='/news-thumb/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_Vn"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/news/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_Vn"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                    else
                    {
                        _html += "<li role='presentation'>";
                        if ((bool) _dtGetCatalogParrent.Rows[i]["IsGrid"])
                        {
                            _html += "<a href='/news-thumb/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_Vn"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/news/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_Vn"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                }
            }
            return _html;
        }
        private string GetMenuEn()
        {
            var _html = string.Empty;
            var _clsGetCatalogParrent = new BllCatalogPrarent();
            var _dtGetCatalogParrent = _clsGetCatalogParrent.GetCatalogParrentHomePage(_htmlIDMenuParrent);
            if (_dtGetCatalogParrent != null && _dtGetCatalogParrent.Rows.Count > 0)
            {
                for (int i = 0; i < _dtGetCatalogParrent.Rows.Count; i++)
                {
                    if (_dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString() == _htmlTitile)
                    {
                        _html += "<li class='active' role='presentation'>";
                        if ((bool) _dtGetCatalogParrent.Rows[i]["IsGrid"])
                        {
                            _html += "<a href='/news-thumb/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_En"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString();
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/news/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_En"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString();
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                    else
                    {
                        _html += "<li role='presentation'>";
                        if ((bool) _dtGetCatalogParrent.Rows[i]["IsGrid"])
                        {
                            _html += "<a href='/news-thumb/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_En"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString();
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/news/" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_En"] + "'>";
                            _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString();
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                }
            }
            return _html;
        }
        #endregion
    }
}