myApp.controller('SanPhamCtrl', ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/SanPhamCustumer/"
    var baseurlgh = "/GioHang/"
    //khởi tạo các giá trị ban đầu cho modal

    $scope.MaSP = "";
    $scope.TenSP = "";
    $scope.MoTa = "";
    $scope.Ram = "";
    $scope.Rom = "";
    $scope.SoLuong = "";
    $scope.DonGia = "";
    $scope.MaHang = "";
    $scope.Anh = "";

    //khởi tạo các giá trị ban đầu cho modal
    $scope.MaLoai = "";
    $scope.TenLoai = "";
    $scope.GhiChu = "";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.MaTT = "";
    $scope.TieuDe = "";
    $scope.NoiDung = "";
    $scope.NgayDang = "";
    $scope.MaNV = "";
   


    //viết hàm lấy tất cả loại sản phẩm
    $scope.LoadLSP = function () {
        var apiRoute = baseurl + "getAllLSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (resl) {
            $scope.listLSP = resl.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadLSP()
    //Lấy 1 sản phẩm thoai loại
    $scope.getSPbyLoai = function (MaLoai) {
        var apiRoute = baseurl + "getSPbyLoai?id=" + MaLoai;
        var oneData = CrudService.getAll(apiRoute);
        oneData.then(function (res) {
            $scope.listSPbyLoai = res.data.ListSanPham;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //Viết hàm lấy tất cả thông tin
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
    $scope.getbyID = function (MaSP) {
        var apiRoute = baseurl + "get1SanPham?id="+ MaSP;
        var oneData = CrudService.getAll(apiRoute);
        oneData.then(function (res) {
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
    //Lấy về tên loại sản phẩm
    $scope.getbyIDTen = function (MaLoai) {
        var apiRoute = baseurl + "getTenLoai?id=" + MaLoai;
        var oneData = CrudService.getAll(apiRoute);
        oneData.then(function (res) {
            $scope.MaLoai = res.data.MaLoai;
            $scope.TenLoai = res.data.TenLoai;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    $scope.addtoCart = function (s) {
        var apiRoute = baseurlgh + "MuaHang";
        $.get(apiRoute, { id: s }, function (data) {
            $("#count-cart").html(data.soluong);
            $("#total_price").html(numberWithCommas(data.tongtien));
            $("#show-cart").html("");
            $.each(data.giohang, function (i, val) {
                $("#show-cart").append("<tr class='cart_item'>"
                    + "<td class='product-remove'>"
                    + "<div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>"
                    + "</td>"
                    + "<td class='product-name'>"
                    + "<b>" + val.Ten + "</b>"
                    + "<div class='clr'></div>"
                    + "<div class='box_quantity left'>"
                    + "<div class='quantity right'>"
                    + "<input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>"
                    + "<input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>"
                    + "<input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>"
                    + "</div>"
                    + "</div>"
                    + "</td>"
                    + "<td class='product-price' valign='top'>"
                    + "<span class='amount'>" + numberWithCommas(val.SL * val.Gia) + "</span>"
                    + "</td>"
                    + "</tr>");
            });
        });
    }
}]);
