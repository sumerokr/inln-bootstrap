if ($('.fancybox').length > 0) {
    $('.fancybox').fancybox();
}

if ($('.popovers').length > 0) {
    $('.popovers').popover({placement: 'bottom'});
}

if ($('.sortable').length > 0) {
    $('.sortable').sortable({
        axis: 'y',
        placeholder: 'lol'
    });
}

// костыль для вьюшек просмотра информации
if ($('.display-label').length > 0) {
    $('.display-label').wrapInner('<span></span>');
}

$('#get-order').on('click', function () {
    var orderData = $('.sortable').sortable('serialize', { key: 'client' });
    $.ajax({
        url: '/Admin/Client/OrderSave',
        data: orderData,
        success: function () {
            alert('Порядок сохранен');
        },
        error: function () {
            alert('Кажется, что-то пошло не так..');
        }
    });
});
