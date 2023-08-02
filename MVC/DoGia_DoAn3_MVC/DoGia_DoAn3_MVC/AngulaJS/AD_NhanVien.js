myApp.controller('NhanVienCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/NhanVien/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaNV = "";
    $scope.TenNV = "";
    $scope.DiaChi = "";
    $scope.SDT = "";
    $scope.Anh = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaNV = "";
        $scope.TenNV = "";
        $scope.DiaChi = "";
        $scope.SDT = "";
        $scope.Anh = "";
    }
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadNV = function () {
        var apiRoute = baseurl + "getAllNV";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listNV = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadNV();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1NV";
        var oneData = CrudService.getByID(apiRoute, s.MaNV);
        oneData.then(function (res) {
            $scope.MaNV = res.data.MaNV;
            $scope.TenNV = res.data.TenNV;
            $scope.DiaChi = res.data.DiaChi;
            $scope.SDT = res.data.SDT;
            $scope.Anh = res.data.Anh;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenNV + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteNV";
        var delData = CrudService.getByID(apiRoute, s.MaNV);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadNV();
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
            MaNV: $scope.MaNV,
            TenNV: $scope.TenNV,
            DiaChi: $scope.DiaChi,
            SDT: $scope.SDT,
            Anh: $scope.Anh
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createNV";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadNV();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateNV";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadNV();
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