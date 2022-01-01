# framework_IS220.1_09


- 19521479 - Nguyễn Tăng Hảo (100%). https://www.facebook.com/profile.php?id=100029866783334
- 19520631 - Đỗ Lê Anh Khoa (100%). https://www.facebook.com/khoadole21
- 19521804 - Trần Phi Long (100%). https://www.facebook.com/Phongli.J
- 19521513 - Thân Trung Hiếu (100%) https://www.facebook.com/hieuthanln

###################
Giới thiệu về đồ án
###################

 Đồ án xây dựng website thương mại điện tử kinh doanh mặt hàng linh kiện máy tính.
*******************
Các chức năng của đồ án:
*******************


- Giỏ hàng 

- In hóa đơn excel 

- Đăng ký/đăng nhập
- Plugin bình luận facebook
- Phân trang giữa các sản phẩm, tin tức
- Tìm kiếm sản phẩm 
- Lọc giá sản phẩm
- Quản lý đơn hàng lịch sử
- Xem tin tức
- Hủy đơn hàng, 
- Sử dụng voucher
- Quản trị admin 
- Gửi email google cho khách hàng,
- Chat giữa các khách hàng 
- Thêm xóa sửa cơ bản cho các nhiệm vụ quản lý trong database

Các công nghệ: Ajax, SMTP mail, Jquery, Signal R

**************************
Cài đặt chương trình website
**************************

Cơ sở dữ liệu: Mysql

Các nuget package đã có trong project.

*******************
Các bước cài đặt
*******************

1. Vào thư mục Database chạy file script sql trong mysql workbench. Đặt tên database là : linhkienchinhthuc

2. Mở project -> Thay đổi passwork trong appsetting.json cho đúng với database của workbench.

3. Vào thư mục model -> linhkienchinhthucContext.cs. Chỉnh sửa thông tin trong optionsBuilder (pwd->password) 
ví dụ: optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=[password của workbench];database=linhkienchinhthuc");

4. Password người khách hàng có sẵn: tk: khoale@gmail.com, mật khẩu: benten2801

5. Để vô trang admin. gõ /Admin trên trang chính localhost. tk: haohan2801, mật khẩu: 123





