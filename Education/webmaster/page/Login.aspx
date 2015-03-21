<%@ page language="C#" autoeventwireup="true" inherits="webmaster.page.webmaster_page_Login, App_Web_ij44qqrg" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    
    <%--JQuery-min--%>
    <script src="../Style/Bootstrap/js/jquery.min.js"></script>
    <%--End--%>
    
    <!--Bootstrap-->
    <link href="../Style/JqueryUI/jquery-ui.css" rel="stylesheet" />
    <link href="../Style/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../Style/Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Style/Bootstrap/css/simple-sidebar.css" rel="stylesheet" />
    <script src="../Style/Bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="../Style/JqueryUI/jquery-ui.min.js"></script>
    <script src="../Style/LaguageDatePicker/languagedatepicker.js"></script>
    <script src="../Style/Mask/jquery.maskedinput.js"></script>
    <%--End--%>
    
    <%--MyStyle--%>
    <link href="../Style/Admin.css" rel="stylesheet" />
    <%--End--%>
    
     <%--Alert--%>
    <link href="../Scripts/Alert/jquery.alerts.css" rel="stylesheet" />
    <script src="../Scripts/Alert/jquery.alerts.js"></script>
    <%--End--%>
    
    <style>
        /*-----------Login------------*/
         .body {
                font-family: Arial Tahoma;
                padding     : 20px;
	            /*background  : url(../img/bgnoise.png) 0 0 repeat;*/
                background  : url(../images/bglogin.jpg) no-repeat;
                background-position: center center;
                background-attachment: fixed;
            }
         .text-logo {
             text-align: center;
             font-weight: bold;
             font-size: 24px;
             font-family: -webkit-pictograph;
             text-transform: uppercase;
             text-shadow: 4px 4px 2px rgba(150, 150, 150, 1);
             color: #000000;
         }
         .loadding {
            text-align: center;
            position: fixed;
            width: 100%;
            top: 30%;
        }
        .loadding-main {
            width: 11%;
            margin: auto;
        }
    </style>
    
    <%--Loadding-Page--%>
    <script>
        $(window).load(function () {
            $('#dvLoading').fadeOut("slow");
        });
    </script>
    <%--End--%>
</head>
<body class="body">
    <form id="form1" runat="server">
        <div id="dvLoading" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <asp:Image ID="ImageLoadingPage" runat="server"  ImageUrl="../ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                    <span class="label label-danger">
                        <asp:Label ID="lbLoadingPage" runat="server" Text="Đang tải..."/>
                    </span>  
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="text-logo">
                Quản trị hệ thống
            </div>
        </div>
        <div class="container-fluid" style="width: 30%">
            <div class="col-md-12">
                <div class="panel panel-primary" style="margin-top: 20px;">
                    <div class="panel-heading">
                        <h3 class="panel-title">Đăng nhập hệ thống</h3>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12" style="margin-top: 8px">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Tên đăng nhập</label>
                                <input type="text" class="form-control" id="txtUserName" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-12" style="margin-top: 8px">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Mật khẩu</label>
                                <input type="password" class="form-control" id="txtPasswrods" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <%=_Msg %>
                        </div>
                    </div>
                    <div class="panel-footer">
                         <div class="col-md-12" style="text-align: right">
                             <asp:Button ID="btnSubmit" class="btn btn-danger" runat="server" Text="Đăng nhập" OnClick="btnSubmit_Click"/>
                        </div>
                        <div class="clr"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
