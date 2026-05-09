# Command — Analyze Backend

Use this command when starting backend work.

## Goal

Analyze `rajmango-api` without changing application code.

## Steps

1. Read:
   - `CLAUDE.md`
   - `README.md`
   - `docs/conventions/backend-dotnet-cqrs.md`
   - `docs/conventions/database-sqlserver.md`
   - `docs/conventions/clean-code.md`
   - `.claude/rules/backend.md`

2. Inspect:
   - solution/project structure
   - controllers/endpoints
   - CQRS folders
   - entities and DbContext
   - migrations
   - authentication/authorization
   - Swagger/OpenAPI setup
   - tests if available

3. Produce:
   - current backend architecture summary
   - launch-critical gaps
   - technical risks
   - database risks
   - security risks
   - API sync readiness
   - prioritized execution plan

## Output Format

```text
Backend Summary:
Launch Gaps:
Security Risks:
Database Risks:
API Sync Readiness:
Critical Tasks:
Important Tasks:
Nice-to-have:
Recommended Next Step:
```

Do not modify source code during this command.
