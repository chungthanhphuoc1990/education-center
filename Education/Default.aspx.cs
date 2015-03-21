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
    protected string _htmlNotify = string.Empty;
    protected string _htmlNews = string.Empty;
    private const int _maxLength = 287;
    private const int _maxLengthTitile = 41;
    //readonly DateTime t1 = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));//Thời gian hệ thống
    #endregion

    #region[Controller]
    protected void Page_Load(object sender, EventArgs e)
    {
        _htmlUtilities = GetUtilitiesVn();
        _htmPage = GetPageSetting();
        _htmlNotify = GetNotify();
        _htmlNews = GetNewsVn();
        var cookie = Request.Cookies["CurrentLanguage"];
        if (!IsPostBack && cookie != null && cookie.Value != null)
        {
            if (cookie.Value == "vn")
            {
                _htmlUtilities = GetUtilitiesVn();
                _htmlNews = GetNewsVn();
            }
            else
            {
                _htmlUtilities = GetUtilitiesEn();
                _htmlNews = GetNewsEn();
            }
        }
    }
    #endregion

    #region[Method]
    private string GetNotify()
    {
        var _html = string.Empty;
        var _clsGetNotify = new BllNotify();
        var _clsGetNotifyDetail = new BllNotifyDetail();
        var _dtGetNotify = _clsGetNotify.GetNotifyHomePage(string.Empty);
        if (_dtGetNotify != null && _dtGetNotify.Rows.Count > 0)
        {
            for (int i = 0; i < _dtGetNotify.Rows.Count; i++)
            {
                if(i==1)
                    break;
                _html += "<tr>";
                var _dtGetNotifyDetail =
                    _clsGetNotifyDetail.GetNotifyDetailHomePage(int.Parse(_dtGetNotify.Rows[i]["ID_Notify"].ToString()));
                if (_dtGetNotifyDetail != null && _dtGetNotifyDetail.Rows.Count > 0)
                {
                    _html += "<td style='width: 30%;vertical-align: top;text-align: center'>";
                    _html += "<div class='img'>";
                    _html +=
                        "<img src='" + _dtGetNotifyDetail.Rows[0]["Img"] +
                        "' class='img-thumbnail' style='width: 100%;height: 180px;' />";
                    _html += "<div class='overlay'>";
                    if (_dtGetNotifyDetail.Rows[0]["Url"].ToString() == string.Empty
                        || _dtGetNotifyDetail.Rows[1]["Url"] == DBNull.Value)
                    {
                        _html += "<a href='/intro/" + _dtGetNotifyDetail.Rows[0]["Friendly_Url_Vn"] + "' class='expand'>+</a>";
                    }
                    else
                    {
                        _html += "<a href='" + _dtGetNotifyDetail.Rows[0]["Url"] + "' class='expand'>+</a>";
                    }
                    _html += "</div>";
                    _html += "</div>";
                    _html += "</td>";

                    _html += "<td style='width: 70%;vertical-align: top;text-align: center' colspan='3'>";
                    _html += "<div class='img'>";
                    _html +=
                        "<img src='" + _dtGetNotifyDetail.Rows[1]["Img"] +
                        "' class='img-thumbnail' style='width: 100%;height: 180px;' />";
                    _html += "<div class='overlay'>";
                    if (_dtGetNotifyDetail.Rows[1]["Url"].ToString() == string.Empty
                        || _dtGetNotifyDetail.Rows[1]["Url"] == DBNull.Value)
                    {
                        _html += "<a href='/intro/" + _dtGetNotifyDetail.Rows[1]["Friendly_Url_Vn"] + "' class='expand'>+</a>";
                    }
                    else
                    {
                        _html += "<a href='" + _dtGetNotifyDetail.Rows[1]["Url"] + "' class='expand'>+</a>";
                    }
                    _html += "</div>";
                    _html += "</div>";
                    _html += "</td>";
                    
                }
                _html += "</tr>";
            }
            for (int k = 1; k < _dtGetNotify.Rows.Count; k++)
            {
                var _dtGetNotifyDetailTwo =
                    _clsGetNotifyDetail.GetNotifyDetailHomePage(int.Parse(_dtGetNotify.Rows[k]["ID_Notify"].ToString()));
                _html += "<tr>";
                for (int j = 0; j < _dtGetNotifyDetailTwo.Rows.Count; j++)
                {
                    _html += "<td style='width: 33.3%;vertical-align: top;text-align: center'>";
                    _html += "<div class='img'>";
                    _html +=
                        "<img src='" + _dtGetNotifyDetailTwo.Rows[j]["Img"] +
                        "' class='img-thumbnail' style='width: 100%;height: 180px;' />";
                    _html += "<div class='overlay'>";
                    if (_dtGetNotifyDetailTwo.Rows[j]["Url"].ToString() == string.Empty
                        || _dtGetNotifyDetailTwo.Rows[j]["Url"] == DBNull.Value)
                    {
                        _html += "<a href='/intro/" + _dtGetNotifyDetailTwo.Rows[j]["Friendly_Url_Vn"] + "' class='expand'>+</a>";
                    }
                    else
                    {
                        _html += "<a href='" + _dtGetNotifyDetailTwo.Rows[j]["Url"] + "' class='expand'>+</a>";
                    }
                    _html += "</div>";
                    _html += "</div>";
                    _html += "</td>";
                }
                _html += "</tr>";
            }
        }
        return _html;
    }
    private string GetNewsVn()
    {
        string _html = string.Empty;
        var _clsGetNews = new BllNews();
        var _dtGetNews = _clsGetNews.GetNews(string.Empty);
        if (_dtGetNews != null && _dtGetNews.Rows.Count > 0)
        {
            if ((bool)_dtGetNews.Rows[0]["IsHot"] && (bool)_dtGetNews.Rows[0]["IsActive"])
            {
                _html += "<h3>Tin nỗi bật</h3>";
                _html += "<div class='content-news'>";
                    _html += "<div class='col-md-3'>";
                    _html += "<img src='" + _dtGetNews.Rows[0]["Img_Thumb"] + "' style='width: " +
                         _dtGetNews.Rows[0]["Width_Thumb"] + "%" + ";height:" +
                         _dtGetNews.Rows[0]["Height_Thumb"] + "px' class='img-thumbnail'/>";
                    _html += "</div>";

                    _html += "<div class='col-md-9'>";
                        _html += "<div class='titile-news'>";
                            _html += _dtGetNews.Rows[0]["Titile_Vn"].ToString();
                            _html += "<p class='short-content-news'>";
                            if (_dtGetNews.Rows[0]["ShortContent_Vn"].ToString().Length > _maxLength)
                            {
                                _html += _dtGetNews.Rows[0]["ShortContent_Vn"].ToString().Substring(0, _maxLength) +
                                         "....";
                            }
                            else
                            {
                                _html += _dtGetNews.Rows[0]["ShortContent_Vn"].ToString();
                            }
                            _html += "</p>";

                            _html += "<span class='date-begin-news'>";
                                _html += "Ngày đăng : " + String.Format("{0:dd-MM-yyyy}", _dtGetNews.Rows[0]["DateBegin"]);
                            _html += "</span>";

                            _html += "<span class='more-detail'>";
                                _html += "<a href='/intro/" + _dtGetNews.Rows[0]["Friendly_Url_Vn"] + "' class='more-detail'>Chi tiết</a>";
                            _html += "</span>";
                        _html += "</div>";
                    _html += "</div>";
                    _html += "<div class='clear'></div>";
                _html += "</div>";

                _html += "<hr class='hr'/>";
                for (int i = 1; i < _dtGetNews.Rows.Count; i++)
                {
                    if ((bool) _dtGetNews.Rows[i]["IsHot"] && (bool) _dtGetNews.Rows[i]["IsActive"])
                    {
                        _html += "<div class='col-md-4'>";
                        _html += "<img src='" + _dtGetNews.Rows[i]["Img_Thumb"] + "' style='width: " +
                                 _dtGetNews.Rows[i]["Width_Thumb"] + "%" + ";height:" +
                                 _dtGetNews.Rows[i]["Height_Thumb"] +
                                 "px;padding: 0;margin: 0;text-align: center' class='img-thumbnail'/>";
                        _html += "<div class='box-news'>";
                        if (_dtGetNews.Rows[i]["Titile_Vn"].ToString().Length > _maxLengthTitile)
                        {
                            _html += "<a data-toggle='tooltip' data-placement='top' href='/intro/" + _dtGetNews.Rows[i]["Friendly_Url_Vn"] + "' class='box-news' title='" + _dtGetNews.Rows[i]["Titile_Vn"] + "'>";
                            _html += _dtGetNews.Rows[i]["Titile_Vn"].ToString().Substring(0,_maxLengthTitile) + "...";
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/intro/" + _dtGetNews.Rows[i]["Friendly_Url_Vn"] + "' class='box-news'>";
                            _html += _dtGetNews.Rows[i]["Titile_Vn"].ToString();
                            _html += "</a>";
                        }
                        _html += "</div>";
                        _html += "</div>";
                    }
                }
            }
        }
        return _html;
    }
    private string GetNewsEn()
    {
        string _html = string.Empty;
        var _clsGetNews = new BllNews();
        var _dtGetNews = _clsGetNews.GetNews(string.Empty);
        if (_dtGetNews != null && _dtGetNews.Rows.Count > 0)
        {
            if ((bool)_dtGetNews.Rows[0]["IsHot"] && (bool)_dtGetNews.Rows[0]["IsActive"])
            {
                _html += "<h3>Hot News</h3>";
                _html += "<div class='content-news'>";
                _html += "<div class='col-md-3'>";
                _html += "<img src='" + _dtGetNews.Rows[0]["Img_Thumb"] + "' style='width: " +
                     _dtGetNews.Rows[0]["Width_Thumb"] + "%" + ";height:" +
                     _dtGetNews.Rows[0]["Height_Thumb"] + "px' class='img-thumbnail'/>";
                _html += "</div>";

                _html += "<div class='col-md-9'>";
                _html += "<div class='titile-news'>";
                _html += _dtGetNews.Rows[0]["Titile_En"].ToString();
                _html += "<p class='short-content-news'>";
                if (_dtGetNews.Rows[0]["ShortContent_En"].ToString().Length > _maxLength)
                {
                    _html += _dtGetNews.Rows[0]["ShortContent_En"].ToString().Substring(0, _maxLength) +
                             "....";
                }
                else
                {
                    _html += _dtGetNews.Rows[0]["ShortContent_Vn"].ToString();
                }
                _html += "</p>";

                _html += "<span class='date-begin-news'>";
                _html += "Date Post : " + String.Format("{0:dd-MM-yyyy}", _dtGetNews.Rows[0]["DateBegin"]);
                _html += "</span>";

                _html += "<span class='more-detail'>";
                _html += "<a href='/intro/" + _dtGetNews.Rows[0]["Friendly_Url_En"] + "' class='more-detail'>View Detail</a>";
                _html += "</span>";
                _html += "</div>";
                _html += "</div>";
                _html += "<div class='clear'></div>";
                _html += "</div>";

                _html += "<hr class='hr'/>";
                for (int i = 1; i < _dtGetNews.Rows.Count; i++)
                {
                    if ((bool) _dtGetNews.Rows[i]["IsHot"] && (bool) _dtGetNews.Rows[i]["IsActive"])
                    {
                        _html += "<div class='col-md-4'>";
                        _html += "<img src='" + _dtGetNews.Rows[0]["Img_Thumb"] + "' style='width: " +
                                 _dtGetNews.Rows[i]["Width_Thumb"] + "%" + ";height:" +
                                 _dtGetNews.Rows[i]["Height_Thumb"] +
                                 "px;padding: 0;margin: 0;text-align: center' class='img-thumbnail'/>";
                        _html += "<div class='box-news'>";
                        if (_dtGetNews.Rows[i]["Titile_En"].ToString().Length > _maxLengthTitile)
                        {
                            _html += "<a data-toggle='tooltip' data-placement='top' href='/intro/" + _dtGetNews.Rows[i]["Friendly_Url_En"] + "' class='box-news' title='" + _dtGetNews.Rows[i]["Titile_En"] + "'>";
                            _html += _dtGetNews.Rows[i]["Titile_En"].ToString().Substring(0, _maxLengthTitile) + "...";
                            _html += "</a>";
                        }
                        else
                        {
                            _html += "<a href='/intro/" + _dtGetNews.Rows[i]["Friendly_Url_En"] + "' class='box-news'>";
                            _html += _dtGetNews.Rows[i]["Titile_En"].ToString();
                            _html += "</a>";
                        }
                        _html += "</div>";
                        _html += "</div>";
                    }
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