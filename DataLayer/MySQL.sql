USE QLCuaHang
GO

--/*----------- SẢN PHẨM -----------*/

-- Thêm sản phẩm
CREATE PROC sp_ThemSanPham
	@tenSP nvarchar(100),
	@maLoai int,
	@maHang int,
	@donGiaNhap decimal(18,2),
	@donGiaBan decimal(18,2),
	@tonKho int,
	@maKM int,
	@trangThai nvarchar(50)
AS
BEGIN
	INSERT INTO SanPham(tenSP, maLoai, maHang, donGiaNhap, donGiaBan, tonKho, maKM, trangThai) 
	VALUES (@TenSP, @maLoai, @maHang, @donGiaNhap, @donGiaBan, @tonKho, @maKM, @trangThai)
END
GO

-- Cập nhật sản phẩm
CREATE PROC sp_CapNhatSP
	@maSP int,
	@tenSP nvarchar(100),
	@maLoai int,
	@maHang int,
	@donGiaNhap decimal(18,2),
	@donGiaBan decimal(18,2),
	@tonKho int,
	@maKM int,
	@trangThai nvarchar(50)
AS
BEGIN
	UPDATE SanPham
	SET tenSP = @tenSP,
		maLoai = @maLoai,
		maHang = @maHang,
		donGiaNhap = @donGiaNhap,
		donGiaBan = @donGiaBan,
		tonKho = @tonKho,
		maKM = @maKM,
		trangThai = @trangThai
	WHERE maSP =@maSP
END
GO

-- Kiểm tra sản phẩm trước khi xóa
CREATE PROC sp_KTXoaSP @maSP int
AS
BEGIN
	SELECT COUNT(*) 
	FROM ChiTietNhapKho 
	WHERE maSP = @maSP
END
GO

-- Lấy tỷ lệ giảm giá của sản phẩm
CREATE PROC sp_LayTyLeGiam @maSP int
AS
BEGIN
	SELECT k.tyLeGiam
	FROM SanPham s JOIN KhuyenMai k ON s.maKM = k.maKM
	WHERE s.maSP = @maSP
END
GO

-- Thêm Hãng sản xuất
CREATE PROC sp_CapNhatHangSX
	@maHang int,
	@tenHang nvarchar(20),
	@quocGia nvarchar(100)
AS
BEGIN
	UPDATE HangSanXuat
	SET tenHang = @tenHang,
		quocGia = @quocGia
	WHERE maHang =@maHang
END
GO



--/*----------- KHUYẾN MÃI -----------*/

-- Thêm khuyến mãi
CREATE PROC sp_ThemKhuyenMai @tenKM nvarchar(100),
							 @tyLeGiam float,
							 @loaiKM nvarchar(20),
							 @ngayBatDau datetime,
							 @ngayKetThuc datetime,
							 @ghiChu nvarchar(200)
AS
BEGIN
	INSERT INTO KhuyenMai(tenKM,tyLeGiam,loaiKM,ngayBatDau,ngayKetThuc,ghiChu) 
	VALUES (@tenKM,@tyLeGiam,@loaiKM,@ngayBatDau,@ngayKetThuc,@ghiChu)
END
GO

-- Cập nhật khuyến mãi
CREATE PROC sp_CapNhatKhuyenMai  @maKM int,
								 @tenKM nvarchar(100),
								 @tyLeGiam float,
								 @loaiKM nvarchar(20),
								 @ngayBatDau datetime,
								 @ngayKetThuc datetime,
								 @ghiChu nvarchar(200)
AS
BEGIN
	UPDATE KhuyenMai
	SET tenKM = @tenKM,
		tyLeGiam= @tyLeGiam, 
		loaiKM=@loaiKM,
		ngayBatDau= @ngayBatDau,
		ngayKetThuc=@ngayKetThuc,
		ghiChu = @ghiChu
	WHERE maKM = @maKM
END
GO

-- Kiểm tra khuyến mãi còn hạn sử dụng hay không?
CREATE PROC sp_KTHanSuDungCuaKM @maKM int
AS
BEGIN
	SELECT COUNT(*)
	FROM KhuyenMai
	WHERE maKM = @maKM AND GETDATE() BETWEEN ngayBatDau AND ngayKetThuc

