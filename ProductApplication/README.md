# Product Application

A console-based product management application built with .NET 8.0. Manage an inventory of products through an interactive command-line interface.

## Features

- Add new products with name, price, and quantity
- Update product stock levels
- Delete products from inventory
- View all products
- Duplicate product name detection
- Input validation for prices and quantities

## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

### Build

```bash
dotnet build
```

### Run

```bash
dotnet run
```

## Usage

The application presents an interactive menu:

```
1. Add Product
2. Update Stock
3. Delete Product
4. View All Products
5. Exit
```

### Adding a Product

Select option `1` and enter the product name, price, and quantity when prompted.

### Updating Stock

Select option `2`, enter the product name, and specify the new quantity.

### Deleting a Product

Select option `3` and enter the name of the product to remove.

### Viewing Products

Select option `4` to display all products with their name, price, and quantity.

## Project Structure

```
ProductApplication/
├── Program.cs              # Entry point and UI logic
├── Domain/
│   └── Product.cs          # Product data model
└── Service/
    └── ProductService.cs   # Business logic layer
```

## License

This project is open source.
