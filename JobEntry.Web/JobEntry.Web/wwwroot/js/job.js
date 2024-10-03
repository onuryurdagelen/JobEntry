$(document).on('click', '.edit-qualification', function () {
    alert('edit qualification clicked!');
})
$(document).on('click', '.delete-qualification', function () {
    let qid = $(this).attr("data-qid");
    let jobid = $(this).attr("data-jobid")

    let qualification = $("#qualification-list").find(`li[data-id="${qid}"]`);

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Admin/Job/DeleteQualificationWithAjax",
                data: { qId: qid, jobId: jobid },
                success: function (response) {
                    qualification.remove();
                    Swal.fire({
                        title: "Deleted!",
                        text: response.Message,
                        icon: "success"
                    });
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }
            });

        }
    });
})

$(document).on('click', '.delete-responsibility', function () {
    let rid = $(this).attr("data-rid");
    let jobid = $(this).attr("data-jobid")

    let responsibility = $("#responsibility-list").find(`li[data-id="${rid}"]`);

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Admin/Job/DeleteResponsibilityWithAjax",
                data: { rId: rid, jobId: jobid },
                success: function (response) {
                    responsibility.remove();
                    Swal.fire({
                        title: "Deleted!",
                        text: response.Message,
                        icon: "success"
                    });
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }
            });

        }
    });
})


$(document).ready(function () {
   

    //Add Qualification
    const addQualificationModalContainer = $("#addQualificationModal-container");

    $("#add-qualification").click(function () {
        let addQualificationModalUrl = app.Urls.AddQualificationModalUrl;
        $.get(addQualificationModalUrl, {jobId:app.JobId}).done(function (data) {
            addQualificationModalContainer.html(data);
            addQualificationModalContainer.find('.modal').modal('show');
        })
        
    })
    addQualificationModalContainer.on('click',
        '#btnSave',
        function (event) {
            event.preventDefault();
            const form = $("#addQualificationForm");
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            const jobId = app.JobId;

            $.post(actionUrl, dataToSend).done(function (data) {
                const newFormBody = $('.modal-body', data.view);
                addQualificationModalContainer.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() == 'True';
                if (isValid) {
                    var newQualification = data.qualification;
                    var itemHtmlTemplate = ` <li class="list-group-item d-flex flex-row" data-id="${newQualification.Id}">
                                        <div class="col-md-10">
                                            <p>${newQualification.Description.length >= 150 ? CutStr(newQualification.Description,0,150).concat("..") : newQualification.Description}</p>
                                        </div>
                                        <div class="col-md-2 d-flex justify-content-end">
                                            <button type="button" class="btn btn-primary btn-sm text-white edit-qualification" data-id="${newQualification.Id}" data-jobid="${newQualification.JobId}">
                                                <i class="bx bxs-edit"></i>
                                            </button>
                                            <button type="button" class="btn btn-danger btn-sm text-white delete-qualification" data-qid="${newQualification.Id}" data-jobid="${newQualification.JobId}">
                                                <i class="bx bx-minus-circle"></i>
                                            </button>
                                        </div>
                                    </li>`;
                    var newItem = $(itemHtmlTemplate);
                    $("#qualification-list").prepend(newItem)
                    addQualificationModalContainer.find('.modal').modal('hide');
                }
            });

           
        })

    //Add Responsibility
    const addResponsibilityModalContainer = $("#addResponsibilityModal-container");
    $("#add-responsibility").click(function () {
        let addResponsibilityModalUrl = app.Urls.AddResponsibilityModalUrl;
        $.get(addResponsibilityModalUrl, { jobId: app.JobId }).done(function (data) {
            addResponsibilityModalContainer.html(data);
            addResponsibilityModalContainer.find('.modal').modal('show');
        })

    })

    addResponsibilityModalContainer.on('click',
        '#btnSave',
        function (event) {
            event.preventDefault();
            const form = $("#addResponsibilityForm");
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            const jobId = app.JobId;

            $.post(actionUrl, dataToSend).done(function (data) {
                const newFormBody = $('.modal-body', data.view);
                console.log(newFormBody);
                addResponsibilityModalContainer.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() == 'True';
                if (isValid) {
                    var newResponsibility = data.responsibility;
                    var itemHtmlTemplate = ` <li class="list-group-item d-flex flex-row" data-id="${newResponsibility.Id}">
                                        <div class="col-md-10">
                                            <p>${newResponsibility.Description.length >= 150 ? CutStr(newResponsibility.Description, 0, 150).concat("..") : newResponsibility.Description}</p>
                                        </div>
                                        <div class="col-md-2 d-flex justify-content-end">
                                            <button type="button" class="btn btn-primary btn-sm text-white edit-responsibility" data-id="${newResponsibility.Id}" data-jobid="${newResponsibility.JobId}">
                                                <i class="bx bxs-edit"></i>
                                            </button>
                                            <button type="button" class="btn btn-danger btn-sm text-white delete-responsibility" data-rid="${newResponsibility.Id}" data-jobid="${newResponsibility.JobId}">
                                                <i class="bx bx-minus-circle"></i>
                                            </button>
                                        </div>
                                    </li>`;
                    var newItem = $(itemHtmlTemplate);
                    $("#responsibility-list").prepend(newItem)
                    addResponsibilityModalContainer.find('.modal').modal('hide');
                }
            });


        })
   

  


   
    

    //Edit Qualification

    //Edit Responsibility




    $('#table-jobs').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
        ],
        language: {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ entries",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Search:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Next",
                "previous": "Previous"
            },
            "aria": {
                "orderable": "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }
    });
});