END
GO


-- Lấy tỷ lệ giảm giá cho mã khách hàng
ALTER PROC sp_LayKhuyenMai_maKH @maKH int
AS
BEGIN
	SELECT km.tenKM,km.tyLeGiam
	FROM KhachHang kh JOIN HangKhachHang h ON kh.hangKH = h.maHangKH 
					 JOIN KhuyenMai km ON h.maKM = km.maKM
	WHERE kh.maKH = @maKH
END
GO


--/*----------- NHÀ CUNG CẤP -----------*/

--Thêm nhà cung cấp
CREATE PROC sp_ThemNhaCungCap @tenNCC nvarchar(100),
							  @soDT nvarchar(10),
							  @email nvarchar(100),
							  @diaChi nvarchar(200)
AS
BEGIN
	INSERT INTO NhaCungCap(tenNCC, soDT, email, diaChi) 
	VALUES (@tenNCC, @soDT, @email, @diaChi)
END
GO


-- Cập nhật nhà cung cấp
CREATE PROC sp_CapNhatNCC  @maNCC int,
						   @tenNCC nvarchar(100),
						   @soDT nvarchar(10),
						   @email nvarchar(100),
						   @diaChi nvarchar(200)
AS
BEGIN
	UPDATE NhaCungCap
	SET tenNCC = @tenNCC,
		soDT = @soDT,
		email = @email,
		diaChi = @diaChi
	WHERE maNCC = @maNCC
END
GO





--/*----------- NHÂN VIÊN -----------*/

-- Thêm nhân viên
CREATE PROC sp_ThemNhanVien @hoNV nvarchar(50),
							@tenNV nvarchar(20),
							@ngaySinh date,
							@gioiTinh nvarchar(10),
							@chucVu nvarchar(50),
							@soDT nvarchar(10),
							@email nvarchar(100),
							@diaChi nvarchar(100),
							@tinhTrang nvarchar(50)
AS
BEGIN
	INSERT INTO NhanVien(hoNV,tenNV, ngaySinh, gioiTinh, chucVu,soDT,email,diaChi,tinhTrang) 
	VALUES (@hoNV,@tenNV, @ngaySinh, @gioiTinh, @chucVu,@soDT,@email,@diaChi,@tinhTrang)
END
GO

-- Cập nhật nhân viên
CREATE PROC sp_CapNhatNhanVien  @maNV int,
								@hoNV nvarchar(50),
								@tenNV nvarchar(20),
								@ngaySinh date,
								@gioiTinh nvarchar(10),
								@chucVu nvarchar(50),
								@soDT nvarchar(10),
								@email nvarchar(100),
								@diaChi nvarchar(100),
								@tinhTrang nvarchar(50)						 					   
AS
BEGIN
	UPDATE NhanVien
	SET hoNV = @hoNV,
		tenNV= @tenNV, 
		ngaySinh = @ngaySinh, 
		gioiTinh=@gioiTinh, 
		chucVu=@chucVu,
		soDT=@soDT,
		email= @email,
		diaChi=@diaChi,
		tinhTrang = @tinhTrang
	WHERE maNV = @maNV
END
GO

-- Kiểm tra nhân viên trước khi xóa
CREATE PROC sp_KiemTraTruocKhiXoaNV @maNV int
AS
BEGIN
	IF EXISTS (SELECT 1 FROM NhapKho WHERE maNV = @maNV)
	BEGIN
		SELECT COUNT(*) FROM NhapKho WHERE maNV = @maNV
	END
	ELSE 
	BEGIN
		SELECT COUNT(*) FROM HoaDon WHERE maNV = @maNV
	END
	
END
GO


--/*----------- TÀI KHOẢN -----------*/

-- Thêm tài khoản 

CREATE PROC sp_ThemTaiKhoan @maNV int, @tenDangNhap nvarchar(50),
							@matKhau nvarchar(MAX),
							@chucNang nvarchar(50),
							@mail nvarchar(200)
