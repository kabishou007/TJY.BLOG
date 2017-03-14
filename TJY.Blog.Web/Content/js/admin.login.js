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
                window.location.href = data.Data;//��¼�ɹ�ʱ���ݷ��������ص�url��ת
            } else {
                layer.alert('�˻����������', {icon:0});
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("���������������⣺" + textStatus.responsText + "|" + errorThrown, { icon: 2 });
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
                layer.alert("�����ѷ�������������Ŷ~");
            } else {
                layer.alert("�����Ҳ����ˣ���ϵ����Ա�ɣ�");
            }
        },
        error: function (textStatus, errorThrown) {
            layer.alert("��������������" + textStatus + "|" + errorThrown);
        }
    });
});