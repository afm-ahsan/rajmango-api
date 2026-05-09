# Backend Convention — .NET 8 + CQRS/MediatR for RajMango API

## Scope

This convention applies to the active `rajmango-api` backend.

```text
.NET 8
ASP.NET Core Web API
EF Core
SQL Server Express
CQRS/MediatR where applicable
Swagger/OpenAPI
```

Do not upgrade this repo to .NET 10 or PostgreSQL unless a separate migration task is approved.

---

## Architecture Direction

Use practical Clean Architecture + CQRS without risky rewrites.

Preferred logical structure:

```text
Domain
Application
Infrastructure
Api
```

If the current project structure differs, preserve it and improve incrementally.

---

## Launch Modules

Prioritize:

```text
Customers
CustomerAddresses
Receivers
MangoTypes
MangoAvailability
CrateTypes
Orders
OrderDetails
Payments
CourierProviders
CourierStations
Dashboard
Reports
UsersRoles
AuditLogs
```

Later:

```text
Complaints
Feedback
Refunds
Notifications
Policies
GoogleMaps
bKashGateway
FAQChatbot
```

---

## CQRS Rules

- Commands change state.
- Queries read state.
- Commands and queries return DTOs, not EF entities.
- One use case per folder where practical.
- Handlers orchestrate business workflow.
- Validators handle input validation.
- Controllers must not contain business logic.
- Use `CancellationToken` for async handlers.
- Keep handlers focused and testable.

Example shape:

```text
Application/Orders/Commands/CreateOrder/
├── CreateOrderCommand.cs
├── CreateOrderCommandHandler.cs
└── CreateOrderCommandValidator.cs
```

---

## Controller Rules

Continue with controllers if the existing project uses controllers.

Controllers should:

- Accept request DTOs.
- Call `IMediator`.
- Return response DTOs.
- Contain no business rules.
- Avoid direct `DbContext` usage in new code.

Route style:

```text
/api/orders
/api/mango-types
/api/payments
/api/courier-stations
```

---

## Mandatory Business Rules

- Minimum order quantity is 10 kg.
- Supported crate types are 10 kg and 20 kg.
- Customers may combine multiple crates.
- Orders can only be placed for available mango types.
- Mango price may vary by type/date/season.
- Total amount must be calculated server-side.
- Payment must reference an order.
- Customers may order for themselves or another receiver.
- Customers can only see their own orders/payments/addresses.
- Admin/operations users can update order status.

Order statuses:

```text
Draft
Submitted
Confirmed
Processing
Packed
Dispatched
InTransit
Delivered
Cancelled
Refunded
```

Payment statuses:

```text
Pending
PartiallyPaid
Paid
Failed
Refunded
Due
```

---

## Entity and DTO Rules

- Use PascalCase for C# types.
- Use `decimal` for money.
- Use UTC timestamps where possible.
- Prefer soft delete for customer/order/payment-related data.
- Do not expose EF entities directly from API responses.
- Use separate request and response DTOs.

Recommended DTO names:

```text
CreateOrderRequest
UpdateOrderStatusRequest
OrderDto
OrderListItemDto
PagedResult<T>
```

---

## EF Core Rules

- Use migrations for schema changes.
- Use descriptive migration names.
- Use `AsNoTracking()` for read-only queries.
- Add indexes for real list/search/report needs.
- Avoid destructive migrations before launch.
- Explain migration impact before applying schema changes.

Useful indexes:

```text
OrderNumber
CustomerId
OrderStatus
PaymentStatus
CreatedAt
MangoTypeId
CourierStationId
```

---

## Error Handling

Use consistent error responses.

Recommended shape:

```json
{
  "message": "Order quantity must be at least 10 kg.",
  "errorCode": "ORDER_MINIMUM_QUANTITY",
  "traceId": "..."
}
```

Status codes:

```text
400 validation
401 unauthorized
403 forbidden
404 not found
409 conflict
500 unexpected server error
```

Do not expose internal stack traces to clients.

---

## Security

- Enforce role-based authorization.
- Customers can only access their own data.
- Admin can access operational data.
- Finance can manage payment data.
- Operations can update order processing/delivery statuses.
- Do not log passwords, tokens, or sensitive payment data.
- Do not hardcode secrets.

---

## API Sync

`rajmango-api` owns the OpenAPI contract.

Rules:

- Keep Swagger/OpenAPI enabled and accurate.
- When DTOs/routes change, note the frontend impact.
- Generated frontend clients must not be manually edited.
- Keep API contracts stable before launch.

---

## Testing Priority

Prioritize tests for:

```text
Minimum order quantity
Crate calculation
Mango availability validation
Order total calculation
Payment status update
Customer data authorization
Order status transition
```

Test naming:

```text
MethodName_Scenario_ExpectedResult
```

---

## Claude Code Rules

Claude must:

- Analyze existing backend before changes.
- Keep launch changes small.
- Avoid framework upgrades.
- Avoid empty placeholder classes.
- Explain database migration impact.
- Summarize changed files and validation steps.
