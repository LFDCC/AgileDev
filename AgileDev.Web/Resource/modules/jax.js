layui.define(['layer'], function (e) {
    var layer = layui.layer;
    var $ = layui.$;
    //var loading = 0;
    $.ajaxSetup({
        headers: { Token: $(':input[name=__RequestVerificationToken]').val() },
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        beforeSend: function () {
            //loading = layer.msg('数据请求中', { icon: 16, time: false });
        },
        complete: function (XMLHttpRequest, textStatus) {
            //layer.close(loading);
            var redirect = XMLHttpRequest.responseJSON.redirect;
            var timeout = XMLHttpRequest.responseJSON.status === 204;
            if (timeout) {
                //如果超时就处理 ，指定要跳转的页面
                top.window.location = redirect || "/Account/Login";
            }
        },
        error: function (XMLHttpRequest) {
            var message = XMLHttpRequest.responseJSON.message;
            layer.msg('异常！' + message, { icon: 15, time: 1200, shade: 0 });
        }
    });
    e('jax', {});
})