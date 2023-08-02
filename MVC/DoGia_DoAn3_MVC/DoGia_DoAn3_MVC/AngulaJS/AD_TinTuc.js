myApp.controller('TinTucCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/TinTuc/";
    var baseurlnv = "/Admin/NhanVien/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaTT = "";
    $scope.TieuDe = "";
    $scope.NoiDung = "";
    $scope.NgayDang = "";
    $scope.MaNV = "";
    $scope.Anh = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaTT = "";
        $scope.TieuDe = "";
        $scope.NoiDung = "";
        $scope.NgayDang = "";
        $scope.MaNV = "";
        $scope.Anh = "";
    }
 
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadTT = function () {
        var apiRoute = baseurl + "getAllTT";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listTT = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadTT();

    $scope.LoadNV = function () {
        var apiRoute = baseurlnv + "getAllNV";
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
        var apiRoute = baseurl + "get1TT";
        var oneData = CrudService.getByID(apiRoute, s.MaTT);
        oneData.then(function (res) {
            $scope.MaTT = res.data.MaTT;
            $scope.TieuDe = res.data.TieuDe;
            $scope.NoiDung = res.data.NoiDung;
            $scope.NgayDang = res.data.NgayDang;
            $scope.MaNV = res.data.MaNV;
            $scope.Anh = res.data.Anh;
            $scope.btnText = "Cập nhập";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TieuDe + " không?")) {
            return;
        }
        var apiRoute = baseurl + "deleteTT";
        var delData = CrudService.getByID(apiRoute, s.MaTT);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadTT();
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
            MaTT: $scope.MaTT,
            TieuDe: $scope.TieuDe,
            NoiDung: $scope.NoiDung,
            NgayDang: $scope.NgayDang,
            MaNV: $scope.MaNV,
            Anh: $scope.Anh
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createTT";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadTT();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateTT";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadTT();
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