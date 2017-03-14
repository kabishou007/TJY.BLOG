var $ = layui.jquery;
$("#btnEdit").click(function () {
    var layer = layui.layer;
    layer.open({
        type: 2,
        title: '编辑账户信息',
        area: ['500px'],
        content: ['/Admin/Account/Edit', 'no'] //iframe的url，no代表不显示滚动条
        //btn: ['保存', '取消'],
        //yes: function (index, layero) {//保存按钮的回调，index表示当前层索引，layero表示当前层DOM
            
        //},
        //btn2: function (index, layero) {//取消按钮回调
        //    layer.closeAll('iframe'); //关闭所有的iframe层
        //    //var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
        //    //parent.layer.close(index); //再执行关闭 
        //}
    });
});