$(function () {
    toastr.options.positionClass = 'toast-top-center';
    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();
 
    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();

    FormValidator();
});
var FormValidator = function () {

    //校验
    $('#table').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            DoHour: {
                message: '工时验证失败',
                validators: {
                    notEmpty: {
                        message: '工时不能为空'
                    },
                    regexp: {
                        regexp: /^[1-9]\d*$/,
                        message: '工时需大于0'
                    }
                }

            },
            Stepname: {
                message: '步骤名称验证失败',
                validators: {
                    notEmpty: {
                        message: '步骤名称不能为空'
                    }
                }
            },
            StepID: {
                message: '步骤验证失败',
                validators: {
                    notEmpty: {
                        message: '步骤不能为空'
                    }
                }
            },
            Processname: {
                message: '流程名称验证失败',
                validators: {
                    notEmpty: {
                        message: '流程名称不能为空'
                    }
                }
            },
        },
        submitButtons: '#btn_submit',
        submitHandler: function (validator, form, submitButton) {
            alert("submit");
        }
    });

}

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_process').bootstrapTable({
            url: '/Home/GetDepartment',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "ID",                     //每一行的唯一标识，一般为主键列
            showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                checkbox: true
            },
          
            {
                field: 'Processname',
                title: '流程名称'
            }, {
                field: 'Stepname',
                title: '步骤名'
            }, {
                field: 'DoHour',
                title: '工时'
            },]
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            processname: $("#txt_search_processname").val(),
            stepname: $("#txt_search_stepname").val()
        };
        return temp;
    };
    return oTableInit;
};


var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        //初始化页面上面的按钮事件
        $("#btn_add").click(function () {
            $("#myModalLabel").text("新增");
            $('#myModal').modal();
            $("#Processname").val('');
            $("#StepID").val('');
            $("#Stepname").val('');
            $("#DoHour").val('0');
            postdata.ID = "";
            $("#table").data('bootstrapValidator').destroy();
            $('#table').data('bootstrapValidator', null);
            FormValidator();
        });

        $("#btn_edit").click(function () {
            var arrselections = $("#tb_process").bootstrapTable('getSelections');
            if (arrselections.length > 1) {
                toastr.warning('只能选择一行进行编辑');

                return;
            }
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');

                return;
            }
            $("#myModalLabel").text("编辑");
            $("#Processname").val(arrselections[0].Processname);
            $("#StepID").val(arrselections[0].StepID);
            $("#Stepname").val(arrselections[0].Stepname);
            $("#DoHour").val(arrselections[0].DoHour);

            postdata.ID = arrselections[0].id;
            $('#myModal').modal();
        });

        $("#btn_delete").click(function () {
            var arrselections = $("#tb_process").bootstrapTable('getSelections');
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }

            swal({
                title: "操作提示",      //弹出框的title
                text: "确定删除吗？",   //弹出框里面的提示文本
                type: "warning",        //弹出框类型
                showCancelButton: true, //是否显示取消按钮
                confirmButtonColor: "#DD6B55",//确定按钮颜色
                cancelButtonText: "取消",//取消按钮文本
                confirmButtonText: "是的，确定删除！",//确定按钮上面的文档
                closeOnConfirm: true
            }, function () {
                $.ajax({
                    type: "post",
                    url: "/Home/Delete",
                    dataType: "json",
                    data: { "id": arrselections[0].id   },
                    success: function (data, status) {
                        if (data.status == "ok") {
                            toastr.success('删除数据成功');
                          
                        }
                        else {
                            toastr.success('删除数据失败');
                  
                        }
                        $("#tb_process").bootstrapTable('refresh');
                    },
                    error: function () {
                        toastr.error('Error');
                    },
                    complete: function () {

                    }

                });
            });
        });

        $("#btn_submit").click(function () {
 
            $.ajax({
                type: "post",
                url: "/Home/GetEdit",
                data: {
                    "id": postdata.ID,
                    "Processname": $("#Processname").val(),
                    "StepID":$("#StepID").val(),
                    "Stepname":$("#Stepname").val(),
                    "DoHour":$("#DoHour").val(),

                },
                success: function (data, status) {
                    if (data.status == "ok") {
                        toastr.success('保存数据成功');

                    }
                    else {
                        toastr.success('保存数据失败');

                    }
                    $("#tb_process").bootstrapTable('refresh');
                    $('#myModal').modal('hide');
                },
                error: function () {
                    toastr.error('Error');
                },
                complete: function () {

                }

            });
        });

        $("#btn_query").click(function () {
            $("#tb_process").bootstrapTable('refresh');
        });
    };

    return oInit;
};