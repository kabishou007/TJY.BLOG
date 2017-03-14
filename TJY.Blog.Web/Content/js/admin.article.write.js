var $ = layui.jquery;
var layedit = layui.layedit;
//建立富文本编辑器
var index = layedit.build('content', {
    height: 600
});

/*按钮 暂存为草稿*/
$("#btnSaveDraft").click(function () {
    var category = $("[name='category']").val();
    var title = $("[name='title']").val();
    var content = layedit.getContent(index);
    var layer = layui.layer;
    $.ajax({
        url: "/Admin/Article/Save",
        type: "POST",
        data: {
            CategoryID: categoryId,
            Title: title,
            Content: content
        },
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess == true) {
                layer.alert('文章已保存为草稿！', { icon: 1});
            } else {
                layer.alert('文章保存草稿失败！', { icon: 0 });
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("服务器发生了问题：" + textStatus.responsText + "|" + errorThrown, { icon: 2 });
        }
    });
});

/*按钮 保存并发布*/
$("#btnSaveDraft").click(function () {
    var categoryId = $("[name='category']").val();
    var title = $("[name='title']").val();
    var content = layedit.getContent(index);
    var layer = layui.layer;
    $.ajax({
        url: "/Admin/Article/SaveAndPublish",
        type: "POST",
        data: {
            CategoryID: categoryId,
            Title: title,
            Content: content
        },
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess == true) {
                layer.alert('文章已保存并发布！', { icon: 1 });
            } else {
                layer.alert('文章保存发布失败！', { icon: 0 });
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("服务器发生了问题：" + textStatus.responsText + "|" + errorThrown, { icon: 2 });
        }
    });
});