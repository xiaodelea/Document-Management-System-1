var nodenameChanged = false;

$('#Title').bind('input propertychange', function () {
    if (!nodenameChanged)
        $('#NodeName').val($('#Title').val());
})

$('#NodeName').bind('input', function () {
    nodenameChanged = true;
})