AS
BEGIN
	INSERT INTO TaiKhoan(maNV,tenDangNhap, matKhau, chucNang, mail) 
	VALUES (@maNV, @tenDangNhap, @matKhau, @chucNang,@mail)
END
GO


-- Cập nhật tài khoản
CREATE PROC sp_CapNhatTaiKhoan  @maNV int,
								@tenDangNhap nvarchar(50),
								@matKhau nvarchar(MAX),
								@chucNang nvarchar(50),
								@mail nvarchar(200)
AS
BEGIN
	UPDATE TaiKhoan
	SET tenDangNhap = @tenDangNhap,
		matKhau = @matKhau,
		chucNang = @chucNang,
		mail =@mail
	WHERE maNV =@maNV
END
GO

--Đổi mật khẩu
CREATE PROC sp_DoiMatKhau @matKhau varchar(MAX),
						  @tenDangNhap varchar(50)
AS
BEGIN
    UPDATE TaiKhoan SET  matKhau=@matKhau WHERE tenDangNhap=@tenDangNhap
END
GO


--/*----------- KHÁCH HÀNG -----------*/

-- Thêm khách hàng
CREATE PROC sp_ThemKhachHang @hoKH nvarchar(50),
							 @tenKH nvarchar(20),
							 @soDT nvarchar(10),
							 @email nvarchar(100),
							 @diaChi nvarchar(100),
							 @hangKH nvarchar(10)
AS
BEGIN
	INSERT INTO KhachHang(hoKH,tenKH,soDT,email,diaChi,hangKH) 
	VALUES (@hoKH,@tenKH,@soDT,@email,@diaChi,@hangKH)
END
GO

-- Cập nhật khách hàng
CREATE PROC sp_CapNhatKhachHang  @maKH int,
								 @hoKH nvarchar(50),
								 @tenKH nvarchar(20),
								 @soDT nvarchar(10),
								 @email nvarchar(100),
								 @diaChi nvarchar(100),
								 @hangKH nvarchar(10)
AS
BEGIN
	UPDATE KhachHang
	SET hoKH = @hoKH,
		tenKH= @tenKH, 
		soDT=@soDT,
		email= @email,
		diaChi=@diaChi,
		hangKH = @hangKH
	WHERE maKH = @maKH
END
GO

-- Xóa khách hàng
CREATE PROC sp_XoaKhachHang  @maKH int
AS
BEGIN
	IF EXISTS (SELECT 1 FROM HoaDon WHERE maKH = @maKH)
	BEGIN
		UPDATE HoaDon SET maKH = 1 WHERE maKH =@maKH
	END
	DELETE FROM KhachHang WHERE maKH = @maKH
END
GO


--/*----------- NHẬP KHO -----------*/

-- Thêm phiếu nhập kho
CREATE PROC sp_ThemNhapKho   
    @ngayNhap datetime,
    @maNV int,
    @maNCC int,
    @ghiChu nvarchar(max),
    @maNK int OUTPUT   -- Trả về mã nhập kho
AS
BEGIN
    INSERT INTO NhapKho(ngayNhap,maNV,maNCC,ghiChu) 
    VALUES (@ngayNhap,@maNV,@maNCC,@ghiChu)

    SET @maNK = SCOPE_IDENTITY(); -- LẤY mã NK vừa thêm
END
GO


-- Lấy danh sách các phiếu nhập kho kể từ ngày được chọn
CREATE PROC sp_LayDSNhapKho_NgayNhap @ngayNhap datetime
AS
BEGIN
	SELECT *
	FROM NhapKho
	WHERE ngayNhap >= @ngayNhap ; 
END
GO


--/*----------- CHI TIẾT NHẬP KHO -----------*/

-- Thêm chi tiết nhập kho
CREATE PROC sp_ThemChiTietNhapKho   @maNK int,
									 @maSP int,
									 @soLuongNhap int,
									 @donGiaNhap decimal(18,2)
AS
BEGIN
	-- Thêm chi tiết nhập kho
	INSERT INTO ChiTietNhapKho(maNK,maSP,soLuongNhap,donGiaNhap) 
	VALUES (@maNK,@maSP,@soLuongNhap,@donGiaNhap)

	-- Cập nhật số lượng tồn kho của sản phẩm
	UPDATE SanPham
    SET tonKho = tonKho + @soLuongNhap
    WHERE maSP = @maSP;
