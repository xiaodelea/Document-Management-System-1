function gotoDetails(event) {
    location.href = ($(event).data("url"));
}

function setChecked(id) {
    setFlag(id, 'IsChecked', true);
}





function setFlag(id, property, value) {
    $.post('/Services/SetDocumentFlag',
        {
            id: id,
            property: property,
            value: value,
        },
        function (data, status) {
            if (status === 'success') {
                window.location.reload();
            } else {
                console.log('"setFlag" failed.');
            }
        }
    );
}





$(document).on('keypress', function (event) {
    event.preventDefault = true;

    if (event.keyCode == 38) {
        $('#parent-node').get(0).click();
    } else if (event.keyCode == 37) {
        $('#pre-node').get(0).click();
    } else if (event.keyCode == 39) {
        $('#post-node').get(0).click();
    } else {

    }
});