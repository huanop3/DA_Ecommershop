# DA_EcommerShop - Dự án E-commerce Shop

## Giới thiệu
DA_EcommerShop là một dự án thương mại điện tử được xây dựng bằng ASP.NET Core Blazor, sử dụng kiến trúc đa tầng. Dự án cung cấp các chức năng cơ bản của một hệ thống mua sắm trực tuyến.

## Công nghệ sử dụng
- **Backend**: ASP.NET Core API
- **Frontend**: Blazor WebAssembly
- **Database**: Entity Framework Core với SQL Server
- **Authentication**: JWT (JSON Web Tokens)
- **DevOps**: Docker và Docker Compose

## Cấu trúc dự án
```
DA_EcommerShop/
├── controllers/            # API Controllers
├── Infrastructure/         # Tầng hạ tầng (Repositories, Services, UnitOfWork)
├── Models/                 # Domain Models và ViewModels
│   ├── dbEcommer/         # Entity Models
│   └── ViewModel/         # View Models
├── Pages/                  # Blazor Pages
├── Service_Fe/             # Frontend Services
└── util/                   # Các tiện ích
```

## Mô hình dữ liệu
Dự án bao gồm các entity chính:
- User, Role, UserRole: Quản lý người dùng và phân quyền
- Product, Category, ProductVariant, ProductImage: Quản lý sản phẩm
- Cart, CartItem: Giỏ hàng
- Order, OrderItem, OrderStatus: Đơn hàng
- Coupon, Promotion: Khuyến mãi và mã giảm giá
- Payment, Shipment: Thanh toán và vận chuyển

## Cài đặt và Khởi chạy
### Yêu cầu
- .NET 8.0 SDK
- SQL Server
- Docker (tùy chọn)

### Chạy ứng dụng bằng Docker
```bash
docker-compose up
```

### Chạy ứng dụng bằng .NET CLI
```bash
dotnet restore
dotnet run
```

## License
[MIT](LICENSE)