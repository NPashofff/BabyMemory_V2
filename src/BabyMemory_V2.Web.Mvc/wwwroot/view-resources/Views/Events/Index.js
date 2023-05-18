

(function ($) {
    const eventService = abp.services.app.event,
        l = abp.localization.getSource('BabyMemory_V2'),
        $modal = $('#EventModal'),
        $form = $modal.find('form'),
        $table = $('#EventTable'),
        $createButton = $('#CreateButton');

    const $eventTable = $table.translatedDataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#EntitySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            abp.ui.setBusy($table);
            //todo: get all in future, order by event date
            eventService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy($table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => $eventTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: ''
            },
            {
                targets: 1,
                data: null,
                sortable: false,
                render: (data, type, row, meta) => {
                    return window.moment(row.eventDate).format(`DD-MM-YYYY  HH:mm`);
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
                    const result = [`<button type="button" class="btn btn-sm bg-secondary event-details ml-1" title="${l("Details")
                        }" data-event-id="${row.id}" data-name="${row.name}">`,
                        `<i class="fas fa-bars"></i>`,
                        '   </button>'];

                    if (row.isPublic)
                        result.push(`<button type="button" class="btn btn-sm bg-secondary ml-1 join-event" title="${l("JoinEvent")}" data-event-id="${row.id}" data-name="${row.name}">`,
                            `<i class="fa fa-plus-circle"></i>`,
                            '   </button>');

                    if (abp.session.userId === row.userId)
                        result.push(`   <button type="button" class="btn btn-sm bg-secondary ml-1 edit-event" title="${l("Edit")
                            }" data-event-id="${row.id}" data-toggle="modal" data-target="#EventModal">`,
                            `       <i class="fas fa-pencil-alt"></i>`,
                            '   </button>',
                            `   <button type="button" class="btn btn-sm bg-danger ml-1 deleter" title="${l("Delete")
                            }" data-event-id="${row.id}" data-name="${row.name}">`,
                            `       <i class="fas fa-trash"></i>`,
                            '   </button>');

                    return result.join('');
                }
            }
        ]
    });

    $form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        let eventId = $form.find("#Id").val();
        if (eventId === "") {
            eventId = 0;
            $form.find("#Id").val(eventId);
        }

        const event = $form.serializeFormToObject();

        if ($("#IsPublic").is(':checked')) {
            event.IsPublic = true;
        }

        const usedFunction = eventId == 0 ? eventService.create(event) : eventService.update(event);

        abp.ui.setBusy($modal);
        usedFunction.done(function () {
            $modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            $eventTable.reload(eventId === 0);
        }).always(function () {
            abp.ui.clearBusy($modal);
        });
    });

    $(document).on('click', '.edit-event', function (e) {
        const eventId = $(this).attr("data-event-id");
        e.preventDefault();
        abp.ui.setBusy($form);

        eventService.get({ id: eventId }).done(function (dto) {
            $form.populateForm(dto);
        }).always(function () {
            abp.ui.clearBusy($form);
        });
    });

    $(document).on('click',
        '.event-details',
        function () {
            const eventId = $(this).attr("data-event-id");
            eventService.get({ id: eventId }).done((event) => {
                const eventMessage = [event.description, l('Participants') + ":"];
                //todo; add all participants
                abp.message.info(eventMessage.join("\r\n"), event.name);
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
                    eventService.delete({
                        id: itemId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        $eventTable.reload(false);
                    });
                }
            }
        );
    }

    $($modal).on('hidden.bs.modal', function () {
        //$form.find('#clear').click();
        $form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        $eventTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which === 13) {
            $eventTable.ajax.reload();
            return false;
        }
    });
})(jQuery);