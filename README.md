# RajMango API

Backend API repository for RajMango, a seasonal mango business automation platform.

## Purpose

This repository supports the backend for:

- Customer registration and profile management
- Mango catalog and seasonal availability
- Order placement
- Crate-based ordering
- Payment tracking
- Courier provider/station management
- Customer dashboard APIs
- Admin dashboard APIs
- Basic reports
- Swagger/OpenAPI contract for frontend sync

## Active Stack

```text
.NET 8
ASP.NET Core Web API
Entity Framework Core
SQL Server Express
CQRS/MediatR where applicable
Swagger/OpenAPI
```

## Documentation Map

```text
CLAUDE.md
docs/conventions/backend-dotnet-cqrs.md
docs/conventions/database-sqlserver.md
docs/conventions/clean-code.md
.claude/rules/backend.md
.claude/commands/analyze-backend.md
.claude/commands/api-sync.md
```

## Launch Scope

Focus first on:

```text
Customer registration/login
Customer profile
Mango catalog
Mango availability/pricing
Order placement
10 kg / 20 kg crate support
Minimum 10 kg order rule
Admin order management
Manual payment tracking
Courier information management
Customer dashboard APIs
Admin dashboard APIs
Basic reports
Swagger/OpenAPI
```

## Business Rules

- Minimum order quantity is 10 kg.
- Supported crate types are 10 kg and 20 kg.
- Orders can only be placed for available mango types.
- Total quantity and total amount must be calculated server-side.
- Payment must be tracked against each order.
- Customer data must not be visible to other customers.
- Admin/operations users can update order status.
- Reports must respect role-based access.

## Local Development

```bash
dotnet restore
dotnet build
dotnet run
```

Adjust commands according to the actual solution structure.

## Claude Code Usage

Claude must read `CLAUDE.md` before modifying code.

For backend work, Claude must follow:

```text
docs/conventions/backend-dotnet-cqrs.md
docs/conventions/database-sqlserver.md
docs/conventions/clean-code.md
.claude/rules/backend.md
```

## API Sync

`rajmango-api` is the source of truth.

Recommended flow:

```text
rajmango-api Swagger/OpenAPI
        ↓
Generated Angular TypeScript client
        ↓
rajmango-web
```

When API contracts change, mention the required frontend sync step.
