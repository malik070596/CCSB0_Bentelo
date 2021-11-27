var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false,

    });
    InitializeCalendar();
});
var kalender;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            kalender = new FullCalendar.Calendar(calendarEl, {
                locale: 'nl',
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                weekNumbers: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
                evenDisplay: 'block',
                events: function (fethinfo, succesCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/AppointmentApi/GetCalenderData?appointmentId' + $("appointmentId").val(),
                        type: 'GET',
                        dataType: 'json',
                        success: function (response) {
                            var events = [];
                            if (response.status === 1) {
                                $.each(response.dataenum, function (i, data) {
                                    events.push({
                                        title: data.title,
                                        description: data.description,
                                        start: data.startDate,
                                        end: data.endDate,
                                        backgroundColor: data.isAdminApproved ? "#28a745" : "#dc3545",
                                        textColor: "white",
                                        id: data.id
                                    });
                                })
                            }
                            succesCallback(events);
                        },
                        error: function (xhr) {
                            $.notify("Error", "error");
                        }
                    });
                },
                eventClick: function (info) {
                    getEventDetailsByEventId(info.event);
                }
            });
            kalender.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + 'api/AppointmentApi/GetCalendarDataById/' + info.id,
        type: "GET",
        datatype: 'JSON',
        contentType: "application/json",
        succes: function (response) {
            if (response.status === 1 && response.dataenum != undefined) {
                onShowModal(response.dataenum, true);
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}
function onShowModal(obj, isEventDetail) {
    if (isEventDetail) {
        $("#OphalenId").val(obj.OphalenId)
        $("#title").val(obj.title)
        $("#adminId").val(obj.adminId);
        $("#appointmentDate").val(obj.startDate);
    }
    else {
        var appointmentdate = obj.start.getDate() + "-" + obj.start.getMonth() + "-" +
            obj.start.getFullYear() + "" + new moment().format("hh:mm");
        $("#id").val(0);
        $("#appointmentDate").val(obj.appointmentdate);
    }
    $("#appointmentInput").modal("show");
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

function checkValidation() {
    var isValid = true;
    if ($("#title").val() === undefined || $("#title").val().trim() === "") {
        isValid = false;
        $("#title").removeClass("error");
    }
    else {
        $("#title").addClass("error");
    }
    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val().trim() === "") {
        isValid = false;
        $("#appointmentDate").addClass("error");
    }
    else {
        $("#appointmentDate").removeClass("error");
    }
    return isValid;
}


function onSubmitForm() {
    if (!checkValidation()) return;
    var requestData = {
        OphalenId: $("#Ophalen").val(),
        AppointmentId: parseInt($("id").val()),
        TimeAndMoment: $("#appointmentDate").val(),
        Action: $("#action").val(),
        customerId: $("#customerId").val()
    };

    $.ajax({
        url: routeURL + "api/AppointmentApi/SaveCalendarData",
        type: "POST",
        data: JSON.stringify(requestData),
        contentType: "application/json",
        succes: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "succes");
                onCloseModal();
            } else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "Foutje");
        }
    });
}