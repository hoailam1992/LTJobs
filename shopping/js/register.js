$(document).on('click', '.browse', function () {
    var file = $(this).parent().parent().parent().find('.file');
    file.trigger('click');
});
$(document).on('change', '.file', function () {
    $(this).parent().find('.form-control').val($(this).val().replace(/C:\\fakepath\\/i, ''));
});
var setAccountType = function (typeRadio) {
    var accountType = ['memberInfomation', 'hotelInformation', 'clientInformation'];
    $('input:radio[name="accounttyperadio"]').change(function (radio) {
        switch (typeRadio.value) {
            case 'client':
                $('div.clientInformation').show();
                break;
            case 'member':
                $('div.memberInfomation').show();
                break;
            case 'hotel':
                $('div.hotelInformation').show();
                break;
        }
        for (var i = 0; i < accountType.length; i++) {
            if (accountType[i].indexOf(typeRadio.value) < 0) {
                $('div.' + accountType[i]).hide();
            }

        }
    });
}
