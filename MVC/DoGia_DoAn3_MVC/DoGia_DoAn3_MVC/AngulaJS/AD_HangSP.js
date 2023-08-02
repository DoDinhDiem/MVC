myApp.controller('HangSPCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/HangSP/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaLoai = "";
    $scope.TenLoai = "";
    $scope.GhiChu = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaHang = "";
        $scope.TenHang = "";
        $scope.GhiChu = "";
    }
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadHSP = function () {
        var apiRoute = baseurl + "getAllHSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listHSP = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadHSP();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1HSP";
        var oneData = CrudService.getByID(apiRoute,s.MaHang);
        oneData.then(function (res) {
            $scope.MaHang = res.data.MaHang;
            $scope.TenHang = res.data.TenHang;
            $scope.GhiChu = res.data.GhiChu;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenHang + " không?")) {
            return;
        }
        var apiRoute = baseurl + "deleteHSP";
        var delData = CrudService.getByID(apiRoute,s.MaHang);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadHSP();
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
            MaHang: $scope.MaHang,
            TenHang: $scope.TenHang,
            GhiChu: $scope.GhiChu
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createHSP";
            var creData = CrudService.post(apiRoute,singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadHSP();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateHSP";
            var creData = CrudService.post(apiRoute,singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadHSP();
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