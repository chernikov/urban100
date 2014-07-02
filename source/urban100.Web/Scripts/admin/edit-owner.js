function EditOwner()
{
    var _this = this;

    this.init = function ()
    {
        $("#ChangeAvatar").fineUploader({
            element: $('#ChangeAvatar'),
            request: {
                endpoint: "/File/UploadFile"
            },
            template: 'qq-template-bootstrap',
            allowedExtensions: ['jpg', 'jpeg', 'png', 'gif'],
            classes: {
                success: 'alert alert-success',
                fail: 'alert alert-error'
            },
            failedUploadTextDisplay: {
                mode: 'custom',
                maxChars: 400,
                responseProperty: 'error',
                enableTooltip: true
            },
            debug: true
        })
        .on('complete', function (event, id, filename, responseJSON)
        {
            if (responseJSON.success)
            {
                $("#Image").val(responseJSON.fileUrl);
                $("#AvatarImage").attr("src", responseJSON.fileUrl + "?w=120&h=120&mode=crop");
            }
        }).on('submit', function () {
            $(".qq-upload-fail").remove();
            return true;
        });
    };
}

var editOwner;
$(function () {
    editOwner = new EditOwner();
    editOwner.init();
});
