(function () {
    $(function () {

        var _blogService = abp.services.app.blog;
        var _$modal = $('#BlogCreateModal');
        var _$form = _$modal.find('form');

        _$form.find('button[type="button"]').click(function (e) {
	        $("form").submit();  
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshBlogList() {
            location.reload(true); //reload page to see new user!
        }
    });
})();