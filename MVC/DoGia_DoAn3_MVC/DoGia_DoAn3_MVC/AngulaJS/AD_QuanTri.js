

myApp.controller('QuanTriCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/QuanTri/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.UserName = "";
    $scope.Pass = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.UserName = "";
        $scope.Pass = "";
    }
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadQT = function () {
        var apiRoute = baseurl + "getAllQT";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listQT = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadQT();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1QT";
        var oneData = CrudService.getByID(apiRoute, s.MaLoai);
        oneData.then(function (res) {
            $scope.UserName = res.data.UserName;
            $scope.Pass = res.data.Pass;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.UserName + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteQT";
        var delData = CrudService.getByID(apiRoute, s.UserName);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadQT();
            }
            else {
                alert("Lỗi hệ thống");
            }
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            UserName: $scope.UserName,
            Pass: $scope.Pass
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createQT";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadQT();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateQT";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadQT();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        $("#exampleModal").modal("hide");
    }
}]);