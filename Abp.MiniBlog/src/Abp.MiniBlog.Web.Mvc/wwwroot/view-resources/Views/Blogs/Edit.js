(function () {
    $(function () {

        var _blogService = abp.services.app.blog;
        var _$modal = $('#BlogCreateModal');
        var _$form = _$modal.find('form');


        var blogId = $(this).attr("data-blog-id");

        e.preventDefault();
        $.ajax({
            url: abp.appPath + 'Blogs/EditBlogModal?blogId=' + blogId,
            type: 'POST',
            contentType: 'application/html',
            success: function (content) {
                $('#BlogEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var blog = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _blogService.create(blog).done(function () {
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

        function deleteBlog(blogId, blogName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MiniBlog'), blogName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _blogService.delete({
                            id: blogId
                        }).done(function () {
                            refreshBlogList();
                        });
                    }
                }
            );
        }
    });
})();