
var iscreatr = false;
//var ad = document.getElementById("<%=ContentPlaceHolder2_txt_search%>").value;

function initialize() {
    var ad = document.getElementById('ContentPlaceHolder2_txt_search').value;

    var points = [];//定义一个坐标数组
    var count = 0;//定义坐标点计数

    //---------将标记点保存在字符串中-----------------
    var getRouteStr = function (pos) {
        var str = "";
        for (var i = 0; i < pos.length; i++) {
            str += pos[i].xpoint.lng + "," + pos[i].point.lat + ";";
        }
    }
    //---------将标记点保存在字符串中结束-----------------



    //---------------------------------------------基础示例---------------------------------------------
    var map = new BMap.Map("allmap", { minZoom: 12, maxZoom: 20 });  // 创建Map实例
    //map.centerAndZoom(new BMap.Point(116.4035,39.915),15);  //初始化时，即可设置中心点和地图缩放级别。

    //通过搜索框获取目标城市,后交给ad
    map.centerAndZoom(ad, 15);  // 初始化地图,设置中心点坐标和地图级别。

    map.enableScrollWheelZoom(true);//鼠标滑动轮子可以滚动

    map.addEventListener("click", function (e) {
        //经纬度
        document.getElementById("ContentPlaceHolder2_tx_latitude").value = e.point.lng + ", " + e.point.lat;
        //var point = new BMap.Point(e.point.lng, e.point.lat);//将经纬度交给Point
    });
    //---------------------------------------------基础示例结束-------------------------


    //-----------------------------计算距离------------------------------------//


    var getDis = function (pots) {
        var s = 0.0;
        for (var i = 1; i < points.length; i++) {
            var disz = map.getDistance(pots[i - 1], pots[i]);
            s += parseFloat(disz);
        }
        return (s / 1000).toFixed(2) + "公里";
    }

    //------------------------------计算距离结束------------------------------//



    //---------------------------------------------鼠标右键（放大，缩小）操作---------------------------------------------
    var menu = new BMap.ContextMenu(); //右键菜单

    var txtMenuItem = [  //右键菜单项目
        {
            text: '在此添加标注',
            callback: function (p) {
                var marker = new BMap.Marker(p), px = map.pointToPixel(p);//坐标经纬度

                points[count] = p;//将坐标经纬度装入坐标数组
                count++;//记数点自增
                map.addOverlay(marker);//在地图上添加标记

                //当标记点大于1的时候
                if (count > 1) {
                    //划线
                    var polyline = new BMap.Polyline(points, { strokeColor: "blue", strokeWeight: 3, strokeOpacity: 0.5 });
                    map.addOverlay(polyline);
                }
                document.getElementById("ContentPlaceHolder2_tx_dis").value = getDis(points);

                //--------------------右键标记后在将地图名字显示出来-------------------------//
                var gc = new BMap.Geocoder();//地图解析
                //将坐标p交给Location
                gc.getLocation(p, function (rs) {
                    var addComp = rs.addressComponents;//获取位置对象
                    document.getElementById("ContentPlaceHolder2_tx_destination").value = addComp.province + addComp.city + addComp.district + addComp.street + addComp.streetNumber;
                    // + addComp.district + addComp.street + addComp.streetNumber
                    // documnet.getElementById("ContentPlaceHolder2_lab_place").innerHTML = addComp.province + addComp.city;

                });
                //--------------------------------------------------------------------------//

                //----------定义ajax,保存为JSON格式方便调用----------


                $(function () {

                    $("#ContentPlaceHolder2_btn_sure").onlick = function () {
                        alert('aa')
                        $.getJSON("commitroute.aspx", { "route": getRouteStr(points) }, function (data) {
                            switch (data.code) {
                                case 0: alert("成功!"); break;
                                default: alert("失败!"); break;
                            }
                        });
                    }
                })


                //------------------------------------------------------


            }
        },



        {
            text: '放大',
            callback: function () { map.zoomIn() }
        },
        {
            text: '缩小',
            callback: function () { map.zoomOut() }
        },
        {
            text: '放置到最大级',
            callback: function () { map.setZoom(18) }
        },
        {
            text: '查看全国',
            callback: function () { map.setZoom(1) }
        }
    ];


    for (var i = 0; i < txtMenuItem.length; i++) {
        menu.addItem(new BMap.MenuItem(txtMenuItem[i].text, txtMenuItem[i].callback, 100)); //菜单添加项目
        if (i == 1 || i == 3) {
            menu.addSeparator();  //添加右键菜单的分割线
        }
    }

    map.addContextMenu(menu);

}

function loadScript() {
    var script = document.createElement("script");
    script.src = "http://api.map.baidu.com/api?v=1.4&callback=initialize";
    document.body.appendChild(script);
}

window.onload = loadScript;