END
GO

-- Xóa chi tiết nhập kho
CREATE PROC sp_XoaChiTietNhapKho @maNK int
AS
BEGIN
	-- Cập nhật tồn kho: trừ đi số lượng đã nhập
	UPDATE s
	SET s.tonKho = s.tonKho - c.soLuongNhap
	FROM SanPham s INNER JOIN ChiTietNhapKho c ON s.maSP = c.maSP
	WHERE c.maNK = @maNK

	-- Xóa chi tiết nhập kho theo mã nhập kho
	DELETE FROM ChiTietNhapKho WHERE maNK = @maNK;
END
GO



--/*----------- HÓA ĐƠN -----------*/

-- Thêm hóa đơn
CREATE PROC sp_ThemHoaDon   
    @ngayLapHD datetime,
    @maNV int,
    @maKH int,
    @phuongThucTT nvarchar(50),
    @maHD int OUTPUT   -- Trả về mã hóa đơn vừa tạo
AS
BEGIN
    INSERT INTO HoaDon(ngayLapHD,maNV,maKH,phuongThucTT) 
    VALUES (@ngayLapHD, @maNV,@maKH,@phuongThucTT)

    SET @maHD = SCOPE_IDENTITY(); -- LẤY mã hóa đơn vừa thêm
END
GO

-- Lấy danh sách các hóa đơn kể từ ngày được chọn
CREATE PROC sp_LayDSHoaDon_ngayLapHD @ngayLapHD datetime
AS
BEGIN
	SELECT *
	FROM HoaDon
	WHERE ngayLapHD >= @ngayLapHD ; 
END
GO

-- Lấy danh sách các hóa đơn kể từ ngày được chọn + mã nhân viên
CREATE PROC sp_LayDSHoaDon_maNV_ngayLapHD @maNV int,@ngayLapHD datetime
AS
BEGIN
	SELECT *
	FROM HoaDon
	WHERE maNV = @maNV AND ngayLapHD >= @ngayLapHD ; 
END
GO


--/*----------- CHI TIẾT HÓA ĐƠN -----------*/


-- Thêm thông tin chi tiết cho hóa đơn
CREATE PROC sp_ThemChiTietHD   @maHD int,
							   @maSP int,
							   @soLuong int,
							   @donGiaBan decimal(18,2),
							   @tyLeGiamGia float
AS
BEGIN
	-- Thêm chi tiết hóa đơn
	INSERT INTO ChiTietHD(maHD,maSP,soLuong,donGiaBan, tyLeGiamGia) 
	VALUES (@maHD,@maSP,@soLuong,@donGiaBan, @tyLeGiamGia)

	-- Cập nhật số lượng tồn kho của sản phẩm
	UPDATE SanPham
    SET tonKho = tonKho - @soLuong
    WHERE maSP = @maSP;
END
GO

-- Xóa chi tiết hóa đơn
CREATE PROC sp_XoaChiTietHoaDon @maHD int
AS
BEGIN
	-- Cập nhật tồn kho: cộng thêm số lượng đã được bán trước đó
	UPDATE s
	SET s.tonKho = s.tonKho + c.soLuong
	FROM SanPham s INNER JOIN ChiTietHD c ON s.maSP = c.maSP
	WHERE c.maHD = @maHD

	-- Xóa chi tiết nhập kho theo mã nhập kho
	DELETE FROM ChiTietHD WHERE maHD = @maHD;
END
GO


--/*----------- THỐNG KÊ BÁO CÁO -----------*/

-- Doanh thu tổng
CREATE PROC sp_DoanhThuTong  @Thang INT,
    @Nam INT
