$(document).ready(function (event) {

    const DEFAULT_USER_ROLE = "user";
    const ADMIN_USER_ROLE = "admin";
    
    const MODIFY_ROLE_ACTION = "ModifyRole";

    $('.downgrade').on('click', function(){
        console.log(this);
    })

    $('.boost').on('click', function(){
        let userId =$(this).parents('.card-body').find('.user-id').text();

        let model = new ModifyUserRoleViewModel(userId, ADMIN_USER_ROLE);
        ajaxPost(MODIFY_ROLE_ACTION, model);
    })


    function ajaxPost(method, data) {
        $.ajax({
            type: 'POST',
            url: '/Accounts/' + method,
            data: { model: data },
            error: onAjaxError,
            statusCode: {
                200: function (data) {
                    document.write(data);
                    document.location.href = document.location.protocol + '//' + document.location.host + '/Accounts';
                }
            }
        });
    }

    function onAjaxError(jqXHR) {
        document.location.href = document.location.protocol + '//' + document.location.host + '/Projects/Error/?StatusCode=' + (Number)(jqXHR.status);
    }

})