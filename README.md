# Library Management System

یک سیستم مدیریت کتابخانه مدرن و حرفه‌ای که با استفاده از **.NET** و الگوهای طراحی پیشرفته توسعه یافته است.

## 📋 فهرست مطالب

- [معرفی](#معرفی)
- [ویژگی‌ها](#ویژگی‌ها)
- [معماری پروژه](#معماری-پروژه)
- [پیش‌نیازها](#پیش‌نیازها)
- [نصب و راه‌اندازی](#نصب-و-راه‌اندازی)
- [ساختار پروژه](#ساختار-پروژه)
- [API Endpoints](#api-endpoints)
- [تکنولوژی‌های استفاده شده](#تکنولوژی‌های-استفاده-شده)
- [توسعه‌دهنده](#توسعه‌دهنده)

## 🎯 معرفی

این پروژه یک سیستم مدیریت کتابخانه است که امکان مدیریت کتاب‌ها و نویسندگان را فراهم می‌کند. با استفاده از این سیستم می‌توانید:

- کتاب‌های جدید اضافه کنید
- اطلاعات کتاب‌ها را به‌روزرسانی کنید
- لیست کتاب‌ها را مشاهده کنید
- نویسندگان را مدیریت کنید
- کتاب‌های هر نویسنده را مشاهده کنید

## ✨ ویژگی‌ها

- ✅ **Clean Architecture** - معماری تمیز و قابل نگهداری
- ✅ **CQRS Pattern** - جداسازی عملیات خواندن و نوشتن
- ✅ **MediatR** - پیاده‌سازی الگوی Mediator
- ✅ **Entity Framework Core** - ORM قدرتمند برای دسترسی به داده‌ها
- ✅ **SQL Server** - پایگاه داده رابطه‌ای
- ✅ **FluentValidation** - اعتبارسنجی ورودی‌ها
- ✅ **Swagger/OpenAPI** - مستندات API
- ✅ **Unit Testing** - تست‌های واحد با xUnit
- ✅ **Dependency Injection** - تزریق وابستگی

## 🏗️ معماری پروژه

پروژه بر اساس الگوی **Clean Architecture** طراحی شده است که شامل لایه‌های زیر می‌باشد:

```
┌─────────────────────────────────────────┐
│         Presentation Layer              │
│         (Library.Api)                   │
├─────────────────────────────────────────┤
│         Application Layer               │
│         (Commands & Queries)            │
├─────────────────────────────────────────┤
│         Domain Layer                    │
│         (Entities & Business Logic)     │
├─────────────────────────────────────────┤
│         Infrastructure Layer            │
│         (Data Access & External Services)│
└─────────────────────────────────────────┘
```

### لایه‌ها

1. **Presentation (ارائه)**: شامل API Controllers و نقطه ورود برنامه
2. **Application (کاربرد)**: شامل Commandها، Queryها و منطق کسب‌وکار
3. **Domain (دامنه)**: شامل موجودیت‌ها و رابط‌های اصلی
4. **Infrastructure (زیرساخت)**: شامل پیاده‌سازی Repositoryها و DbContext

## 📦 پیش‌نیازها

قبل از اجرای پروژه، مطمئن شوید که موارد زیر نصب شده باشند:

- [.NET 8 SDK](https://dotnet.microsoft.com/download) یا بالاتر
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) یا [VS Code](https://code.visualstudio.com/)

## 🚀 نصب و راه‌اندازی

### 1. کلون کردن پروژه

```bash
git clone <repository-url>
cd LibraryManagement
```

### 2. تنظیمات پایگاه داده

در فایل `appsettings.json` اتصال به پایگاه داده را تنظیم کنید:

```json
{
  "ConnectionStrings": {
    "LibraryDbContext": "Server=localhost;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. اعمال Migrationها

```bash
dotnet ef database update --project Infrastructure --startup-project Presentation/Library.Api
```

### 4. اجرای پروژه

```bash
dotnet run --project Presentation/Library.Api
```

### 5. دسترسی به Swagger

پس از اجرای پروژه، مرورگر خود را باز کرده و به آدرس زیر بروید:

```
https://localhost:7001/swagger
```

یا

```
http://localhost:5001/swagger
```

## 📁 ساختار پروژه

```
LibraryManagement/
├── Core/
│   ├── Application/          # لایه کاربرد (Commands, Queries, Validators)
│   └── Domain/               # لایه دامنه (Entities, Interfaces)
├── Infrastructure/           # لایه زیرساخت (Repositories, DbContext, Migrations)
├── Presentation/
│   └── Library.Api/          # لایه ارائه (Controllers, Program.cs)
├── Test/
│   └── TestLibrary/          # تست‌های واحد
├── LibraryManagement.sln     # فایل Solution
└── README.md                 # این فایل
```

## 🔌 API Endpoints

### Books Controller

| متد | Endpoint | توضیحات |
|-----|----------|---------|
| POST | `/api/books` | افزودن کتاب جدید |
| PUT | `/api/books` | به‌روزرسانی کتاب |
| GET | `/api/books` | دریافت لیست کتاب‌ها |
| GET | `/api/books/{BookId}` | دریافت کتاب بر اساس شناسه |

### Authors Controller

| متد | Endpoint | توضیحات |
|-----|----------|---------|
| POST | `/api/authors` | افزودن نویسنده جدید |
| PUT | `/api/authors` | به‌روزرسانی نویسنده |
| GET | `/api/authors` | دریافت لیست نویسندگان |
| GET | `/api/authors/{Id}` | دریافت نویسنده بر اساس شناسه |
| GET | `/api/authors/{AuthorId}/AuthorBooks` | دریافت کتاب‌های نویسنده |

## 🛠️ تکنولوژی‌های استفاده شده

| تکنولوژی | نسخه | توضیحات |
|----------|------|---------|
| .NET | 8+ | فریم‌ورک اصلی |
| Entity Framework Core | 8+ | ORM |
| SQL Server | 2019+ | پایگاه داده |
| MediatR | Latest | الگوی Mediator |
| FluentValidation | Latest | اعتبارسنجی |
| xUnit | Latest | فریم‌ورک تست |
| Moq | Latest | Mocking برای تست |
| Swagger/OpenAPI | Latest | مستندات API |
| AutoMapper | Latest | Mapping بین اشیاء |

## 🧪 اجرای تست‌ها

برای اجرای تست‌های واحد از دستور زیر استفاده کنید:

```bash
dotnet test Test/TestLibrary/TestLibrary.csproj
```

## 👨‍💻 توسعه‌دهنده

**Mohammad Yousefi**

- Email: Mohammadmy619@email.com
- GitHub: [محمد یوسفی](https://github.com/Mohammadmy619)

## 📝 لایسنس

این پروژه تحت لایسنس شخصی توسعه یافته است.

---

<div dir="rtl">

> **نکته**: برای اطلاعات بیشتر می‌توانید به مستندات Swagger مراجعه کنید یا با توسعه‌دهنده تماس بگیرید.

</div>
