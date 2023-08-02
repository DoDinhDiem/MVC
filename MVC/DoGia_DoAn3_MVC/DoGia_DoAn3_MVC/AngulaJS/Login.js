

myApp.controller('LoginCustumerCtrl', function ($scope, $http, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Account/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.UserName = "";
    $scope.Pass = "";


    $scope.LoginCustumer = function () {
        let singleData = {}
        singleData.UserName = $('#UserName').val(),
        singleData.Pass = $('#Pass').val();

        $http({
            method: 'POST',
            url: '/Account/getLoginCustumer',
            datatype: 'json',
            data: JSON.stringify(singleData)
        }).then(function (res) {
            if (res.data.ok == 1) {
                window.location.replace("/SanPhamCustumer/SanPham");
            }
            else {
                alert('Có lỗi');
            }
        });
    };

    $scope.Create = function () {
        var singleData = {
            UserName: $scope.UserName,
            Pass: $scope.Pass,
        }
        var apiRoute = baseurl + "createND";
        var creData = CrudService.post(apiRoute, singleData);
        creData.then(function (res) {
            if (res.data != "") {
                alert("Đăng ký thành công!");
                window.location.replace("/Account/LoginCustumer");
            }
            else {
                alert("Lỗi hệ thống!");
            }
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    };
});