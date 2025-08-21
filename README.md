# QuanLyCuaHangDienTu
## 1. Giới thiệu
**QuanLyCuaHangDienTu** là một ứng dụng quản lý bán hàng điện tử được xây dựng để hỗ trợ cửa hàng quản lý sản phẩm, đơn hàng, khách hàng và doanh thu một cách hiệu quả.

## 2. Tính năng chính
- **Đăng nhập/Phân quyền**
- **Trang bán hàng**
  + Thêm sản phẩm vào giỏ hàng, tạo đơn hàng và cập nhật lượng tồn kho.
  + Xuất hóa đơn ra file PDF.
  + Xem lại lịch sử đơn hàng đã bán.
- **Quản lý danh mục sản phẩm:** 
  + Thêm/Sửa/Xóa sản phẩm
  + Tra cứu theo mã/hãng/loại
  + Cập nhật tồn kho, giá bán
- **Quản lý nhập hàng:**
  + Tạo phiếu nhập hàng, cập nhật tồn kho
  + Tra cứu lịch sử nhập hàng
- **Quản lý đơn hàng đã hoàn tất (do người khác bán):**
  + Tìm kiếm, xem chi tiết hóa đơn qua mã hóa đơn/thời gian
  + In hóa đơn ra PDF
- **Quản lý nhân viên:** 
  + Thêm/Sửa/Xóa nhân viên
- **Quản lý khách hàng:**
  + Thêm/Sửa/Xóa khách hàng
  + Tìm kiếm theo SĐT, tên
  + Phân loại theo hạng (Thường, Thân thiết, VIP)
- **Quản lý khuyến mãi:**
  + Tạo, cập nhật, xóa và áp dụng khuyến mãi
- **Thống kê, báo cáo:** 
  + Doanh thu theo tháng, năm
  + Thống kê sản phẩm: sản phẩm bán chạy, loại sản phẩm/hãng sản xuất được ưa chuộng
  + Thống kê nhập hàng
  + Xuất báo cáo ra file Excel và gửi Mail thông báo đến quản trị viên
## 3. Cấu trúc thư mục
- **PresentationLayer:** Giao diện người dùng (UI)
- **BusinessLayer:** Xử lý logic nghiệp vụ
- **DataLayer:** Kết nối và truy vấn dữ liệu
- **TransferObject:** Định nghĩa các DTO (Data Transfer Objects) 
## 4. Yêu cầu hệ thống
- Hệ điều hành: Windows 10 trở lên (hoặc phù hợp với môi trường làm việc của bạn).
- Ngôn ngữ lập trình / Framework: C#, .NET 
- Cơ sở dữ liệu: SQL Server.
- Các thư viện bên ngoài: iTextSharp, ClosedXML.

## 5. Hướng dẫn cài đặt & chạy ứng dụng
1. Clone repository:
   ```bash
   git clone https://github.com/ThuyAn4342/QuanLyCuaHangDienTu.git
2. Mở SQL Server và chạy file script QuanLyCuaHang.sql để tạo Database
3. Mở project trong môi trường phát triển Visual Studio.
4. Khởi động project và thao tác các chức năng trên hệ thống
