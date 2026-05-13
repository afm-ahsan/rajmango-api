# API Authorization Refactor Prompt

You are a senior solution architect and enterprise backend engineer.

Your task is to refactor the current authorization system into a production-grade, reusable RBAC + Permission-Based Authorization architecture.

## Core Principle

User → Role → Permission → Resource/Action

Rules:
- Roles are ONLY for grouping permissions.
- Backend authorization MUST check permissions, NOT role names.
- Database remains the source of truth.
- Redis/cache must never serve stale permissions.
- Keep the system modular and reusable across all applications.

---

# Permission Naming Convention

Use:

module.resource.action

Examples:

- order.view
- order.create
- order.update
- payment.receive
- inventory.adjust
- report.sales.view

Never hardcode raw permission strings repeatedly.

---

# Required Database Architecture

Use normalized RBAC + Permission design.

## Required Tables

### Roles

- Id
- Name
- Description
- IsSystemRole
- IsActive
- CreatedAt
- CreatedBy
- UpdatedAt
- UpdatedBy

### Permissions

- Id
- Name (UNIQUE)
- Module
- Description
- IsActive
- CreatedAt
- CreatedBy
- UpdatedAt
- UpdatedBy

### UserRoles

- UserId
- RoleId

Unique:
(UserId, RoleId)

### RolePermissions

- RoleId
- PermissionId

Unique:
(RoleId, PermissionId)

### Optional: UserPermissions

- UserId
- PermissionId
- IsGranted

Purpose:
Future override support.

---

# EF Core Expectations

Use Fluent API configuration.

Example:

```csharp
builder.HasIndex(x => x.Name)
    .IsUnique();

builder.HasMany(x => x.RolePermissions)
    .WithOne(x => x.Role)
    .HasForeignKey(x => x.RoleId)
    .OnDelete(DeleteBehavior.Cascade);
```

Avoid lazy loading dependency.

Respect existing BaseEntity/AuditableEntity conventions.

---

# Refactor Requirements

## Step 1 — Analyze Existing System

Find and refactor all:

- [Authorize(Roles="...")]
- User.IsInRole(...)
- role == "Admin"
- switch(role)
- hardcoded role checks

Analyze:
- Existing JWT claims
- Existing Redis caching
- Existing middleware
- Existing policies

---

## Step 2 — Create Permission Constants

Example:

```csharp
public static class Permissions
{
    public static class Orders
    {
        public const string View = "order.view";
        public const string Create = "order.create";
        public const string Update = "order.update";
        public const string Delete = "order.delete";
    }
}
```

This becomes the single source of truth.

---

## Step 3 — Implement Permission Authorization

Implement:

- PermissionRequirement
- PermissionAuthorizationHandler
- RequirePermissionAttribute
- CurrentUserService
- PermissionResolverService
- PermissionCacheService

Expected usage:

```csharp
[Authorize]
[RequirePermission(Permissions.Orders.Create)]
public async Task<IActionResult> CreateOrder(...)
{
}
```

---

# JWT & Claims

JWT should include:

- UserId
- Username
- TenantId if applicable
- Role names if needed
- Optional permission version/cache stamp

Do NOT place massive permission lists into JWT.

Prefer resolving permissions server-side with Redis caching.

---

# Redis Cache Requirements

Cache key:

user-permissions:{tenantId}:{userId}

Invalidate cache when:

- role updated
- permission updated
- role-permission mapping changed
- user-role mapping changed
- user permission override changed

If Redis fails:
- fallback to database
- application must continue working

---

# SuperAdmin Rule

Use:

SuperAdmin

Implement safe bypass:

```csharp
if (currentUser.IsSuperAdmin)
{
    return true;
}
```

Still log sensitive operations.

---

# Migration Requirements

- Preserve existing users
- Preserve authentication flow
- Seed default permissions
- Seed role-permission mappings
- Avoid destructive migration unless absolutely necessary

---

# Testing Requirements

Backend tests:

- permission success
- permission denied
- unauthorized access
- SuperAdmin bypass
- Redis invalidation
- DB fallback when Redis unavailable

---

# Logging & Auditing

Log:
- unauthorized access attempts
- permission changes
- role changes
- user-role changes

Use structured logging.

---

# Production Readiness

Requirements:

- clean architecture
- reusable services
- strongly typed DTOs
- centralized constants
- SOLID principles
- async/await properly
- cancellation token support
- no magic strings
- proper exception handling
- production-safe caching

---

# Deliverables

Provide:

1. Database/entity changes
2. EF migrations
3. Backend authorization refactor
4. Redis cache implementation
5. Seed data
6. Tests
7. Summary of changed files
8. Verification checklist

---

# Execution Rule

Proceed incrementally.

After every major step:
- build solution
- run tests
- verify application still works

Keep the application usable throughout the refactor process.
