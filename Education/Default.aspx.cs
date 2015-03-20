using System;
using System.Web.UI.HtmlControls;
using LibBusinessLayer;

public partial class _Default : System.Web.UI.Page
{
    #region[Define]
    protected string _htmNewsMain = string.Empty;
    protected string _htmSlideShow = string.Empty;
    protected string _htmPage = string.Empty;
    protected string _htmlUtilities = string.Empty;
    readonly DateTime t1 = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));//Thời gian hệ thống
    #endregion

    #region[Controller]
    protected void Page_Load(object sender, EventArgs e)
    {
        //_htmNewsMain = GetNews();
        //_htmSlideShow = GetSlide();
        _htmlUtilities = GetUtilitiesVn();
        var cookie = Request.Cookies["CurrentLanguage"];
        if (!IsPostBack && cookie != null && cookie.Value != null)
        {
            _htmlUtilities = cookie.Value == "vn" ? GetUtilitiesVn() : GetUtilitiesEn();
        }
        _htmPage = GetPageSetting();
    }
    #endregion

    #region[Method]
    private string GetNews()
    {
        string _html = string.Empty;
        var _clsGetCatalogMain = new BllCatalogMain();
        var _clsGetCatalogParrent = new BllCatalogPrarent();
        var _clsGetNews = new BllNews();
        var _dtGetCatalogMain = _clsGetCatalogMain.GetCatalogMainHomePage(string.Empty);
        if (_dtGetCatalogMain != null && _dtGetCatalogMain.Rows.Count > 0)
        {
            for (int i = 0; i < _dtGetCatalogMain.Rows.Count; i++)
            {
                var _dtGetCatalogParrent =
                    _clsGetCatalogParrent.GetCatalogParrentHomePage(int.Parse(_dtGetCatalogMain.Rows[i]["ID_CatMain"].ToString()));

                if (_dtGetCatalogParrent != null && _dtGetCatalogParrent.Rows.Count > 0)
                {
                    if ((bool)_dtGetCatalogMain.Rows[i]["IsShow"])
                    {
                        _html += "<div class='boxmain'>";//Box Main
                        _html += "<div style='position:relative;padding-top:15px;clear:both'>";//Box position
                        for (int j = 0; j < _dtGetCatalogParrent.Rows.Count; j++)
                        {
                            var _dtGetNews = _clsGetNews.GetNewsHomePage(string.Empty,
                                int.Parse(_dtGetCatalogParrent.Rows[j]["ID_CatPrarent"].ToString()));
                            if (j == 1)
                                break;
                            _html += "<div class='bg_topic_level_two'>";//Box bg_topic_level_two
                            _html += _dtGetCatalogMain.Rows[i]["Catalog_Main_Titile_Vn"] + " » ";
                            _html += _dtGetCatalogParrent.Rows[j]["Catalog_Prarent_Titile_Vn"].ToString();
                            _html += "</div>";//Đóng bg_topic_level_two

                            if (_dtGetNews != null && _dtGetNews.Rows.Count > 0)
                            {
                                _html += "<div class='newsitem topnewsitem first'>";//newsitem topnewsitem first
                                _html += "<div class='news_title'>";
                                _html += "<a href='/detail/" + _dtGetNews.Rows[0]["Friendly_Url_Vn"] + "'>";
                                //if ((bool)_dtGetNews.Rows[0]["IsHot"])
                                //{
                                //    //_html += "<img src=images/new.gif /> ";
                                //    _html += _dtGetNews.Rows[0]["Titile_Vn"] + " ";
                                //}
                                //else
                                //{
                                //    _html += _dtGetNews.Rows[0]["Titile_Vn"] + " ";
                                //}
                                if (t1 < Convert.ToDateTime(_dtGetNews.Rows[0]["DateEnd"].ToString()))
                                {
                                    _html += "<img src=../images/new.gif /> ";
                                    _html += _dtGetNews.Rows[0]["Titile_Vn"] + " ";
                                }
                                else
                                {
                                    _html += _dtGetNews.Rows[0]["Titile_Vn"] + " ";
                                }
                                _html += "</a>";
                                _html += "<span class='template_datebegin'>";
                                _html += String.Format("{0:dd-MM-yyyy}", _dtGetNews.Rows[0]["DateBegin"]);
                                _html += "</span>";
                                _html += "</div>";

                                _html += "<div style='margin-top:5px;margin-bottom:5px;text-align:center;'>";
                                if (String.IsNullOrEmpty(_dtGetNews.Rows[0]["Img_Thumb"].ToString())
                                                         ||
                                                         _dtGetNews.Rows[0]["Img_Thumb"].ToString() ==
                                                         DBNull.Value.ToString())
                                {
                                    _html += "<img src='Upload/no_photo.png'style='width:220px;height:220px'/>";
                                }
                                else
                                {
                                    _html += "<img src='" + _dtGetNews.Rows[0]["Img_Thumb"] + "' style='width: " +
                                        _dtGetNews.Rows[0]["Width_Thumb"] + "px" + ";height:" +
                                        _dtGetNews.Rows[0]["Height_Thumb"] + "px'/>";
                                }
                                _html += "</div>";
                                _html += "<div class='news_content'>";
                                _html += _dtGetNews.Rows[0]["ShortContent_Vn"].ToString();
                                _html += "</div>";
                                _html += "</div>";//Đóng newsitem topnewsitem first
                                //_html += "<div style='clear: both'></div>";
                                _html += "<div class='newsitem topnewsitem'>";//newsitem topnewsitem
                                for (int k = 1; k < _dtGetNews.Rows.Count; k++)
                                {
                                    if (k == 8)
                                        break;
                                    _html += "<div class='news_title_'>";
                                    _html += "<img src='images/media_dot_.gif' style='border: 0' /> ";
                                    _html += "<a href='/detail/" + _dtGetNews.Rows[k]["Friendly_Url_Vn"] + "'>";

                                    if (t1 < Convert.ToDateTime(_dtGetNews.Rows[k]["DateEnd"].ToString()))
                                    {
                                        _html += "<img src=../images/new.gif /> ";
                                        _html += _dtGetNews.Rows[k]["Titile_Vn"] + " ";
                                    }
                                    else
                                    {
                                        _html += _dtGetNews.Rows[k]["Titile_Vn"] + " ";
                                    }
                                    _html += "</a>";
                                    _html += "<span class='template_datebegin'>";
                                    _html += String.Format("{0:dd-MM-yyyy}", _dtGetNews.Rows[k]["DateBegin"]);
                                    _html += "</span>";
                                    _html += "</div>";
                                }

                                _html += "</div>";//Đóng newsitem topnewsitem
                                //_html += "<div style='clear: both'></div>"; 
                                //_html += "<div style='width: 100%;height: 100%;'>";
                                //_html += "<span class='span-order-news'>Các tin cùng loại</span>";
                                //    _html += "<table style='width:100%;'>";
                                //var _dtCategoryOrder =
                                //    _clsGetCatalogParrent.GetCatalogParrentHomePage(
                                //        int.Parse(_dtGetCatalogMain.Rows[i]["ID_CatMain"].ToString()));
                                //for (int h = 1; h < _dtCategoryOrder.Rows.Count; h++)
                                //{
                                //    if (h == 4)
                                //        break;
                                //    _html += "<tr>";
                                //    _html += "<td class='td-border'>";
                                //    _html += "<div class='div-titile'>";
                                //    _html += "<a href='/news/" + _dtCategoryOrder.Rows[h]["Friendly_Url_Vn"] + "'>";
                                //    _html += " » ";
                                //    _html += _dtCategoryOrder.Rows[h]["Catalog_Prarent_Titile_Vn"] +
                                //              "</a>";
                                //    _html += "</div>";
                                //    _html += "</td>";
                                //    _html += "</tr>";
                                //}

                                //    _html += "</table>";
                                //_html += "</div>";
                            }
                        }
                        _html += "</div>";//Đóng Box position
                        _html += "</div>";//Đóng box main
                    }
                }
            }
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
                    _html += "<div class='slide'>";
                    _html += "<a href='/detail/" + _dtGetSlide.Rows[i]["Friendly_Url_Vn"] + "'title='" +
                             _dtGetSlide.Rows[i]["Titile_Vn"] +
                             "' target='_blank'>";
                    _html += "<img src='" + _dtGetSlide.Rows[i]["Img"] + "' style='width: " +
                             _dtGetSlide.Rows[i]["Width"] + "px" + ";height:" +
                             _dtGetSlide.Rows[i]["Height"] + "px'/>";

                    _html += "</a>";
                    _html += "<div class='captions' style='bottom:0'>";
                    _html += "<p>" + _dtGetSlide.Rows[i]["Titile_Vn"] + "</p>";
                    _html += "</div>";
                    _html += "</div>";
                }
            }
        }
        return _html;
    }
    private string GetUtilitiesVn()
    {
        var _html = string.Empty;
        var _clsUtilities = new BllGallery();
        var _clsUtilitiesDetail = new BllGalleryDetail();
        var _dtUtilities = _clsUtilities.GetGalleryHomePage(string.Empty);
        if (_dtUtilities != null && _dtUtilities.Rows.Count > 0)
        {
            for (int i = 0; i < _dtUtilities.Rows.Count; i++)
            {
                var _dtNotifyDetail =
                        _clsUtilitiesDetail.GetGalleryDetailHomePage(int.Parse(_dtUtilities.Rows[i]["ID_Gallery"].ToString()));
                if (_dtUtilities.Rows[i]["Img"].ToString() == string.Empty || _dtUtilities.Rows[i]["Img"] == DBNull.Value)
                {
                    _html += "<div class='col-md-12'>";
                    _html += "<h2 class='titile-images'>";
                    _html += _dtUtilities.Rows[i]["Gallery_Titile_Vn"].ToString();
                    _html += "</h2>";
                    _html += "</div>";

                    //Parrent
                    _html += "<div class='box-fanpage''>";
                    if (_dtNotifyDetail != null && _dtNotifyDetail.Rows.Count > 0)
                    {
                        for (int j = 0; j < _dtNotifyDetail.Rows.Count; j++)
                        {
                            _html += _dtNotifyDetail.Rows[j]["ShortContent_Vn"].ToString();
                        }
                    }
                    _html += "</div>";
                }
                else
                {
                    _html += "<div class='col-md-12' style='margin-bottom: 15px;'>";
                    _html += "<div class='box-images'>";
                    _html += "<div class='customNavigation'>";
                    _html += "<h2 class='titile-images'>";
                    _html += "<a class='btn prev slide-control-prev'></a>";
                    _html += _dtUtilities.Rows[i]["Gallery_Titile_Vn"].ToString();
                    _html += "<a class='btn next slide-control-next'></a>";
                    _html += "</h2>";
                    _html += "</div>";
                    _html += "</div>";

                    //Parrent
                    _html += "<div id='owl-demo-right' class='owl-carousel owl-theme'>";
                    if (_dtNotifyDetail != null && _dtNotifyDetail.Rows.Count > 0)
                    {
                        for (int j = 0; j < _dtNotifyDetail.Rows.Count; j++)
                        {
                            _html += "<div class='item'>";
                            _html += "<img src='" + _dtNotifyDetail.Rows[j]["Img"] + "' alt='" + _dtNotifyDetail.Rows[j]["Gallery_Titile_Vn"] + "' style='height:204px'/>";
                            _html += "</div>";
                        }
                    }
                    _html += "</div>";
                    _html += "</div>";
                }
               
            }
        }
        return _html;
    }
    private string GetUtilitiesEn()
    {
        var _html = string.Empty;
        var _clsUtilities = new BllGallery();
        var _clsUtilitiesDetail = new BllGalleryDetail();
        var _dtNotifyUtilities = _clsUtilities.GetGalleryHomePage(string.Empty);
        if (_dtNotifyUtilities != null && _dtNotifyUtilities.Rows.Count > 0)
        {
            for (int i = 0; i < _dtNotifyUtilities.Rows.Count; i++)
            {
                var _dtNotifyDetail =
                        _clsUtilitiesDetail.GetGalleryDetailHomePage(int.Parse(_dtNotifyUtilities.Rows[i]["ID_Gallery"].ToString()));
                if (_dtNotifyUtilities.Rows[i]["Img"].ToString() ==string.Empty || _dtNotifyUtilities.Rows[i]["Img"] == DBNull.Value)
                {
                    _html += "<div class='col-md-12'>";
                    _html += "<h2 class='titile-images'>";
                    _html += _dtNotifyUtilities.Rows[i]["Gallery_Titile_En"].ToString();
                    _html += "</h2>";
                    _html += "</div>";

                    //Parrent
                    _html += "<div class='box-fanpage'>";
                    if (_dtNotifyDetail != null && _dtNotifyDetail.Rows.Count > 0)
                    {
                        for (int j = 0; j < _dtNotifyDetail.Rows.Count; j++)
                        {
                            _html += _dtNotifyDetail.Rows[j]["ShortContent_En"].ToString();
                        }
                    }
                    _html += "</div>";
                }
                else
                {
                    _html += "<div class='col-md-12' style='margin-bottom: 15px;'>";
                    _html += "<div class='box-images'>";
                    _html += "<div class='customNavigation'>";
                    _html += "<h2 class='titile-images'>";
                    _html += "<a class='btn prev slide-control-prev'></a>";
                    _html += _dtNotifyUtilities.Rows[i]["Gallery_Titile_En"].ToString();
                    _html += "<a class='btn next slide-control-next'></a>";
                    _html += "</h2>";
                    _html += "</div>";
                    _html += "</div>";

                    //Parrent
                    _html += "<div id='owl-demo-right' class='owl-carousel owl-theme'>";
                    if (_dtNotifyDetail != null && _dtNotifyDetail.Rows.Count > 0)
                    {
                        for (int j = 0; j < _dtNotifyDetail.Rows.Count; j++)
                        {
                            _html += "<div class='item'>";
                            _html += "<img src='" + _dtNotifyDetail.Rows[j]["Img"] + "' alt='" + _dtNotifyDetail.Rows[j]["Gallery_Titile_En"] + "' style='height:204px'/>";
                            _html += "</div>";
                        }
                    }
                    _html += "</div>";
                    _html += "</div>";
                }

            }
        }
        return _html;
    }
    private string GetPageSetting()
    {
        var _html = string.Empty;
        var _clsGetPage = new BllPageSetting();
        var _dtGetpage = _clsGetPage.GetPageSetting();
        if (_dtGetpage != null && _dtGetpage.Rows.Count > 0)
        {
            Page.Title = String.IsNullOrEmpty(_dtGetpage.Rows[0]["Page_Titile"].ToString()) ? "Trường Cao Đăng Kinh Tế Bạc Liêu | Trang Chủ" : _dtGetpage.Rows[0]["Page_Titile"].ToString();
            var metakey = new HtmlMeta
            {
                Name = "keywords",
                Content = _dtGetpage.Rows[0]["Keywords_ShortContent"].ToString()
            };
            Page.Header.Controls.Add(metakey);
            var metadesc = new HtmlMeta
            {
                Name = "description",
                Content = _dtGetpage.Rows[0]["Keywords_Descriptions"].ToString()
            };
            Page.Header.Controls.Add(metadesc);


        }
        return _html;
    }
    #endregion
}