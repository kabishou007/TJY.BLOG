var $ = layui.jquery;
var form = layui.form();
form.verify({//自定义表单验证
    loginname: [/^[\S]{1,20}$/, '登录名不能为空，但也不能超过20位'],
    nickname: [/^[\S]{1,20}$/, '昵称不能为空，但也不能超过20位'],
    motto: [/^[\S]{0,50}$/, '人生格言神马的，不要太长...50位吧']
});

layui.upload({//图片上传
    url: '',
    before:function(){//上传前回调
        //var layer = layui.layer;
        //var index = layer.load();
    },
    success: function (res) {//上传成功的回调，res为返回值（json）

    }
});

$("#btnSave").click(function () {
    var loginname = $("[name='loginname']").val();
    var nickname = $("[name='nickname']").val();
    var email = $("[name='email']").val();
    var motto = $("[name='motto']").text();
    $.ajax({
        type: 'POST',
        url: '/Admin/Account/Edit',
        data: {
            LoginName: loginname,
            NickName: nickname,
            Email: email,
            Motto: motto
        },
        dataType: 'json',
        success: function (data) {
            if (data.IsSuccess) {//操作成功
                layer.alert('编辑信息成功！', { icon: 1 });
                parent.location.reload();
            } else {
                layer.alert('编辑信息保存失败！', { icon: 0 });  
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("服务器发生了问题：" + textStatus.responsText + "|" + errorThrown, { icon: 2 });
        }
    });
});

$("#btnCancel").click(function () {
    //iframe页内操作
    var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
    parent.layer.close(index); //再执行关闭
});