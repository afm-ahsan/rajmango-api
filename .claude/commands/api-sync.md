# Command — API Sync

Use this command when backend API contracts may affect the frontend.

## Goal

Keep `rajmango-api` and `rajmango-web` aligned through Swagger/OpenAPI.

## Rules

- `rajmango-api` is the source of truth.
- Swagger/OpenAPI must reflect actual routes and DTOs.
- Generated Angular clients must not be manually edited.
- Backend DTO changes must be communicated clearly.

## Backend Steps

1. Verify Swagger/OpenAPI is enabled.
2. Verify endpoint routes are correct.
3. Verify request/response DTOs are accurate.
4. Build the backend.
5. Run the API locally if needed.
6. Locate/export Swagger JSON if practical.

## Frontend Impact Report

Always report:

```text
Frontend API client regeneration required: Yes/No
Breaking change: Yes/No
Affected endpoints:
Affected request DTOs:
Affected response DTOs:
Recommended frontend action:
```

Do not modify frontend code from this backend repo unless explicitly allowed.
