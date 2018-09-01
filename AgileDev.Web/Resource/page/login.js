layui.config({
    base: "/Resource/modules/"
}).use(['jax', 'form', 'nprogress'], function () {
    var form = layui.form;
    var nprogress = layui.nprogress;
    var $ = layui.$;
    var index = 0;
    //监听提交
    form.on('submit(btnSub)', function (data) {
        console.log(data.field);
        $.ajax({
            url: "/Account/Login",
            type: "post",
            dataType: "json",
            data: data.field,
            beforeSend: function () {
                nprogress.start();
            },
            success: function (data) {
                if (data.status == 200) {
                    location.href = data.jumpUrl;
                } else {
                    nprogress.done();
                    index = layer.alert(data.message);
                }
            },
            complete: function () {
            }
        });
        return false;
    });
    //自定义验证规则
    form.verify({
        username: function (value) {
            if (value.length == 0) {
                return '请输入用户名！';
            }
        }
      , password: function (value) {
          if (value.length == 0) {
              return '请输入密码！';
          }
      }
    });
    $(document).on("keydown", function (event) {
        if (event.keyCode == 13) {
            if (index > 0) {
                layer.close(index);
                index = 0;
            } else {
                $("#btnSub").click();
            }
        }
    })
})