myApp.controller('LoginAdmin', function ($scope, $http) {


    $scope.LoginAdmin = function () {
        let singleData = {}
        singleData.UserName = $('#UserName').val(),
            singleData.Pass = $('#Pass').val();

        $http({
            method: 'POST',
            url: '/Admin/AccountAdmin/getLoginAdmin',
            datatype: 'json',
            data: JSON.stringify(singleData)
        }).then(function (res) {
            if (res.data.ok == 1) {
                window.location.replace("/Admin/Home/Home");
            }
            else {
                alert('Có lỗi');
            }
        });
    };
});