var $ = layui.jquery;
$("#login").click(function () {
    var loginName=$("[name='loginname']").val();
    var password= $("[name='password']").val();
    var layer = layui.layer;
    $.ajax({
        url: "/Admin/Account/Login",
        type: "POST",
        data: {
            loginName: loginName,
            password: password
        },
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess == true) {
                window.location.href = data.Data;//登录成功时根据服务器返回的url跳转
            } else {
                layer.alert('账户或密码错误！', {icon:0});
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("服务器发生了问题：" + textStatus.responsText + "|" + errorThrown, { icon: 2 });
        }
    });
});

$("#forgetPwd").click(function () {
    var layer = layui.layer;
    $.ajax({
        url: "/Admin/Account/ForgetPwd",
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data.IsSuccess == true) {
                layer.alert("密码已发送至您的邮箱哦~");
            } else {
                layer.alert("密码找不到了，联系管理员吧！");
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("服务器出错啦：" + textStatus + "|" + errorThrown);
        }
    });
});