AS
BEGIN
	-- Nếu không truyền tháng/năm thì lấy tháng/năm hiện tại
    IF @Thang = 0 AND @Nam = 0
    BEGIN
		SELECT SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
		FROM ChiTietHD CT JOIN HoaDon HD ON CT.maHD = HD.maHD
		WHERE DAY(HD.ngayLapHD) = DAY(GETDATE())
			AND MONTH(HD.ngayLapHD) = MONTH(GETDATE()) AND YEAR(HD.ngayLapHD) = YEAR(GETDATE())
    END
	ELSE IF @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
		FROM ChiTietHD CT JOIN HoaDon HD ON CT.maHD = HD.maHD
		WHERE YEAR(HD.ngayLapHD) = @Nam
	END
	ELSE
	BEGIN
		SELECT SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
		FROM ChiTietHD CT JOIN HoaDon HD ON CT.maHD = HD.maHD
		WHERE MONTH(HD.ngayLapHD) = @Thang AND YEAR(HD.ngayLapHD) = @Nam
	END
END
GO


-- Doanh thu của từng loại sản phẩm
CREATE PROC sp_ThongKeLoaiSP  @Thang INT ,
    @Nam INT 
AS
BEGIN
	-- Nếu tháng/năm đều bằng 0 thì lấy tháng/năm hiện tại
    IF @Thang = 0 AND @Nam =0
    BEGIN
        SELECT 
		LSP.tenLoai AS loaiSP,
		SUM(CT.soLuong) AS soLuongBan,
		SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
		FROM LoaiSanPham LSP
		JOIN SanPham SP ON LSP.maLoai = SP.maLoai
		JOIN ChiTietHD CT ON SP.maSP = CT.maSP
		JOIN HoaDon HD ON CT.maHD = HD.maHD
		WHERE DAY(HD.ngayLapHD) = DAY(GETDATE())
			AND MONTH(HD.ngayLapHD) = MONTH(GETDATE())
			  AND YEAR(HD.ngayLapHD) = YEAR(GETDATE())
		GROUP BY LSP.tenLoai
		ORDER BY soLuongBan DESC;
    END
	ELSE IF @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT 
		LSP.tenLoai AS loaiSP,
		SUM(CT.soLuong) AS soLuongBan,
		SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
		FROM LoaiSanPham LSP
		JOIN SanPham SP ON LSP.maLoai = SP.maLoai
		JOIN ChiTietHD CT ON SP.maSP = CT.maSP
		JOIN HoaDon HD ON CT.maHD = HD.maHD
		WHERE YEAR(HD.ngayLapHD) = @Nam
		GROUP BY LSP.tenLoai
		ORDER BY soLuongBan DESC;
	END
	ELSE
	BEGIN
		SELECT 
		LSP.tenLoai AS loaiSP,
		SUM(CT.soLuong) AS soLuongBan,
		SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
		FROM LoaiSanPham LSP
		JOIN SanPham SP ON LSP.maLoai = SP.maLoai
		JOIN ChiTietHD CT ON SP.maSP = CT.maSP
		JOIN HoaDon HD ON CT.maHD = HD.maHD
		WHERE MONTH(HD.ngayLapHD) = @Thang
			  AND YEAR(HD.ngayLapHD) = @Nam
		GROUP BY LSP.tenLoai
		ORDER BY soLuongBan DESC;
	END	
END
GO

-- Lấy tổng số hóa đơn
CREATE PROC sp_LayTongHoaDon @Thang int, @Nam int
AS
BEGIN
	-- Nếu cả tháng và năm đều = 0 thì lấy ngày, tháng, năm hiện tại
    IF @Thang = 0 AND @Nam = 0
	BEGIN
		SELECT COUNT(maHD) 
		FROM  HoaDon 
		WHERE DAY(ngayLapHD) = DAY(GETDATE())
			AND MONTH(ngayLapHD) = MONTH(GETDATE()) 
			AND YEAR(ngayLapHD) = YEAR(GETDATE())
	END
	ELSE IF  @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT COUNT(maHD) 
		FROM  HoaDon 
		WHERE YEAR(ngayLapHD) = @Nam
	END
	ELSE
	BEGIN
		SELECT COUNT(maHD) 
		FROM  HoaDon 
		WHERE MONTH(ngayLapHD) = @Thang AND YEAR(ngayLapHD) = @Nam
	END	
END
GO

