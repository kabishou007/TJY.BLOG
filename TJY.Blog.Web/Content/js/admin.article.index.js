var $=layui.jquery;

/* 初始化加载 */
$(document).ready(function () {
    /* 初始化datatable并且获得Datatable对象，供后续调用api */
    $('#table').DataTable({
        scrollCollapse: true,//当数据达不到分页条数时，自适应表格高度
        //scrollY: "200px",//tbody的高度固定，超过此高度时，在此高度内滚动，表头是固定的
        searching: false,
        paging: true,//分页
        pageLength: 10,//初始每页数量
        ordering: true,//是否启用排序
        language: {
            lengthMenu: '每页<select><option value="5">5</option><option value="10" selected>10</option><option value="20">20</option><option value="50">50</option></select>条记录',//左上角的分页大小显示。
            paginate: {//分页的样式内容。
                previous: "上一页",
                next: "下一页",
                first: "首页",
                last: "末页"
            },
            processing: true,//表格处理或加载数据时的提示
            zeroRecords: "没有数据",//table tbody内容为空时，tbody的内容。
            //下面三者构成了总体的左下角的内容。
            info: "第_START_ 到第 _END_ 条，共_TOTAL_条",//左下角的信息显示，大写的词为关键字。
            infoEmpty: "0条记录",//筛选为空时左下角的显示。
        },
        pagingType: "full_numbers",//分页样式的类型
    });//初始化datatable表格
});

/* 表格多选 */
$('#table tbody').on('click', 'tr', function () {
    $(this).toggleClass('selected');
});


/* 查询表单交互切换效果*/
$("[name='searchmethod']").onselect(function () {
    var inputHtml = '<div class="layui-input-inline" style="width: 100px;"><input type="text" name="searchword" placeholder="请输入标题关键词" autocomplete="off" class="layui-input"></div>';
    if ($(this).val()=="title") {
        $("#searchBox").html(inputHtml);
    }
    else {
        GetSelectHtml();
    }
});

/*按category查询时，请求所有category数据，动态生成select*/
function GetSelectHtml(){
    $.ajax({
        url:"/Admin/Category/GetCategory",
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess == true) {
                var selectHtml = '<select name="searchmethod" style="width:100px;">';
                //循环得到的数据，生成option的html，最后添加到页面
                var optionList = data.Data;
                for (var i = 0; i < optionList.length; i++) {
                    selectHtml += '<option value="' + optionList[i].Id + '">'+optionList[i].Name+'</option>';
                }
                selectHtml += '</select>';
                $("#searchBox").html(inputHtml);
            } else {
                var layer=layui.layer;
                layer.alert('文章分类加载失败！');
                var selectHtml = '<select name="searchmethod" style="width:100px;"><option value="title" disabled>文章分类加载失败</option></select>';
                $("#searchBox").html(selectHtml);
            }
        },
        error: function (textStatus, errorThrown) {
            var layer=layui.layer;
            layer.alert("发生了错误：" + textStatus + "|" + errorThrown);
            var selectHtml = '<select name="searchmethod" style="width:100px;"><option value="title" disabled>发生了错误</option></select>';
            $("#searchBox").html(selectHtml);
        }
    });
}


function Search() {

}
