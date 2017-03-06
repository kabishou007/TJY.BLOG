var $ = layui.jquery;
$(document).ready(function () {
  InitFixBar();
});

/* 生成页面右下角置顶按钮 */
function InitFixBar(){
   var util = layui.util;
  util.fixbar();//生成页面右下角置顶按钮
}

/* 顶部导航条的搜索按钮*/
$("#btnGO").click(function () {
    
});