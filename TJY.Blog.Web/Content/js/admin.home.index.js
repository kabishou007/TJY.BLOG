/* 点击侧边栏菜单，添加tab页*/
function AddTab(tabTitle, srctUrl) {
    var element = layui.element();//加载element模块
    var $ = layui.jquery; //获得layui中内置的jquery组件，后续可以用jquery的方式操作dom
    var isAdded = false;
    var tabIndex;
    $('.layui-tab-title').children('li').each(function (i) {//遍历所有tab，判断是否要添加的tab已存在
        if ($(this).text().indexOf(tabTitle) >= 0) {//这里之所以用indexOf,一是js的字符串没有contains方法，二是layui生成的text有其它字符，因此不用==比较
            isAdded = true;
            tabIndex = i;
            return false;//停止遍历
        }
    });
    if (isAdded == false) {//当要添加的tab不存在时，添加新tab，并获取其index
        element.tabAdd('mainTab', {
            title: tabTitle,
            content: GenerateTabContent(tabTitle, srctUrl)
        });
        tabIndex = $('.layui-tab-title').children('li').length - 1;
    }
    element.tabChange('mainTab', tabIndex);//切换到当前index的tab
}

/* 生成tab内容页的html  */
function GenerateTabContent(tabTitle, srctUrl) {
    return '<iframe name="' + tabTitle + '" src="' + srctUrl + '" onload="ResizeFrame(\'' + tabTitle + '\')" width="100%" height="90%" frameborder="0"></iframe>';
}

/*
 * 重新设置iframe的大小，使其铺满父窗口
 * tip1：只有iframe的父div设置了height为100%，iframe才会表现出height为100%
 * tip2：layui生成的tabcontent下面每个内容都用div包裹，因此必须iframe的父div的父div先设置height=100%
 */
function ResizeFrame(tabTitle) {
    var $ = layui.jquery;
    $("[name='" + tabTitle + "']").parent().height("100%");
}