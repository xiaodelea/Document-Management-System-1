//[Checked]
//载入。
//获取model对象，按键绑定。
$(document).ready(function () {
    refreshModel();
    buttonBinding();
});

//[Checked]
//按键绑定。
function buttonBinding() {
    $("#setChecked").click(setFlag);
    $("#setChecked").data('property', 'IsChecked');
    $("#setChecked").data('propertyValue', true);

    $("#setUnChecked").click(setFlag);
    $("#setUnChecked").data('property', 'IsChecked');
    $("#setUnChecked").data('propertyValue', false);

    $("#setNoted").click(setFlag);
    $("#setNoted").data('property', 'IsNoted');
    $("#setNoted").data('propertyValue', true);

    $("#setUnNoted").click(setFlag);
    $("#setUnNoted").data('property', 'IsNoted');
    $("#setUnNoted").data('propertyValue', false);

    $("#setGetAllChildren").click(setFlag);
    $("#setGetAllChildren").data('property', 'IsGetAllChildren');
    $("#setGetAllChildren").data('propertyValue', true);

    $("#setUnGetAllChildren").click(setFlag);
    $("#setUnGetAllChildren").data('property', 'IsGetAllChildren');
    $("#setUnGetAllChildren").data('propertyValue', false);

    $("#setGetAllChapters").click(setFlag);
    $("#setGetAllChapters").data('property', 'IsGetAllChapters');
    $("#setGetAllChapters").data('propertyValue', true);

    $("#setUnGetAllChapters").click(setFlag);
    $("#setUnGetAllChapters").data('property', 'IsGetAllChapters');
    $("#setUnGetAllChapters").data('propertyValue', false);

    $("#setBookmarked").click(setFlag);
    $("#setBookmarked").data('property', 'IsBookmarked');
    $("#setBookmarked").data('propertyValue', true);

    $("#setUnBookmarked").click(setFlag);
    $("#setUnBookmarked").data('property', 'IsBookmarked');
    $("#setUnBookmarked").data('propertyValue', false);

    $("#createChapterAuto").click(getChapters);
}

//[Checked]
//设置Flag。
//回调刷新控件。
function setFlag(event) {
    $(this).hide();
    $.post('/Services/SetDocumentFlag',
        { id: model.DocumentId, property: $(this).data('property'), value: $(this).data('propertyValue') },
        function (data, status) {
            if (status === 'success') {
                model = data;
            } else {
                console.log('"setFlag" failed.');
            }
            refreshContent();
        }
    );
}

//[Checked]
//刷新控件。
function refreshContent() {
    //更新查阅相关
    refreshButtonsCheckedboxes(model.IsChecked, 'setChecked', 'setUnChecked', 'isChecked');
    //更新笔记相关
    refreshButtonsCheckedboxes(model.IsNoted, 'setNoted', 'setUnNoted', 'isNoted');
    //更新书签相关
    refreshButtonsCheckedboxes(model.IsBookmarked, 'setBookmarked', 'setUnBookmarked', 'isBookmarked');
    //更新子节点相关
    refreshButtonsCheckedboxes(model.IsGetAllChildren, 'setGetAllChildren', 'setUnGetAllChildren', 'isGetAllChildren');
    //更新章节相关
    refreshButtonsCheckedboxes(model.IsGetAllChapters, 'setGetAllChapters', 'setUnGetAllChapters', 'isGetAllChapters');

    //新增相关
    refreshAddingButtons(model.IsGetAllChildren, 'createChild', 'cannotCreateChild');
    refreshAddingButtons(model.IsParentGetAllChildren, 'createSilbling', 'cannotCreateSilbling');
    refreshAddingButtons(model.IsParentGetAllChildren, 'createSilblingByUrl', 'cannotCreateSilblingByUrl');
    refreshAddingButtons(model.IsGetAllChildren, 'createChildByUrl', 'cannotCreateChildByUrl');
    refreshAddingButtons(model.IsGetAllChapters, 'createChapter', 'cannotCreateChapter');
    refreshAddingButtons(model.IsGetAllChapters, 'createChapterBatch', 'cannotCreateChapterBatch');
    refreshAddingButtons(model.IsGetAllChapters, 'createChapterAuto', 'cannotCreateChapterAuto');

    //更新数据显示
    refreshDataDisplay();
}





//[Checked]
//更新设置按钮、设置取消按钮、复选框相关
function refreshButtonsCheckedboxes(flag, id_Set, id_SetUn, id_Display) {
    if (flag) {
        $('#' + id_SetUn).show();
        $('#' + id_Set).hide();
        $('#' + id_Display).prop("checked", true);
    } else {
        $('#' + id_SetUn).hide();
        $('#' + id_Set).show();
        $('#' + id_Display).prop('checked', false);
    }
}

//[Checked]
//更新添加用按钮
function refreshAddingButtons(flag, id_Able, id_Unable) {
    if (flag) {
        $('#' + id_Able).hide();
        $('#' + id_Unable).show();
    } else {
        $('#' + id_Able).show();
        $('#' + id_Unable).hide();
    }
}

//[Checked]
//更新数据显示
function refreshDataDisplay() {
    //文档阅读时间。
    $('#totalMinutesToRead').get(0).innerHTML = model.TotalMinutesToRead;

    //完成Logo。
    if (model.IsFinished) {
        $('#isFinished').show();
    } else {
        $('#isFinished').hide();
    }
}





//var clipboard = new Clipboard('.btn');





//[Checked]
//重新获取model。
function refreshModel() {
    $.post('/Services/GetDocument',
        { id: model.DocumentId },
        function (data, status) {
            if (status === 'success') {
                model = data;
                refreshContent();
            } else {
                console.log('"refreshModel" failed.');
            }
        }
    );
}

function getChapters(event) {
    $.post('/Services/GetChapters',
        { DocumentId: model.DocumentId },
        function (data, status) {
            if (status == 'success') {
                if (data == true)
                    location.reload(true);
                else
                    alert('失败');
            } else {
                alert('失败');
            }
        }
    );
}