myApp.controller('NhaCungCapCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/NhaCungCap/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaNCC = "";
    $scope.TenNCC = "";
    $scope.DiaChi = "";
    $scope.SDT = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaNCC = "";
        $scope.TenNCC = "";
        $scope.DiaChi = "";
        $scope.SDT = "";
    }
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadNCC = function () {
        var apiRoute = baseurl + "getAllNCC";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listNCC = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadNCC();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1NCC";
        var oneData = CrudService.getByID(apiRoute, s.MaNCC);
        oneData.then(function (res) {
            $scope.MaNCC = res.data.MaNCC;
            $scope.TenNCC = res.data.TenNCC;
            $scope.DiaChi = res.data.DiaChi;
            $scope.SDT = res.data.SDT;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenNCC + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteNCC";
        var delData = CrudService.getByID(apiRoute, s.MaNCC);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadNCC();
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
            MaNCC: $scope.MaNCC,
            TenNCC: $scope.TenNCC,
            DiaChi: $scope.DiaChi,
            SDT: $scope.SDT
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createNCC";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadNCC();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateNCC";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadNCC();
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