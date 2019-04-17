(function() {
    $(function() {

        var _blogService = abp.services.app.blog;
        var _$modal = $('#BlogCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
            
        });

        $('#RefreshButton').click(function () {
            refreshBlogList();
        });

        $('.delete-blog').click(function () {
            var blogId = $(this).attr("data-blog-id");
            var blogName = $(this).attr('data-blog-name');

            deleteBlog(blogId, blogName);
        });

        $('.edit-blog').click(function (e) {
            var blogId = $(this).attr("data-blog-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Users/EditUserModal?blogId=' + blogId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            user.roleNames = [];
            var _$roleCheckboxes = $("input[name='role']:checked");
            if (_$roleCheckboxes) {
                for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                    var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                    user.roleNames.push(_$roleCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);
            _blogService.create(user).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshBlogList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteBlog(userId, userName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MiniBlog'), userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _blogService.delete({
                            id: userId
                        }).done(function () {
                            refreshBlogList();
                        });
                    }
                }
            );
        }
    });
})();