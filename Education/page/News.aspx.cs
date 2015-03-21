using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LibBusinessLayer;

namespace page
{
    public partial class page_News : System.Web.UI.Page
    {
        #region[Define]
        private const int _maxLength = 287;
        protected int _htmlIDMenuParrent = 0;
        protected string _htmlGetMenu = string.Empty;
        protected string _htmlTitile = string.Empty;
        #endregion

        #region[Controller]
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["CurrentLanguage"];
            if (!IsPostBack && cookie != null && cookie.Value != null && Request.Params["id"] != null)
            {
                GetNewsTitileVn(Request.Params["id"]);
                _htmlGetMenu = GetMenuVn();
                ListViewAllEn.Visible = false;
                DataPagerEn.Visible = false;
                if (cookie.Value == "vn")
                {
                    GetNewsTitileVn(Request.Params["id"]);
                    _htmlGetMenu = GetMenuVn();
                    ListViewAll.Visible = true;
                    DataPagerListAll.Visible = true;

                    ListViewAllEn.Visible = false;
                    DataPagerEn.Visible = false;
                }
                else
                {
                    GetNewsTitileEn(Request.Params["id"]);
                    _htmlGetMenu = GetMenuEn();
                    ListViewAll.Visible = false;
                    DataPagerListAll.Visible = false;

                    ListViewAllEn.Visible = true;
                    DataPagerEn.Visible = true;
                }
            }
        }
        protected void ListViewAll_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var lb_lst_short_vn = (Label)e.Item.FindControl("lb_lst_short_vn");
                if (lb_lst_short_vn.Text.Length > _maxLength)
                {
                    lb_lst_short_vn.Text = lb_lst_short_vn.Text.Substring(0, _maxLength) + "...";
                }
                else
                {
                    lb_lst_short_vn.Text = lb_lst_short_vn.Text;
                }
            }
        }
        protected void ListViewAllEn_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var lb_lst_short_en = (Label)e.Item.FindControl("lb_lst_short_en");
                if (lb_lst_short_en.Text.Length > _maxLength)
                {
                    lb_lst_short_en.Text = lb_lst_short_en.Text.Substring(0, _maxLength) + "...";
                }
                else
                {
                    lb_lst_short_en.Text = lb_lst_short_en.Text;
                }
            }
        }
        protected void DataPagerListAll_PreRender(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                GetNewsTitileVn(Request.Params["id"]);
            }
        }
        protected void DataPagerEn_PreRender(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                GetNewsTitileEn(Request.Params["id"]);
            }
        }
        #endregion

        #region[Method]
        private void GetNewsTitileVn(string Friendly_Url)
        {
            var _clsGetNewsTitile = new BllNews();
            var _dtGetNewTitile = _clsGetNewsTitile.GetNewsHomePageTitile(string.Empty, Friendly_Url);
            if (_dtGetNewTitile != null && _dtGetNewTitile.Rows.Count > 0)
            {
                _htmlTitile = _dtGetNewTitile.Rows[0]["Catalog_Prarent_Titile_Vn"].ToString();
                Page.Title = _dtGetNewTitile.Rows[0]["Catalog_Main_Titile_Vn"] + " | " +
                                _dtGetNewTitile.Rows[0]["Catalog_Prarent_Titile_Vn"];
                _htmlIDMenuParrent = int.Parse(_dtGetNewTitile.Rows[0]["ID_CatMain"].ToString());
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetNewTitile.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetNewTitile.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                //End
                ListViewAll.DataSource = _dtGetNewTitile;
                ListViewAll.DataBind();
                ListViewAll.Visible = true;
                DataPagerListAll.Visible = true;
            }
            else
            {
                ListViewAll.Visible = false;
                DataPagerListAll.Visible = false;
            }
        }
        private void GetNewsTitileEn(string Friendly_Url)
        {
            var _clsGetNewsTitile = new BllNews();
            var _dtGetNewTitile = _clsGetNewsTitile.GetNewsHomePageTitile(string.Empty, Friendly_Url);
            if (_dtGetNewTitile != null && _dtGetNewTitile.Rows.Count > 0)
            {
                Page.Title = _dtGetNewTitile.Rows[0]["Catalog_Main_Titile_En"] + " | " +
                                _dtGetNewTitile.Rows[0]["Catalog_Prarent_Titile_En"];
                _htmlIDMenuParrent = int.Parse(_dtGetNewTitile.Rows[0]["ID_CatMain"].ToString());

                _htmlTitile = _dtGetNewTitile.Rows[0]["Catalog_Prarent_Titile_En"].ToString();
                //SEO
                var metakey = new HtmlMeta
                {
                    Name = "keywords",
                    Content = _dtGetNewTitile.Rows[0]["Keywords_ShortContent"].ToString()
                };
                Page.Header.Controls.Add(metakey);
                var metadesc = new HtmlMeta
                {
                    Name = "description",
                    Content = _dtGetNewTitile.Rows[0]["Keywords_Descriptions"].ToString()
                };
                Page.Header.Controls.Add(metadesc);
                ListViewAllEn.DataSource = _dtGetNewTitile;
                ListViewAllEn.DataBind();
                ListViewAllEn.Visible = true;
                DataPagerEn.Visible = true;
            }
            else
            {
                ListViewAllEn.Visible = false;
                DataPagerEn.Visible = false;
            }
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
                        _html += "<a href='" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_Vn"] + "'>";
                        _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString();
                        _html += "</a>";
                        _html += "</li>";
                    }
                    else
                    {
                        _html += "<li role='presentation'>";
                        _html += "<a href='" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_Vn"] + "'>";
                        _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_Vn"].ToString();
                        _html += "</a>";
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
                        _html += "<a href='" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_En"] + "'>";
                        _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString();
                        _html += "</a>";
                        _html += "</li>";
                    }
                    else
                    {
                        _html += "<li role='presentation'>";
                        _html += "<a href='" + _dtGetCatalogParrent.Rows[i]["Friendly_Url_En"] + "'>";
                        _html += _dtGetCatalogParrent.Rows[i]["Catalog_Prarent_Titile_En"].ToString();
                        _html += "</a>";
                        _html += "</li>";
                    }
                }
            }
            return _html;
        }
        #endregion
    }
}