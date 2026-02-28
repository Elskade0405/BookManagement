# BookManagement

## Yêu cầu
- .NET 8
- MySQL

## Cài đặt
1. Clone repository
2. Restore packages: dotnet restore
3. Cài đặt dotnet-ef(Nếu chưa có): dotnet tool install --global dotnet-ef
4. Chỉnh lại user và pass của mysql trong appsettings.json
5. Tạo database: dotnet ef migrations add InitialCreate
6. Cập nhật database: dotnet ef database update
7. Chạy ứng dụng: dotnet run

## API
- GET /authors: Lấy danh sách tác giả
- GET /authors/{id}: Lấy thông tin tác giả
- POST /authors: Thêm tác giả
- PUT /authors/{id}: Cập nhật tác giả
- DELETE /authors/{id}: Xóa tác giả
- GET /books: Lấy danh sách sách
- GET /books/{id}: Lấy thông tin sách
- POST /books: Thêm sách
- PUT /books/{id}: Cập nhật sách
- DELETE /books/{id}: Xóa sách
