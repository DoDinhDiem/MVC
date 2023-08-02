

myApp.controller('LoaiSPCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/LoaiSP/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaLoai = "";
    $scope.TenLoai = "";
    $scope.GhiChu = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaLoai = "";
        $scope.TenLoai = "";
        $scope.GhiChu = "";
    }
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadLSP = function () {
        var apiRoute = baseurl + "getAllLSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listLSP = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadLSP();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1LSP";
        var oneData = CrudService.getByID(apiRoute, s.MaLoai);
        oneData.then(function (res) {
            $scope.MaLoai = res.data.MaLoai;
            $scope.TenLoai = res.data.TenLoai;
            $scope.GhiChu = res.data.GhiChu;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenLoai + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteLSP";
        var delData = CrudService.getByID(apiRoute, s.MaLoai);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadLSP();
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
            MaLoai: $scope.MaLoai,
            TenLoai: $scope.TenLoai,
            GhiChu: $scope.GhiChu
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createLSP";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadLSP();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateLSP";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadLSP();
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