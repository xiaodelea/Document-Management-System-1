var clipboard = new Clipboard('.btn');

$(document).ready(function () {
    refreshContent();
    buttonBinding();
});





function buttonBinding() {
    $("#SetChecked").click(buttonHandlerSetChecked);
    $("#SetUnChecked").click(buttonHandlerSetUnChecked);
    //$("#SetNoted").click(buttonHandlerSetNoted);
    //$("#SetUnNoted").click(buttonHandlerSetUnNoted);
    $("#SetGetAllChildren").click(buttonHandlerSetGetAllChildren);
    $("#SetUnGetAllChildren").click(buttonHandlerSetUnGetAllChildren);
    $("#SetGetAllChapters").click(buttonHandlerSetGetAllChapters);
    $("#SetUnGetAllChapters").click(buttonHandlerSetUnGetAllChapters);
    $("#SetBookmarked").click(buttonHandlerSetBookmarked);
    $("#SetUnBookmarked").click(buttonHandlerSetUnBookmarked);
}

function buttonHandlerSetChecked(event) {
    document.getElementById('SetChecked').style.display = "none";
    $.post(urlServicesDocumentSetChecked,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetUnChecked(event) {
    document.getElementById('SetUnChecked').style.display = "none";
    $.post(urlServicesDocumentSetUnChecked,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetNoted(event) {
    document.getElementById('SetNoted').style.display = "none";
    $.post(urlServicesDocumentSetNoted,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetUnNoted(event) {
    document.getElementById('SetUnNoted').style.display = "none";
    $.post(urlServicesDocumentSetUnNoted,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetGetAllChildren(event) {
    document.getElementById('SetGetAllChildren').style.display = "none";
    $.post(urlServicesDocumentSetGetAllChildren,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetUnGetAllChildren(event) {
    document.getElementById('SetUnGetAllChildren').style.display = "none";
    $.post(urlServicesDocumentSetUnGetAllChildren,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetGetAllChapters(event) {
    document.getElementById('SetGetAllChapters').style.display = "none";
    $.post(urlServicesDocumentSetGetAllChapters,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetUnGetAllChapters(event) {
    document.getElementById('SetUnGetAllChapters').style.display = "none";
    $.post(urlServicesDocumentSetUnGetAllChapters,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetBookmarked(event) {
    document.getElementById('SetBookmarked').style.display = "none";
    $.post(urlServicesDocumentSetBookmarked,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}

function buttonHandlerSetUnBookmarked(event) {
    document.getElementById('SetUnBookmarked').style.display = "none";
    $.post(urlServicesDocumentSetUnBookmarked,
        null,
        function (data, status) {
            refreshFlag();
        }
    );
}





//刷新Flag相关控件
function refreshContent() {
    //更新查阅相关
    refreshButtonsCheckedboxes(flagIsChecked, 'SetChecked', 'SetUnChecked', 'IsChecked');
    //更新笔记相关
    //refreshButtonsCheckedboxes(flagIsNoted, 'SetNoted', 'SetUnNoted', 'IsNoted');
    //更新书签相关
    refreshButtonsCheckedboxes(flagIsBookmarked, 'SetBookmarked', 'SetUnBookmarked', 'IsBookmarked');
    //更新子节点相关
    refreshButtonsCheckedboxes(flagIsGetAllChildren, 'SetGetAllChildren', 'SetUnGetAllChildren', 'IsGetAllChildren');
    //更新章节相关
    refreshButtonsCheckedboxes(flagIsGetAllChapters, 'SetGetAllChapters', 'SetUnGetAllChapters', 'IsGetAllChapters');

    //新增子节点 按钮
    refreshAddingButtons(flagIsGetAllChildren, 'CreateChild', 'CannotCreateChild');
    refreshAddingButtons(flagIsGetAllChildren, 'CreateChildByUrl', 'CannotCreateChildByUrl');
    refreshAddingButtons(flagIsGetAllChapters, 'CreateChapter', 'CannotCreateChapter');
    refreshAddingButtons(flagIsGetAllChapters, 'CreateChapterBatch', 'CannotCreateChapterBatch');

    //更新数据显示
    refreshDataDisplay();
}

//重新获取Flag
function refreshFlag() {
    $.post(urlServicesGetDocument,
        null,
        function (data, status) {
            flagIsChecked = data.IsChecked;
            flagIsNoted = data.IsNoted;
            flagIsGetAllChildren = data.IsGetAllChildren;
            flagIsGetAllChapters = data.IsGetAllChapters;
            flagIsBookmarked = data.IsBookmarked;
            intTotalMinutesToRead = data.TotalMinutesToRead;

            refreshContent();
        },
        'json'
    );
}

//更新设置按钮、设置取消按钮、复选框相关
function refreshButtonsCheckedboxes(flag, id_Set, id_SetUn, id_Display) {
    if (flag) {
        document.getElementById(id_SetUn).style.display = "";
        document.getElementById(id_Set).style.display = "none";
        document.getElementById(id_Display).checked = true;
    } else {
        document.getElementById(id_SetUn).style.display = "none";
        document.getElementById(id_Set).style.display = "";
        document.getElementById(id_Display).checked = false;
    }
}

//更新添加用按钮
function refreshAddingButtons(flag, id_Able, id_Unable) {
    if (flag) {
        document.getElementById(id_Able).style.display = "none";
        document.getElementById(id_Unable).style.display = "";
    } else {
        document.getElementById(id_Able).style.display = "";
        document.getElementById(id_Unable).style.display = "none";
    }
}

function refreshDataDisplay() {
    document.getElementById('TotalMinutesToRead').innerHTML = intTotalMinutesToRead;
}