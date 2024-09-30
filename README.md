> [!IMPORTANT]
Still working on it ...

# Online Shop

Online Shop is an e-commerce website that allows customers to view, select, and purchase products. This website is designed using **Clean Architecture** to enable easier development and maintenance.

## Architecture

This project follows **Clean Architecture**, ensuring separation of concerns and flexibility for future development. The solution is divided into several layers and projects, each with a specific responsibility:

- **Common**: Contains shared utilities and classes used across the entire project.
- **Application**: Handles the business logic, application services, and use cases.
- **Domain**: Contains the core entities and domain logic, independent of any external concerns.
- **InfraStructure**: Provides the implementations for external dependencies like file systems or external APIs.
- **Persistence**: Manages database-related logic, including **Entity Framework** configurations and migrations.
- **Endpoint**: Implements the WebApplication in **MVC (Model-View-Controller)** pattern to handle the user interface. 

This structure helps in maintaining clear separation of concerns and makes the project scalable and easier to manage.

## Features

- **Admin Panel (CRM)**: Manage customers, orders, and products through a dedicated admin interface.
- **CQRS Pattern**: Implements **CQRS** to separate read and write operations, optimizing performance.
- **Entity Framework (EF)**: Utilizes **Entity Framework** for database operations, simplifying data access and management.

## Upcoming Features

1. **Shopping Cart**: Users can add products to a cart and proceed to checkout.
2. **Online Payment**: Integrated with **Zarinpal**, directing users to a secure payment page.
3. **Email Verification**: Users receive a verification code for email validation after registration.
4. **Advanced Reporting**: Sales trends, customer insights, and analytics for admins.
5. **Notifications**: Real-time notifications for order updates and promotions.
6. **Inventory Management**: Track product availability and notify customers when stock is low.

## Future Enhancements

- **Full CQRS Implementation**: Expanding the use of CQRS for all project layers.
- **Refined UI/UX**: Improving the design for better usability across devices.
