<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SWFUploadDemo.aspx.cs" Inherits="BookShop.Web.test.SWFUploadDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="../Css/themes/ui-lightness/jquery-ui-1.8.2.custom.css" rel="stylesheet" />--%>
    <link href="../Css/ImageAreaSelec/imgareaselect-default.css" rel="stylesheet" />
    <script src="../SWFUpload/handlers.js"></script>
    <script src="../SWFUpload/swfupload.js"></script>
    <script src="../js/jquery-1.7.1.js"></script>
    <%--<script src="../js/jquery-ui-1.8.2.custom.min.js"></script>--%>
    <script src="../js/jquery.imgareaselect.min.js"></script>
    <script type="text/javascript">
        var swfu;
        var imgurl ;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "../ashx/Upload.ashx",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg",
                file_types_description: "JPG Images",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: getUpImage,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: "../SWFUpload/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">请选择上传图片 <span class="buttonSmall">(2 MB Max)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,
                // Flash Settings
                flash_url: "../SWFUpload/swfupload.swf",	// Relative to this file
                flash9_url: "../SWFUpload/swfupload_FP9.swf",	// Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });
        }

        function getUpImage(file,serverData) {
            //$("#imgUrl").attr("src", serverData);
            var data = serverData.split(":")
            imgurl = data[0];
            //$("#divContent").css("backgroundImage", "url(" + data[0] + ")").css("width", data[1] + "px").css("height", data[2] + "px");
            $("#selectbanner").attr("src", data[0]);
            $("#selectbanner").imgAreaSelect({
                selectionColor: 'blue'
                , x1: 0
                , y1: 0
                , x2: 100
                , y2: 100
                , selectionOpacity: 0.2
                , onSelectEnd: preview
            })
        }

        function preview(img, selection) {

            $('#selectbanner').data('x', selection.x1);

            $('#selectbanner').data('y', selection.y1);

            $('#selectbanner').data('w', selection.width);

            $('#selectbanner').data('h', selection.height);

        }
        $(function () {
            //$("#divCut").draggable({ containment: "parent" }).resizable({ containment: "#divContent" });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="header">
        </div>
        <div id="content">
            <div id="swfu_container" style="margin: 0px 10px;">
                <div>
                    <span id="spanButtonPlaceholder"></span>
                </div>
                <div id="divFileProgressContainer" style="height: 75px;"></div>
                <div id="thumbnails"></div>
                <%--<img id="imgUrl" />--%>
                <%--<div id="divContent" style="width:300px;height:300px">
                    <div id="divCut" style="width:100px;height:100px;border:1px solid red">

                    </div>
                </div>--%>
                <img id="selectbanner" />
            </div>
        </div>
        <div>
            <img id="imgCut" src="#" />
        </div>
        <input type="button" value="Cut" id="btnCut" onclick="CutImg()"/>
    </form>
    <script type="text/javascript">
        function CutImg() {
            var ajax = BookShop.Web.test.SWFUploadDemo;
            //确定范围
            //var y = $("#divCut").offset().top - $("#divContent").offset().top;//纵坐标
            //var x = $("#divCut").offset().left - $("#divContent").offset().left;//横坐标
            //var width = $("#divCut").width();
            //var height = $("#divCut").height();
            var x = $('#selectbanner').data('x');
            var y = $('#selectbanner').data('y');
            var width = $('#selectbanner').data('w');
            var height = $('#selectbanner').data('h');
            var result = ajax.CutImage(x, y, width, height,imgurl).value;
            //alert(result);
            $("#imgCut").attr("src", result);
        }
    </script>
</body>
</html>
