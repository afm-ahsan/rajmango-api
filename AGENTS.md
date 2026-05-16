# AGENTS.md — RajMango API

You are working inside the **RajMango backend repository** only.

## Repository Scope

```text
rajmango-api
```

This repo owns:

- Backend API
- Domain/application logic
- EF Core entities and migrations
- SQL Server database changes
- Swagger/OpenAPI contract
- Backend tests
- API contract stability for the frontend

Do **not** modify frontend code from this repo.

---

## Current Active Stack

```text
.NET 8
ASP.NET Core Web API
Entity Framework Core
SQL Server Express
CQRS/MediatR where applicable
Swagger/OpenAPI
```

Do not introduce .NET 10, PostgreSQL, React, Angular upgrade work, or unrelated future-stack changes into this repository unless explicitly requested.

---

## Read First

Before making backend changes, read:

```text
README.md
docs/conventions/backend-dotnet-cqrs.md
docs/conventions/database-sqlserver.md
docs/conventions/clean-code.md
.Codex/rules/backend.md
```

If a BRD exists in this repo, read it before planning business features.

---

## Launch-First Backend Priorities

Focus only on launch-critical RajMango flows:

1. Customer registration/login/profile
2. Mango catalog and availability
3. Order placement
4. Crate rules: 10 kg and 20 kg, minimum order 10 kg
5. Manual payment tracking
6. Courier provider/station management
7. Customer dashboard APIs
8. Admin dashboard APIs
9. Basic reports
10. Swagger/OpenAPI readiness for frontend API sync

Defer unless already implemented:

```text
Full bKash payment gateway
Advanced Google Maps distance calculation
Chatbot/FAQ
Marketplace/vendor comparison
Mobile app
Advanced AI analytics
```

---

## Backend Working Rules

Always:

- Inspect existing structure before generating files.
- Preserve current architecture unless a small improvement is clearly safe.
- Keep controllers thin.
- Put business rules in application/domain logic.
- Use DTOs at API boundaries.
- Validate important business rules server-side.
- Use EF Core migrations for schema changes.
- Explain migration impact before changing schema.
- Keep Swagger/OpenAPI accurate.
- Keep changes small and reviewable.

Never:

- Rewrite large areas without approval.
- Expose EF entities directly from APIs.
- Hardcode secrets or connection strings.
- Delete existing code without explaining why.
- Create empty placeholder files.
- Mix unrelated changes in one task.
- Manually edit generated frontend API clients.

---

## API Sync Rule

`rajmango-api` is the source of truth for the API contract.

When routes, request DTOs, response DTOs, or status enums change:

1. Update Swagger/OpenAPI output.
2. Keep DTO names stable where possible.
3. Mention frontend impact clearly.
4. Document whether `rajmango-web` needs API client regeneration.

---

## Required Response Format

After each task, respond with:

```text
Completed:
Changed files:
Validation:
Risks:
Next:
```
