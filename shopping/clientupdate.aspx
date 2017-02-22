<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="clientupdate.aspx.cs" Inherits="clientupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
      
        label {
            font-weight: normal !important;
        }

        .required:after {
            content: "*";
            color: red;
        }

        .form-control {
            width: 57%;
            float: left;
        }     

        .title {
            font-weight: bold;
            border-bottom: 1px solid #e5e5e5;
            width: 100%;
            display: block;
            margin-bottom: 10px;
        }

        .slash {
            width: 3%;
            float: left;
            vertical-align: middle;
            text-align: center;
            line-height: 32px;
        }

        .expiredWidth {
            width: 27% !important;
        }

        .file {
            visibility: hidden;
            position: absolute;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="form-group">
            <label for="inputCode" class="col-sm-4 control-label">Time</label>
            <div class="col-sm-8">
                <input type="text" readonly="true" class="form-control" runat="server" id="inputCode" />
            </div>
        </div>
     <div class="form-group"  id="divRadio1" runat="server" >
              <label class="col-sm-4 control-label">Payment Mode</label>
                <div class="col-sm-8">
                    <label class="radio-inline">
                        <input type="radio" name="paymentradio"  onchange="setAccountType(this);" runat="server" id="rdStart" />Start Job</label>                   
                </div>
            </div>
     <div class="form-group" id="divRadio" runat="server">
         <label class="col-sm-4 control-label">Payment Mode</label>
         <div class="col-sm-8">
              <label class="radio-inline">
                        <input type="radio" name="paymentradio"  onchange="setAccountType(this);" runat="server" id="rdFinish" />Finish</label>
            </div>    
    </div>
   <div class="form-group">
       <label class="col-sm-4 control-label"></label>
         <div class="col-sm-8">
              <label class="radio-inline">
                  <input type="radio" name="paymentradio" onchange="setAccountType(this);" runat="server"  value="Cancel" id="rdCancel" />Cancel</label>
            </div>    
    </div>
     <div class="form-horizontal" id="divHidden" hidden="hidden">
         <label for="inputRemark" class="col-sm-4 control-label">Reason</label>
         <div class="col-sm-8 required">             
                 <textarea class="form-control" row="2" runat="server" id="inputRemark" />
         </div>    
    </div>
        <div class="col-sm-6">
          <div id="jssor_2" style="position:relative;margin:0 auto;top:0px;left:0px;width:400px;height:300px;overflow:hidden;visibility:hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position:absolute;display:block;background:url('img/loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
        </div>
        <div data-u="slides" style="cursor:default;position:relative;top:0px;left:0px;width:400px;height:300px;overflow:hidden;">
            <asp:Literal ID="ltlCarouselImages" runat="server" />        
        </div>
        <!-- Thumbnail Navigator -->
        <div data-u="thumbnavigator" class="jssort03" style="position:absolute;left:0px;bottom:0px;width:400px;height:60px;" data-autocenter="1">
            <div style="position: absolute; top: 0; left: 0; width: 100%; height:100%; background-color: #000; filter:alpha(opacity=30.0); opacity:0.3;"></div>
            <!-- Thumbnail Item Skin Begin -->
            <div data-u="slides" style="cursor: default;">
                <div data-u="prototype" class="p">
                    <div class="w">
                        <div data-u="thumbnailtemplate" class="t"></div>
                    </div>
                    <div class="c"></div>
                </div>
            </div>
            <!-- Thumbnail Item Skin End -->
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora02l" style="top:0px;left:8px;width:55px;height:55px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora02r" style="top:0px;right:8px;width:55px;height:55px;" data-autocenter="2"></span>
    </div>
            </div>
              <div class="form-group" runat="server" style="margin: 0 auto; width: 31%">
            <div class="col-sm-12">               
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"/>
                <button onclick="javascript:history.go(-1); return false;">Back</button>
            </div>
       </div>   
                <script src="js/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="js/jssor.slider-22.1.7.mini.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            var jssor_2_options = {
              $AutoPlay: true,
              $ArrowNavigatorOptions: {
                $Class: $JssorArrowNavigator$
              },
              $ThumbnailNavigatorOptions: {
                $Class: $JssorThumbnailNavigator$,
                $Cols: 9,
                $SpacingX: 3,
                $SpacingY: 3,
                $Align: 260
              }
            };

            var jssor_2_slider = new $JssorSlider$("jssor_2", jssor_2_options);

            /*responsive code begin*/
            /*you can remove responsive code if you don't want the slider scales while window resizing*/
            function ScaleSlider() {
                var refSize = jssor_2_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 500);
                    jssor_2_slider.$ScaleWidth(refSize);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }
            ScaleSlider();
            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            /*responsive code end*/
        });
    </script>
    <style>        
        .jssora02l, .jssora02r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 55px;
            height: 55px;
            cursor: pointer;
            background: url('img/a02.png') no-repeat;
            overflow: hidden;
        }
        .jssora02l { background-position: -3px -33px; }
        .jssora02r { background-position: -63px -33px; }
        .jssora02l:hover { background-position: -123px -33px; }
        .jssora02r:hover { background-position: -183px -33px; }
        .jssora02l.jssora02ldn { background-position: -3px -33px; }
        .jssora02r.jssora02rdn { background-position: -63px -33px; }
        .jssora02l.jssora02lds { background-position: -3px -33px; opacity: .3; pointer-events: none; }
        .jssora02r.jssora02rds { background-position: -63px -33px; opacity: .3; pointer-events: none; }
        /* jssor slider thumbnail navigator skin 03 css *//*.jssort03 .p            (normal).jssort03 .p:hover      (normal mouseover).jssort03 .pav          (active).jssort03 .pdn          (mousedown)*/.jssort03 .p {    position: absolute;    top: 0;    left: 0;    width: 62px;    height: 32px;}.jssort03 .t {    position: absolute;    top: 0;    left: 0;    width: 100%;    height: 100%;    border: none;}.jssort03 .w, .jssort03 .pav:hover .w {    position: absolute;    width: 60px;    height: 30px;    border: white 1px dashed;    box-sizing: content-box;}.jssort03 .pdn .w, .jssort03 .pav .w {    border-style: solid;}.jssort03 .c {    position: absolute;    top: 0;    left: 0;    width: 62px;    height: 32px;    background-color: #000;    filter: alpha(opacity=45);    opacity: .45;    transition: opacity .6s;    -moz-transition: opacity .6s;    -webkit-transition: opacity .6s;    -o-transition: opacity .6s;}.jssort03 .p:hover .c, .jssort03 .pav .c {    filter: alpha(opacity=0);    opacity: 0;}.jssort03 .p:hover .c {    transition: none;    -moz-transition: none;    -webkit-transition: none;    -o-transition: none;}* html .jssort03 .w {    width /**/: 62px;    height /**/: 32px;}
    </style>
    <script type="text/javascript">
        var setAccountType = function (typeRadio) {
            if (typeRadio.value == "Cancel") {
                $('#divHidden').show(1000);
            } else {
                $('#divHidden').hide(1000);
            }
        };       
    </script>
    <input id="idhidden" runat="server" type="hidden" />
    <input id="idbooking" runat="server" type="hidden" />
    <input id="clconfirm" runat="server" type="hidden" />
    <input id="proconfirm" runat="server" type="hidden" />
    <input id="deliveryconfirm" runat="server" type="hidden" />
    <input id="clremark" runat="server" type="hidden" />
    <input id="proremark" runat="server" type="hidden" />
    <input id="deliremark" runat="server" type="hidden" />
    <input id="createddate" runat="server" type="hidden" />
    <input id="modifieddate" runat="server" type="hidden" />
    <input id="datetime" runat="server" type="hidden" />

</asp:Content>
