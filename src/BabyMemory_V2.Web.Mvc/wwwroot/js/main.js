﻿(function ($) {
    const l = abp.localization.getSource('BabyMemory_V2');

    /**
     * Reload DataTable and keep pagination
     * @param {any} resetPaging
     */
    $.fn.dataTable.Api.prototype.reload = function (resetPaging = false, callback = null) {
        const $keywordSelector = $(".txt-search[name=Keyword]");

        const hasSearchKeyword = $keywordSelector && $keywordSelector.length && $keywordSelector.val().length;

        return this.ajax.reload(callback, resetPaging || hasSearchKeyword);
    }


    //Notification handler
    abp.event.on('abp.notifications.received', function (userNotification) {
        abp.notifications.showUiNotifyForUserNotification(userNotification);

        //Desktop notification
        Push.create("BabyMemory_V2", {
            body: userNotification.notification.data.message,
            icon: abp.appPath + 'img/logo.png',
            timeout: 6000,
            onClick: function () {
                window.focus();
                this.close();
            }
        });
    });

    //serializeFormToObject plugin for jQuery
    $.fn.serializeFormToObject = function (camelCased = false) {
        //serialize to array
        var data = $(this).serializeArray();

        //add also disabled items
        $(':disabled[name]', this).each(function () {
            data.push({ name: this.name, value: $(this).val() });
        });

        //map to object
        var obj = {};
        data.map(function (x) { obj[x.name] = x.value; });

        if (camelCased && camelCased === true) {
            return convertToCamelCasedObject(obj);
        }

        return obj;
    };

    //Configure blockUI
    if ($.blockUI) {
        $.blockUI.defaults.baseZ = 2000;
    }

    //Configure validator
    $.validator.setDefaults({
        highlight: (el) => {
            $(el).addClass('is-invalid');
        },
        unhighlight: (el) => {
            $(el).removeClass('is-invalid');
        },
        errorElement: 'p',
        errorClass: 'text-danger',
        errorPlacement: (error, element) => {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    $.fn.translatedDataTable = function (options) {
        options.language = {};
        options.language.paginate = {};
        options.language.lengthMenu = `${l("Show")} _MENU_ ${l("entries")}`;
        options.language.info = `${l("Showing")} _START_-_END_ ${l("of")} _TOTAL_ ${l("entries")}`;
        options.language.infoEmpty = `${l("NoRecords")}`;
        options.language.emptyTable = `${l("NoDataAvailableInTable")}`;
        options.language.paginate.previous = `${l("PaginPrevious")}`;
        options.language.paginate.next = `${l("PaginNext")}`;
        return $(this).dataTable(options).api();
    }

    function convertToCamelCasedObject(obj) {
        var newObj, origKey, newKey, value;
        if (obj instanceof Array) {
            return obj.map(value => {
                if (typeof value === 'object') {
                    value = convertToCamelCasedObject(value);
                }
                return value;
            });
        } else {
            newObj = {};
            for (origKey in obj) {
                if (obj.hasOwnProperty(origKey)) {
                    newKey = (
                        origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey
                    ).toString();
                    value = obj[origKey];
                    if (
                        value instanceof Array ||
                        (value !== null && value.constructor === Object)
                    ) {
                        value = convertToCamelCasedObject(value);
                    }
                    newObj[newKey] = value;
                }
            }
        }
        return newObj;
    }

    function initAdvSearch() {
        $('.abp-advanced-search').each((i, obj) => {
            var $advSearch = $(obj);
            setAdvSearchDropdownMenuWidth($advSearch);
            setAdvSearchStopingPropagations($advSearch);
        });
    }

    initAdvSearch();

    $(window).resize(() => {
        clearTimeout(window.resizingFinished);
        window.resizingFinished = setTimeout(() => {
            initAdvSearch();
        }, 500);
    });

    function setAdvSearchDropdownMenuWidth($advSearch) {
        var advSearchWidth = 0;
        $advSearch.each((i, obj) => {
            advSearchWidth += parseInt($(obj).width(), 10);
        });
        $advSearch.find('.dropdown-menu').width(advSearchWidth)
    }

    function setAdvSearchStopingPropagations($advSearch) {
        $advSearch.find('.dd-menu, .btn-search, .txt-search')
            .on('click', (e) => {
                e.stopPropagation();
            });
    }

    $.fn.clearForm = function () {
        var $this = $(this);
        $this.validate().resetForm();
        $('[name]', $this).each((i, obj) => {
            $(obj).removeClass('is-invalid');
        });
        $this[0].reset();
    };

    /**
    * Populate HTML Form from Flat (not nested) Object 
    * @param {any} model
    */
    $.fn.populateForm = function (model) {
        const $form = $(this);

        for (let dtoProperty in model) {
            if (!Object.prototype.hasOwnProperty.call(model, dtoProperty)) {
                console.log(`Can't find property [${dtoProperty}] in model of type ${typeof (model)}`);
                continue;
            }

            const propName = dtoProperty.charAt(0).toUpperCase() + dtoProperty.slice(1);
            const formElement = $form.find(`#${propName}`);
            let formElementValue = model[dtoProperty];

            if (formElement.hasClass("selectpicker")) {
                if (typeof formElementValue == "number") {
                    formElementValue = formElementValue.toString();
                }

                // https://github.com/snapappointments/bootstrap-select/issues/1167#issuecomment-238502928
                setTimeout(function () {
                    formElement.selectpicker('val', formElementValue);
                    if (formElementValue) {
                        formElement.trigger("change");
                    }
                }, 0);

            } else {
                if (formElement.is(":checkbox")) {
                    formElement.prop("checked", formElementValue == true || formElementValue == "true");
                } else if (formElement.isDatePicker()) {
                    formElement.attr("type", "text");
                    formElement.addClassIfNotExists("datepicker");
                    if (formElementValue)
                        formElement.val(moment(formElementValue).format("DD/MM/YYYY"));
                } else if (formElement.isDateTimePicker()) {
                    formElement.attr("type", "text");
                    formElement.addClassIfNotExists("datetimepicker");
                    if (formElementValue)
                        formElement.val(moment(formElementValue).format("DD/MM/YYYY HH:mm"));
                } else if (formElement.isTimePicker()) {
                    formElement.attr("type", "text");
                    formElement.addClassIfNotExists("timepicker");
                    if (formElementValue)
                        formElement.val(moment(formElementValue).format("HH:mm"));
                } else {
                    formElement.val(formElementValue);
                }
            }
        }
    }

    $.fn.isDatePicker = function () {
        const t = $(this);
        const hasClass = t.hasClass("datepicker");
        const hasType = t.attr("type") == "date";

        return hasClass || hasType;
    }

    $.fn.isTimePicker = function () {
        const t = $(this);
        const hasClass = t.hasClass("timepicker");
        const hasType = t.attr("type") == "time";

        return hasClass || hasType;
    }

    $.fn.isDateTimePicker = function () {
        const t = $(this);
        const hasClass = t.hasClass("datetimepicker");
        const hasType1 = t.attr("type") == "datetime";
        const hasType2 = t.attr("type") == "datetime-local";

        return hasClass || hasType1 || hasType2;
    }

    $.fn.addClassIfNotExists = function (className) {
        const t = $(this);
        if (!t.hasClass(className)) {
            t.addClass(className);
        }
        return t;
    }
})(jQuery);
