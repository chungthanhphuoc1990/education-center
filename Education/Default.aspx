<%@ Page Title="" Language="C#" MasterPageFile="~/page/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Chomehead" ContentPlaceHolderID="head" Runat="Server">
<style>
    .customNavigation{
        text-align: center;
    }
    .customNavigation a{
        -webkit-user-select: none;
        -khtml-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
    }
    .slide-control-next {
        width: 30px;
        height: 30px;
        display: inline-block;
        float: right;
        background: url('/../../img/btnNext.png') no-repeat center;
        cursor: pointer;
        opacity: 0.8;
        margin-top: -6px;
        margin-bottom: 10px;
    }
    .slide-control-prev {
        width: 30px;
        height: 30px;
        display: inline-block;
        float: left;
        background: url('/../../../img/btnBack.png') no-repeat center;
        cursor: pointer;
        opacity: 0.8;
        margin-top: -6px;
        margin-bottom: 10px;
    }
</style>
<script>
    $(document).ready(function () {
        var owl = $("#owl-demo-right");
        // Custom Navigation Events
        $(".next").click(function () {
            owl.trigger('owl.next');
        })
        $(".prev").click(function () {
            owl.trigger('owl.prev');
        })
    });
</script>
</asp:Content>
<asp:Content ID="ChomeContent" ContentPlaceHolderID="CplHome" Runat="Server">
<div class="container body-content">
    <div class="col-xs-12 col-md-9">
        <div id="effect-1" class="effects clearfix">
            <table class="table-responsive" style="width: 100%;border: none">
                <tbody>
                    <%--<tr>
                        <td style="width: 30%;vertical-align: top;text-align: center">
                            <div class="img">
                                <img src="../upload/Mo_TTKT.png" class="img-thumbnail" style="width: 100%;height: 180px;" />
                                <div class="overlay">
                                    <a href="#" class="expand">+</a>
                                </div>
                            </div>
                        </td>
                        <td style="width: 70%;vertical-align: top;text-align: center" colspan="3">
                            <div class="img">
                                <img src="../upload/Mo_CNHT1.png" class="img-thumbnail" style="width: 100%;height: 180px;" />
                                <div class="overlay">
                                    <a href="#" class="expand">+</a>
                                    <a class="close-overlay hidden">x</a>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 33.3%;vertical-align: top;text-align: center">
                            <div class="img">
                                <img src="../upload/Mo_TTKT.png" class="img-thumbnail" style="width: 100%;height: 180px;" />
                                <div class="overlay">
                                    <a href="#" class="expand">+</a>
                                    <a class="close-overlay hidden">x</a>
                                </div>
                            </div>
                        </td>
                        <td style="width: 33.3%;vertical-align: top;text-align: center">
                            <div class="img">
                                <img src="../upload/Mo_TTKT.png" class="img-thumbnail" style="width: 100%;height: 180px;" />
                                <div class="overlay">
                                    <a href="#" class="expand">+</a>
                                    <a class="close-overlay hidden">x</a>
                                </div>
                            </div>
                        </td>
                        <td style="width: 33.3%;vertical-align: top;text-align: center">
                            <div class="img">
                                <img src="../upload/Mo_TTKT.png" class="img-thumbnail" style="width: 100%;height: 180px;" />
                                <div class="overlay">
                                    <a href="#" class="expand">+</a>
                                    <a class="close-overlay hidden">x</a>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                    <%=_htmlNotify %>
                </tbody>
            </table>
         </div>
        <div class="col-md-12 news-main">
            <%--<h3>Tin nỗi bật</h3>
            <div class="content-news">
                <div class="col-md-3">
                    <img src="../upload/Mo_CNHT1.png" style="width: 100%;height: 145px" class="img-thumbnail"/>
                </div>
                <div class="col-md-9">
                    <div class='titile-news'>
                        KẾT QUẢ CUỘC THI THIẾT KẾ THIỆP CHÚC TẾT MỪNG XUÂN ẤT MÙI 2015
                        <p class='short-content-news'>
                            NHỮNG HÌNH ẢNH PHÁT THƯỞNG CHO CÁC LỚP ĐOẠT GIẢI CỦA CUỘC THI THIẾT KẾ THIỆP CHÚC TẾT “ MỪNG XUÂN ẤT MÙI 2015”....... 
                        </p>
                        <span class='date-begin-news'>
                            Ngày đăng: 13/03/2015
                        </span>
                        <span class='more-detail'>
                            <a href='#' class='more-detail'>
                                Chi tiết
                            </a>
                        </span>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
            <hr class="hr"/>
            <div class="col-md-4">
                <img class="img-thumbnail" src="../upload/Mo_CNHT1.png" style="width: 100%;height: 180px;padding: 0;margin: 0;text-align: center"/>
                <div class="box-news">
                    <a href="#" class="box-news">
                         KẾT QUẢ CUỘC THI THIẾT KẾ THIỆP CHÚC TẾT MỪNG XUÂN ẤT MÙI 2015
                    </a>
                </div>
            </div>
            <div class="col-md-4">
                <img class="img-thumbnail" src="../upload/Mo_CNHT1.png" style="width: 100%;height: 180px;padding: 0;margin: 0;text-align: center"/>
                <div class="box-news">
                    <a href="#" class="box-news">
                         KẾT QUẢ CUỘC THI THIẾT KẾ THIỆP CHÚC TẾT MỪNG XUÂN ẤT MÙI 2015
                    </a>
                </div>
            </div>
            <div class="col-md-4">
                <img class="img-thumbnail" src="../upload/Mo_CNHT1.png" style="width: 100%;height: 180px;padding: 0;margin: 0;text-align: center"/>
                <div class="box-news">
                    <a href="#" class="box-news">
                         KẾT QUẢ CUỘC THI THIẾT KẾ THIỆP CHÚC TẾT MỪNG XUÂN ẤT MÙI 2015
                    </a>
                </div>
            </div>--%>
            <%=_htmlNews %>
        </div>
    </div>
    <div class="col-xs-12 col-md-3 right-main">
        
        <%--<div class="col-md-12" style="margin-bottom: 15px;">
            <div class="box-images">
                <div class="customNavigation">
                     <h2 class="titile-images">
                          <a class="btn prev slide-control-prev"></a>
                            HÌNH ẢNH
                         <a class="btn next slide-control-next"></a>
                     </h2>
                </div>
                <div id="owl-demo-right" class="owl-carousel owl-theme">
                  <div class="item">
                      <img src="/img/1.jpg" alt="The Last of us"/>
                  </div>
                  <div class="item">
                      <img src="/img/2.jpg" alt="The Last of us"/>
                  </div>
                  <div class="item">
                      <img src="/img/3.jpg" alt="The Last of us"/>
                  </div>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <h2 class="titile-images">THEO DÕI CHÚNG TÔI</h2>
            <div class="box-fanpage">
                
            </div>
        </div>--%>
        <%=_htmlUtilities %>
        <div class="col-md-12">
            <div class="box-static">
                <h3>Lượt truy cập</h3>
            </div>
        </div>
        <%--<div class="col-md-12">
            <div class="box-static">
                <h3>Lượt truy cập</h3>
            </div>
        </div>--%>
    </div>
</div>
</asp:Content>