-- Lấy tổng tiền nhập 
CREATE PROC sp_LayTongTienNhap @Thang int, @Nam int
AS
BEGIN
	-- Nếu cả tháng và năm đều = 0 thì lấy ngày, tháng, năm hiện tại
    IF @Thang = 0 AND @Nam = 0
	BEGIN
		SELECT SUM(CT.soLuong * S.donGiaNhap) 
		FROM HoaDon HD JOIN ChiTietHD CT ON HD.maHD = CT.maHD JOIN SanPham S ON CT.maSP = S.maSP
		WHERE DAY(HD.ngayLapHD) = DAY(GETDATE())
			AND MONTH(HD.ngayLapHD) = MONTH(GETDATE()) 
			AND YEAR(HD.ngayLapHD) = YEAR(GETDATE())
	END
	ELSE IF  @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT SUM(CT.soLuong * S.donGiaNhap) 
		FROM HoaDon HD JOIN ChiTietHD CT ON HD.maHD = CT.maHD JOIN SanPham S ON CT.maSP = S.maSP
		WHERE YEAR(HD.ngayLapHD) = @Nam
	END
	ELSE
	BEGIN
		SELECT SUM(CT.soLuong * S.donGiaNhap) 
		FROM HoaDon HD JOIN ChiTietHD CT ON HD.maHD = CT.maHD JOIN SanPham S ON CT.maSP = S.maSP
		WHERE MONTH(HD.ngayLapHD) = @Thang AND YEAR(HD.ngayLapHD) = @Nam
	END	
END
GO


-- Lấy doanh thu của từng ngày trong tháng, năm được thiết lập
CREATE PROC sp_LayDoanhThuTungNgayTrongThang @thang int, @nam int
AS
BEGIN
	SELECT CAST(HD.ngayLapHD AS DATE) AS Ngay,
         SUM(CT.soLuong * CT.donGiaBan*(1 - ISNULL(CT.tyLeGiamGia,0)/100.0)) AS doanhThu
	FROM ChiTietHD CT JOIN HoaDon HD ON CT.maHD = HD.maHD
	WHERE MONTH(HD.ngayLapHD) = @thang 
		 AND YEAR(HD.ngayLapHD) = @nam
	GROUP BY CAST(HD.ngayLapHD AS DATE)
	ORDER BY Ngay
END
GO


-- Thống kê số lượng tồn kho và số lượt bán của sản phẩm
CREATE PROC sp_ThongKeSLSanPham @Thang int, @Nam int
AS
BEGIN
	-- Nếu cả tháng và năm đều = 0 thì lấy ngày, tháng, năm hiện tại
    IF @Thang = 0 AND @Nam = 0
	BEGIN
		SELECT s.maSP, s.tenSP, s.tonKho, SUM(c.soLuong) AS soLuongBan
		FROM SanPham s JOIN ChiTietHD c ON s.maSP = c.maSP JOIN HoaDon h ON c.maHD = h.maHD
		WHERE DAY(h.ngayLapHD) = DAY(GETDATE())
			AND MONTH(h.ngayLapHD) = MONTH(GETDATE()) 
					AND YEAR(h.ngayLapHD) = YEAR(GETDATE())
		GROUP BY s.maSP, s.tenSP, s.tonKho
		ORDER BY soLuongBan DESC
	END
	ELSE IF  @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT s.maSP, s.tenSP, s.tonKho, SUM(c.soLuong) AS soLuongBan
		FROM SanPham s JOIN ChiTietHD c ON s.maSP = c.maSP JOIN HoaDon h ON c.maHD = h.maHD
		WHERE YEAR(h.ngayLapHD) = @Nam
		GROUP BY s.maSP, s.tenSP, s.tonKho
		ORDER BY soLuongBan DESC		
	END
	ELSE
	BEGIN
		SELECT s.maSP, s.tenSP, s.tonKho, SUM(c.soLuong) AS soLuongBan
		FROM SanPham s JOIN ChiTietHD c ON s.maSP = c.maSP JOIN HoaDon h ON c.maHD = h.maHD
		WHERE MONTH(h.ngayLapHD) = @Thang
					AND YEAR(h.ngayLapHD) = @Nam
		GROUP BY s.maSP, s.tenSP, s.tonKho
		ORDER BY soLuongBan DESC
	END	
