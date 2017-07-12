<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="DriveTravel.aspx.cs" Inherits="User_DriveTravel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link href="../css/DriveTravelStyle.css" rel="stylesheet" />

    <%--<style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
        }

        body, button, input, select, textarea {
            font: 12px/16px Verdana, Helvetica, Arial, sans-serif;
        }

        #container {
            min-width: 600px;
            min-height: 600px;
        }
    </style>
    <script charset="utf-8" src="http://map.qq.com/api/js?v=2.exp"></script>
    <script>
        var map,
            directionsService = new qq.maps.DrivingService({
                complete: function (response) {
                    var start = response.detail.start,
                        end = response.detail.end;

                    var anchor = new qq.maps.Point(6, 6),
                        size = new qq.maps.Size(24, 36),
                        start_icon = new qq.maps.MarkerImage(
                            'img/busmarker.png',
                            size,
                            new qq.maps.Point(0, 0),
                            anchor
                        ),
                        end_icon = new qq.maps.MarkerImage(
                            'img/busmarker.png',
                            size,
                            new qq.maps.Point(24, 0),
                            anchor

                        );
                    start_marker && start_marker.setMap(null);
                    end_marker && end_marker.setMap(null);
                    clearOverlay(route_lines);

                    start_marker = new qq.maps.Marker({
                        icon: start_icon,
                        position: start.latLng,
                        map: map,
                        zIndex: 1
                    });
                    end_marker = new qq.maps.Marker({
                        icon: end_icon,
                        position: end.latLng,
                        map: map,
                        zIndex: 1
                    });
                    directions_routes = response.detail.routes;
                    var routes_desc = [];
                    //所有可选路线方案
                    for (var i = 0; i < directions_routes.length; i++) {
                        var route = directions_routes[i],
                            legs = route;
                        //调整地图窗口显示所有路线    
                        map.fitBounds(response.detail.bounds);
                        //所有路程信息            
                        //for(var j = 0 ; j < legs.length; j++){
                        var steps = legs.steps;
                        route_steps = steps;
                        polyline = new qq.maps.Polyline(
                            {
                                path: route.path,
                                strokeColor: '#3893F9',
                                strokeWeight: 6,
                                map: map
                            }
                        )
                        route_lines.push(polyline);
                        //所有路段信息
                        for (var k = 0; k < steps.length; k++) {
                            var step = steps[k];
                            //路段途经地标
                            debugger;
                            directions_placemarks.push(step.placemarks);
                            //转向
                            var turning = step.turning,
                                img_position;;
                            switch (turning.text) {
                                case '左转':
                                    img_position = '0px 0px'
                                    break;
                                case '右转':
                                    img_position = '-19px 0px'
                                    break;
                                case '直行':
                                    img_position = '-38px 0px'
                                    break;
                                case '偏左转':
                                case '靠左':
                                    img_position = '-57px 0px'
                                    break;
                                case '偏右转':
                                case '靠右':
                                    img_position = '-76px 0px'
                                    break;
                                case '左转调头':
                                    img_position = '-95px 0px'
                                    break;
                                default:
                                    mg_position = ''
                                    break;
                            }
                            var turning_img = '&nbsp;&nbsp;<span' +
                                ' style="margin-bottom: -4px;' +
                                'display:inline-block;background:' +
                                'url(img/turning.png) no-repeat ' +
                                img_position + ';width:19px;height:' +
                                '19px"></span>&nbsp;';
                            var p_attributes = [
                                'onclick="renderStep(' + k + ')"',
                                'onmouseover=this.style.background="#eee"',
                                'onmouseout=this.style.background="#fff"',
                                'style="margin:5px 0px;cursor:pointer"'
                            ].join(' ');
                            routes_desc.push('<p ' + p_attributes + ' ><b>' + (k + 1) +
                            '.</b>' + turning_img + step.instructions);
                        }
                        //}
                    }
                    //方案文本描述
                    var routes = document.getElementById('routes');
                    routes.innerHTML = routes_desc.join('<br>');
                }
            }),
            directions_routes,
            directions_placemarks = [],
            directions_labels = [],
            start_marker,
            end_marker,
            route_lines = [],
            step_line,
            route_steps = [];

        function init() {
            map = new qq.maps.Map(document.getElementById("container"), {
                // 地图的中心地理坐标。
                center: new qq.maps.LatLng(39.916527, 116.397128)
            });
            calcRoute();
        }
        function calcRoute() {
            // var start_name = document.getElementById("start").value;
            // var end_name = document.getElementById("end").value;
            var start_name = document.getElementById("qidian").value;
            var end_name = document.getElementById("zhongdian").value;
            var policy = document.getElementById("policy").value;
            route_steps = [];

            directionsService.setLocation("成都");
            directionsService.setPolicy(qq.maps.DrivingPolicy[policy]);
            directionsService.search(start_name, end_name);
        }
        //清除地图上的marker
        function clearOverlay(overlays) {
            var overlay;
            while (overlay = overlays.pop()) {
                overlay.setMap(null);
            }
        }
        function renderStep(index) {
            var step = route_steps[index];
            //clear overlays;
            step_line && step_line.setMap(null);
            //draw setp line      
            step_line = new qq.maps.Polyline(
                {
                    path: step.path,
                    strokeColor: '#ff0000',
                    strokeWeight: 6,
                    map: map
                }
            )
        }
        //显示路段路标
        function showP() {
            var showPlacemark = document.getElementById('sp');
            if (showPlacemark.checked) {
                for (var i = 0; i < directions_placemarks.length; i++) {
                    var placemarks = directions_placemarks[i];
                    for (var j = 0; j < placemarks.length; j++) {
                        var placemark = placemarks[j];
                        var label = new qq.maps.Label({
                            map: map,
                            position: placemark.latLng,
                            content: placemark.name
                        });
                        directions_labels.push(label);
                    }
                }
            } else {
                clearOverlay(directions_labels);
            }
        }
    </script>

    <body onload="init();">
        <div style='margin: 5px 0px'>
            <div id="nav" style="width: 850px; height: 50px; margin-left: 250px;position:absolute;z-index:1;left:50px;">

                <b>起点: </b>
                <input type="text" id="qidian" placeholder="请输入起点" onchange="calcRoute()" />

                <b>终点: </b>
                <input type="text" id="zhongdian" placeholder="请输入终点" onchange="calcRoute()" />

                <input type="button" id="btn_sure" value="确定" onclick="calcRoute()" style="width: 50px; height: 40px;" />
                <b>计算策略：</b>
                <select id="policy" onchange="calcRoute();">
                    <option value="LEAST_TIME">最少时间</option>
                    <option value="LEAST_DISTANCE">最短距离</option>
                    <option value="AVOID_HIGHWAYS">避开高速</option>
                    <option value="REAL_TRAFFIC">实时路况</option>
                    <option value="PREDICT_TRAFFIC">预测路况</option>
                </select>
                <label>
                    <input id="sp" type="checkbox" value='1' onclick='showP()' />
                    显示路段地标
                </label>

            </div>

            <div id="container">
                <div id="routes" style="width: 400px; padding-top: 5px; position: absolute; z-index: 1; left: 50px;"></div>
            </div>
        </div>
    </body>--%>

     <script type="text/javascript" src="http://api.map.baidu.com/api? v=2.0& ak=28176ab538f60a16a72f6d7b4d261efe"></script>
        <div id="search-box">
            <asp:TextBox ID="txt_search" Text="" placeholder="寻找你想去的地方或目的地" runat="server" />
            <asp:Button ID="btn_search" runat="server" OnClientClick="initialize()" Text="搜索" Width="43px" Height="43px" />
        </div>
        <div id="l-map"></div>
      <div id="r-result"></div>
    <script type="text/javascript">
            // 百度地图API功能
            var didian = document.getElementById("ContentPlaceHolder2_txt_search").value;
            var map = new BMap.Map("l-map");
            map.centerAndZoom(new BMap.Point(104.388114, 31.100983), 12);

            var transit = new BMap.DrivingRoute(map, {
                renderOptions: {
                    map: map,
                    panel: "r-result",
                    enableDragging: true //起终点可进行拖拽
                },
            });
            transit.search("德阳", didian);
        </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

