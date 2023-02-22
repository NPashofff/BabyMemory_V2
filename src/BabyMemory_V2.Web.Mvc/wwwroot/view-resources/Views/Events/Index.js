(function ($) {
    const _eventService = abp.services.app.event,
        l = abp.localization.getSource('BabyMemory_V2'),
        _$modal = $('#EventModal'),
        _$form = _$modal.find('form'),
        _$table = $('#EventTable');

    var _$eventTable = _$table.translatedDataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#EntitySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            abp.ui.setBusy(_$table);
           
            _eventService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$eventTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column',
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'eventDate',
                sortable: false
            },           
            {
                targets: 2,
                data: 'name',
                sortable: false
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false, className: "inline-flex",
                defaultContent: '',
                render: (data, type, row, meta) => {
                    //if (!abp.auth.isGranted("Edit")) {
                    //    return null;
                    //}
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit" data-id="${row.id}" data-toggle="modal" data-target="#EventModal">`,
                        `       <i class="fas fa-pencil-alt"></i>`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger deleter" data--id="${row.id}" data--name="${row.name}">`,
                        `       <i class="fas fa-trash"></i>`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });
    
    $('.btn-search').on('click', (e) => {
        _$eventTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$eventTable.ajax.reload();
            return false;
        }
    });
})(jQuery);