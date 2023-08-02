myApp.controller('KhachHangCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/KhachHang/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaKH = "";
    $scope.TenKh = "";
    $scope.DiaChi = "";
    $scope.SDT = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaKH = "";
        $scope.TenKh = "";
        $scope.DiaChi = "";
        $scope.SDT = "";
    }
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadKH = function () {
        var apiRoute = baseurl + "getAllKH";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listKH = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadKH();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1KH";
        var oneData = CrudService.getByID(apiRoute, s.MaKH);
        oneData.then(function (res) {
            $scope.MaKH = res.data.MaKH;
            $scope.TenKh = res.data.TenKh;
            $scope.DiaChi = res.data.DiaChi;
            $scope.SDT = res.data.SDT;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenKh + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteKH";
        var delData = CrudService.getByID(apiRoute, s.MaKH);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadKH();
                $scope.btnText = "Lưu";
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
            MaKH: $scope.MaKH,
            TenKh: $scope.TenKh,
            DiaChi: $scope.DiaChi,
            SDT: $scope.SDT
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createKH";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadKH();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateKH";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadKH();
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