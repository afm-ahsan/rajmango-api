# Backend Rule — RajMango API

You are working in `rajmango-api` only.

## Must Follow

Read before backend work:

```text
CLAUDE.md
README.md
docs/conventions/backend-dotnet-cqrs.md
docs/conventions/database-sqlserver.md
docs/conventions/clean-code.md
```

## Guardrails

- Do not modify frontend code.
- Do not upgrade .NET 8.
- Do not replace SQL Server with PostgreSQL.
- Do not introduce React/Angular implementation details.
- Do not create empty placeholder files.
- Do not delete code without explaining why.
- Do not hardcode secrets.
- Do not manually edit frontend generated clients.

## Backend Priorities

Focus on:

```text
Authentication/profile
Mango catalog/availability
Order placement
Crate validation
Payment tracking
Courier management
Dashboards
Basic reports
Swagger/OpenAPI
```

## Required Behavior

Before coding:

1. Inspect current solution structure.
2. Identify existing patterns.
3. Propose a short plan.
4. Make small changes only.
5. Summarize changed files and validation steps.

## API Contract

The backend OpenAPI contract is the source of truth for `rajmango-web`.

When API contracts change, explicitly state:

```text
Frontend API client regeneration required: Yes/No
Breaking change: Yes/No
Affected endpoints:
Affected DTOs:
```
