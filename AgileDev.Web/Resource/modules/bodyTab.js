layui.config({
    base: "/Resource/js/modules/"
}).define(["element", 'nprogress'], function (exports) {
    var element = layui.element;
    var nprogress = layui.nprogress;
    var $ = layui.$;
    var Tab = function () {
        this.tabConfig = {
            closed: true,
            maxTabNum: undefined,  //最大可打开窗口数量
            tabFilter: "bodyTab"  //添加窗口的filter
        }
    };

    Tab.prototype.init = function (options) {
        var _this = this;
        _this.tabConfig = $.extend(true, _this.tabConfig, options);

        $("[lay-filter='" + _this.tabConfig.tabFilter + "']").on("click", ".top_tab li i.layui-tab-close", function () {
            element.tabDelete(_this.tabConfig.tabFilter, $(this).parent("li").attr("lay-id")).init();
        })
        $("[lay-filter='" + _this.tabConfig.tabFilter + "']").on("click", ".oper_tab .refresh,.closePageOther,.closePageAll", function () {
            var _self = $(this);
            if (_self.hasClass("refresh")) {

                $("iframe[lay-id=" + _this.curLayId() + "]").attr('src', $("iframe[lay-id=" + _this.curLayId() + "]").attr('src'));

            } else if (_self.hasClass("closePageOther")) {

                $("[lay-filter='" + _this.tabConfig.tabFilter + "'] .top_tab li").each(function () {
                    if (!$(this).hasClass("isfirst") && !$(this).hasClass("layui-this")) {
                        var layid = $(this).attr("lay-id");
                        element.tabDelete(_this.tabConfig.tabFilter, layid)
                    }
                })

            } else if (_self.hasClass("closePageAll")) {

                $("[lay-filter='" + _this.tabConfig.tabFilter + "'] .top_tab li").each(function () {
                    if (!$(this).hasClass("isfirst")) {
                        var layid = $(this).attr("lay-id");
                        element.tabDelete(_this.tabConfig.tabFilter, layid)
                    }
                })
            }
        })
        return _this;
    }
    Tab.prototype.curLayId = function () {
        var curNode = $("[lay-filter='" + this.tabConfig.tabFilter + "']").find(".layui-this");
        var layid = curNode.attr("lay-id");
        return layid;
    }
    Tab.prototype.tabAdd = function (_this) {
        var _that = this;
        var closed = _that.tabConfig.closed;
        var maxTabNum = _that.tabConfig.maxTabNum;
        var tabFilter = _that.tabConfig.tabFilter;
        if (_this.attr("data-url") != undefined) {
            var layid = _this.attr("lay-id") || (function () {
                var timestamp = new Date().getTime();
                _this.attr("lay-id", timestamp);
                return timestamp;
            })();
            var tab_top = $("[lay-filter='" + tabFilter + "'] .top_tab");
            var isTab = tab_top.find("li[lay-id=" + layid + "]").length > 0;
            //已打开的窗口中不存在
            if (!isTab) {
                if ($(".layui-tab-title.top_tab li").length == maxTabNum) {
                    layer.msg('只能同时打开' + maxTabNum + '个选项卡哦。不然系统会卡的！');
                    return;
                }
                nprogress.start();
                element.tabAdd(tabFilter, {
                    title: function () {
                        var title = _this.attr("data-icon") ? '<i class="iconfont ' + _this.attr("data-icon") + '"></i>' : '';
                        title += '<cite>' + _this.find("cite").text() + '</cite>';
                        title += '<i class="layui-icon layui-unselect layui-tab-close">&#x1006;</i>';
                        return title;
                    }(),
                    content: "<iframe src='" + _this.attr("data-url") + "' lay-id='" + layid + "'></frame>",
                    id: layid
                })
                $("iframe[lay-id="+layid+"]").on("load", function () {
                    nprogress.done();
                });
            }
            element.tabChange(tabFilter, layid);
        }
    }
    exports("bodyTab", function (option) {
        return new Tab().init(option);
    });
})