END
GO

-- Thống kê số lượng nhập kho của các sản phẩm
CREATE PROC sp_ThongKeNhapKho @Thang int, @Nam int
AS
BEGIN
	-- Nếu cả tháng và năm đều = 0 thì lấy ngày, tháng, năm hiện tại
    IF @Thang = 0 AND @Nam = 0
	BEGIN
		SELECT s.maSP, s.tenSP, SUM(c.soLuongNhap) AS soLuongNhap
		FROM SanPham s JOIN ChiTietNhapKho c ON s.maSP = c.maSP JOIN NhapKho n ON c.maNK = n.maNK
		WHERE DAY(n.ngayNhap) = DAY(GETDATE())
					AND MONTH(n.ngayNhap) = MONTH(GETDATE()) 
					AND YEAR(n.ngayNhap) = YEAR(GETDATE())
		GROUP BY s.maSP, s.tenSP
		ORDER BY soLuongNhap DESC		
	END
	ELSE IF  @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT s.maSP, s.tenSP, SUM(c.soLuongNhap) AS soLuongNhap
		FROM SanPham s JOIN ChiTietNhapKho c ON s.maSP = c.maSP JOIN NhapKho n ON c.maNK = n.maNK
		WHERE YEAR(n.ngayNhap) = @Nam
		GROUP BY s.maSP, s.tenSP
		ORDER BY soLuongNhap DESC	
	END
	ELSE
	BEGIN
		SELECT s.maSP, s.tenSP, SUM(c.soLuongNhap) AS soLuongNhap
		FROM SanPham s JOIN ChiTietNhapKho c ON s.maSP = c.maSP JOIN NhapKho n ON c.maNK = n.maNK
		WHERE MONTH(n.ngayNhap) = @Thang
					AND YEAR(n.ngayNhap) = @Nam
		GROUP BY s.maSP, s.tenSP
		ORDER BY soLuongNhap DESC
	END	
END
GO


-- Thống kê hãng sản xuất 
CREATE PROC sp_ThongKeHangSX @Thang int, @Nam int
AS
BEGIN
	-- Nếu cả tháng và năm đều = 0 thì lấy ngày, tháng, năm hiện tại
    IF @Thang = 0 AND @Nam = 0
	BEGIN
		SELECT hsx.tenHang, SUM(c.soLuong) AS soLuong
		FROM SanPham s JOIN HangSanXuat hsx ON s.maHang = hsx.maHang JOIN ChiTietHD c ON c.maSP = s.maSP
		JOIN HoaDon h ON c.maHD = h.maHD
		WHERE DAY(h.ngayLapHD) = DAY(GETDATE())
					AND MONTH(h.ngayLapHD) = MONTH(GETDATE()) 
					AND YEAR(h.ngayLapHD) = YEAR(GETDATE())
		GROUP BY hsx.tenHang
		ORDER BY soLuong DESC		
	END
	ELSE IF  @Thang = 0 AND @Nam <> 0
	BEGIN
		SELECT hsx.tenHang, SUM(c.soLuong) AS soLuong
		FROM SanPham s JOIN HangSanXuat hsx ON s.maHang = hsx.maHang JOIN ChiTietHD c ON c.maSP = s.maSP
		JOIN HoaDon h ON c.maHD = h.maHD
		WHERE YEAR(h.ngayLapHD) = @Nam
		GROUP BY hsx.tenHang
		ORDER BY soLuong DESC
	END
	ELSE
	BEGIN
		SELECT hsx.tenHang, SUM(c.soLuong) AS soLuong
		FROM SanPham s JOIN HangSanXuat hsx ON s.maHang = hsx.maHang JOIN ChiTietHD c ON c.maSP = s.maSP
		JOIN HoaDon h ON c.maHD = h.maHD
		WHERE MONTH(h.ngayLapHD) = @Thang
					AND YEAR(h.ngayLapHD) = @Nam
		GROUP BY hsx.tenHang
		ORDER BY soLuong DESC
	END	
END
GO

