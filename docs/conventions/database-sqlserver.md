# Database Convention — SQL Server Express for RajMango API

## Scope

This convention applies to the active RajMango SQL Server Express database used by `rajmango-api`.

Do not introduce PostgreSQL syntax or naming into the active RajMango database unless a migration is explicitly approved.

---

## Naming Style

Use project-consistent SQL Server naming. Prefer PascalCase if the existing database does not already enforce another style.

| Object | Convention | Example |
|---|---|---|
| Table | PascalCase | `Orders`, `Customers`, `MangoTypes` |
| Column | PascalCase | `OrderNumber`, `CreatedAt` |
| Primary key | `Id` or existing convention | `Id`, `OrderId` |
| Foreign key | `<Entity>Id` | `CustomerId`, `MangoTypeId` |
| Index | `IX_<Table>_<Column>` | `IX_Orders_OrderStatus` |
| Unique index | `UX_<Table>_<Column>` | `UX_Orders_OrderNumber` |
| FK constraint | `FK_<Child>_<Parent>_<Column>` | `FK_Orders_Customers_CustomerId` |
| Check constraint | `CK_<Table>_<Rule>` | `CK_OrderDetails_Quantity_Minimum` |

Preserve existing naming if already established.

---

## Launch Tables

Likely launch tables:

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
Users
Roles
UserRoles
AuditLogs
```

Later tables:

```text
Complaints
ComplaintAttachments
Feedbacks
Refunds
Notifications
Policies
```

---

## Column Rules

Common columns:

```text
Id
CreatedAt
CreatedBy
UpdatedAt
UpdatedBy
IsDeleted
DeletedAt
RowVersion
```

Rules:

- Use `decimal(18,2)` or `decimal(18,4)` for money.
- Use `datetime2` for timestamps.
- Store application timestamps in UTC where possible.
- Use `bit` for booleans.
- Use `nvarchar` for text.
- Avoid `float`/`real` for money.
- Avoid `text`/`ntext`; use `nvarchar(max)` if needed.
- Use `rowversion` for optimistic concurrency where needed.

---

## Business Constraints

Enforce in application and database where practical:

- Minimum order quantity is 10 kg.
- Crate types are 10 kg and 20 kg.
- Order number is unique.
- Payment references a valid order.
- Customer data is scoped by `CustomerId`.
- Amounts cannot be negative.

Recommended constraints:

```text
CK_OrderDetails_Quantity_Minimum
CK_Payments_Amount_NonNegative
CK_Orders_TotalAmount_NonNegative
UX_Orders_OrderNumber
```

---

## Indexing

Recommended indexes:

```text
Orders:
- UX_Orders_OrderNumber
- IX_Orders_CustomerId
- IX_Orders_OrderStatus
- IX_Orders_PaymentStatus
- IX_Orders_CreatedAt
- IX_Orders_CourierStationId

OrderDetails:
- IX_OrderDetails_OrderId
- IX_OrderDetails_MangoTypeId

Payments:
- IX_Payments_OrderId
- IX_Payments_PaymentStatus
- IX_Payments_TransactionId

MangoAvailability:
- IX_MangoAvailability_MangoTypeId
- IX_MangoAvailability_Status
- IX_MangoAvailability_StartDate_EndDate

CourierStations:
- IX_CourierStations_District_Area
```

Do not over-index before launch.

---

## EF Core Migration Rules

Migration names must be descriptive:

```text
Add_Mango_Availability
Create_Courier_Stations
Add_Order_Status_And_Payment_Status
Add_Order_Number_Unique_Index
```

Rules:

- Never use vague names like `Migration1`.
- Avoid destructive migrations before launch.
- Explain data-loss risk before applying a migration.
- Keep migrations in source control.
- Seed lookup data intentionally.

---

## Known Migration Behaviors

### Seed timestamp drift (Clock.Now)

Some seed data uses `Clock.Now()` to set `CreatedAt` values. Because `Clock.Now()` is evaluated at
migration-scaffolding time rather than at a fixed point, EF Core will report **"pending model changes"**
after almost any `migrations add` run — even when no schema changes have been made.

This is a **pre-existing seed-data behavior** in the project and is **not a schema problem**.

Rules:

- Do not create an additional migration just to stabilise seed timestamps unless it is an intentional
  decision to freeze them.
- Verify that a "pending model changes" warning is caused only by `UpdateData` rows before concluding
  that a schema change is needed.
- A migration that contains only `UpdateData` operations and no DDL (`CreateTable`, `AlterColumn`,
  `CreateIndex`, etc.) is a seed-only migration and provides no value — do not commit it.

### SmsLogs migration history

Only one SMS-related migration exists in the project:

| Migration | What it does |
|-----------|-------------|
| `AddSmsLogs` | Creates `SmsLogs` table with `Message nvarchar(280)` and three indexes. No `AlterColumn` follows. |

Any `has-pending-model-changes` warning after `AddSmsLogs` is applied is a seed timestamp diff only.
The `SmsLogs` schema has no pending differences.

---

## Seed Data

Stable seed data:

```text
CrateTypes:
- 10 kg
- 20 kg

PaymentMethods:
- bKash
- BankTransfer
- Manual
- Due

PaymentStatuses:
- Pending
- PartiallyPaid
- Paid
- Failed
- Refunded
- Due
```

Mango types may include:

```text
Himsagor / Khirshapat
Langra
Brindabon
Fazli
Bari-4
```

---

## Reporting

Launch reports:

```text
Daily sales
Seasonal sales
Mango-wise sales
Customer-wise sales
Payment collection
Due payments
Delivery status
Admin dashboard metrics
```

Reports must not expose unauthorized customer data.

---

## Claude Rules

Claude must:

- Inspect existing entities/migrations first.
- Preserve existing naming.
- Explain migration impact.
- Generate migrations only when needed.
- Avoid PostgreSQL syntax in SQL Server code.
- Keep launch database changes minimal.
