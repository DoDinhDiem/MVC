
myApp.controller('SanPhamADCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/SanPham/";
    var baseurlloai = "/Admin/LoaiSP/";
    var baseurlhang = "/Admin/HangSP/";
  
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Lưu";
    $scope.MaSP = "";
    $scope.TenSP = "";
    $scope.MoTa = "";
    $scope.Ram = "";
    $scope.Rom = "";
    $scope.SoLuong = "";
    $scope.DonGia = "";
    $scope.MaLoai = "";
    $scope.MaHang = "";
    $scope.Anh = "";

    $scope.TaoMoi = function () {
        $scope.btnText = "Lưu";
        $scope.MaSP = "";
        $scope.TenSP = "";
        $scope.MoTa = "";
        $scope.Ram = "";
        $scope.Rom = "";
        $scope.SoLuong = "";
        $scope.DonGia = "";
        $scope.MaLoai = "";
        $scope.MaHang = "";
        $scope.Anh = "";
    }

    //khởi tạo các giá trị ban đầu cho modal
    $scope.MaLoai = "";
    $scope.TenLoai = "";
    $scope.GhiChu = "";

    //khởi tạo các giá trị ban đầu cho modal
    $scope.MaHang = "";
    $scope.TenHang = "";

    //viết hàm lấy tất cả loại sản phẩm
    $scope.LoadLSP = function () {
        var apiRoute = baseurlloai + "getAllLSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (resl) {
            $scope.listLSP = resl.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadLSP();



    //viết hàm lấy tất cả hãng sản phẩm
    $scope.LoadHSP = function () {
        var apiRoute = baseurlhang + "getAllHSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (resh) {
            $scope.listHSP = resh.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadHSP()

    //Viết hàm lấy tất cả sản phẩm
    $scope.LoadSP = function () {
        var apiRoute = baseurl + "getAllSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listSP = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadSP();

    /* Viết hàm lấy về 1 sản phẩm */
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1SanPham";
        var oneData = CrudService.getByID(apiRoute, s.MaSP);
        oneData.then(function (res) {
            $scope.btnText = "Cập nhập";
            $scope.MaSP = res.data.MaSP;
            $scope.TenSP = res.data.TenSP;
            $scope.MoTa = res.data.MoTa;
            $scope.Ram = res.data.Ram;
            $scope.Rom = res.data.Rom;
            $scope.SoLuong = res.data.SoLuong;
            $scope.DonGia = res.data.DonGia;
            $scope.MaLoai = res.data.MaLoai;
            $scope.MaHang = res.data.MaHang;
            $scope.Anh = res.data.Anh;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenSP + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteSP";
        var delData = CrudService.getByID(apiRoute, s.MaSP);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadSP();
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
            MaSP: $scope.MaSP,
            TenSP: $scope.TenSP,
            MoTa: $scope.MoTa,
            Ram: $scope.Ram,
            Rom: $scope.Rom,
            SoLuong: $scope.SoLuong,
            DonGia: $scope.DonGia,
            MaLoai: $scope.MaLoai,
            MaHang: $scope.MaHang,
            Anh: $scope.Anh
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Lưu") {
            var apiRoute = baseurl + "createSP";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadSP();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateSP";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadSP();
                  
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