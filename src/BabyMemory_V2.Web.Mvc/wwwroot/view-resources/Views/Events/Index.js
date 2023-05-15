

(function ($) {
    const _eventService = abp.services.app.event,
        l = abp.localization.getSource('BabyMemory_V2'),
        _$modal = $('#EventModal'),
        _$form = _$modal.find('form'),
        _$table = $('#EventTable'),
        _$createButon = $('#CreateButton');

    const _$eventTable = _$table.translatedDataTable({
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
                data: null,
                sortable: false,
                render: (data, type, row, meta) => {
                    return window.moment(row.eventDate).format('DD/MM/YYYY HH:mm');
                }
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
                    const result = abp.session.userId == row.userId
                        ? [
                            `   <button type="button" class="btn btn-sm bg-secondary ml-1 edit-event" title="${l("Edit")}" data-event-id="${row.id}" data-toggle="modal" data-target="#EventModal">`,
                        `       <i class="fas fa-pencil-alt"></i>`,
                        '   </button>',
                            `   <button type="button" class="btn btn-sm bg-danger ml-1 deleter" title="${l("Delete")}" data-event-id="${row.id}" data-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i>`,
                        '   </button>'
                        ]
                        : [`   <button type="button" class="btn btn-sm bg-secondary ml-1 join-event" title="${l("JoinEvent")}" data-event-id="${row.id}" data-name="${row.name}">`,
                            `<i class="fa fa-plus-circle"></i>`,
                            '   </button>'];

                    result.unshift(
                        `   <button type="button" class="btn btn-sm bg-secondary event-details ml-1" title="${l("Details")
                        }" data-event-id="${row.id}" data-name="${row.name}">`,
                        `<i class="fas fa-bars"></i>`,
                        '   </button>');

                    return result.join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        let eventId = _$form.find("#Id").val();
        if (eventId == "") {
            eventId = 0;
            _$form.find("#Id").val(eventId);
        }
        const event = _$form.serializeFormToObject();

        const usedFunction = eventId == 0 ? _eventService.create(event) : _eventService.update(event);

        abp.ui.setBusy(_$modal);
        usedFunction.done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            _$eventTable.reload(eventId == 0);
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.edit-event', function (e) {
        const eventId = $(this).attr("data-event-id");
        e.preventDefault();
        abp.ui.setBusy(_$form);

        _eventService.get({ id: eventId }).done(function (dto) {
            _$form.populateForm(dto);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    });

    $(document).on('click', '.deleter', function () {
        const itemId = $(this).attr("data-event-id");
        const name = $(this).attr("data-name");
        deleteItem(itemId, name);
    });

    function deleteItem(itemId, name) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                name),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _eventService.delete({
                        id: itemId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$eventTable.reload(false);
                    });
                }
            }
        );
    }

    $(_$modal).on('hidden.bs.modal', function () {
        //$form.find('#clear').click();
        _$form.clearForm();
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