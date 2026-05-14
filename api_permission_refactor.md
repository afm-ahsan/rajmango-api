# RajMango API — Permission System Refactor

You are refactoring the RajMango role-permission system.

## Objective

Eliminate double-serialized permission JSON and standardize the authorization system using flat permission keys.

The backend currently stores `Role.PermissionJson` in the database as JSON text, but the API must return strongly typed permission arrays instead of serialized JSON strings.

---

# Current Problem

Current API response pattern:

```json
{
  "permissionJson": "[\"dashboard.admin.view\",\"user.view\"]"
}
```

This causes:

* double serialization
* unnecessary JSON.parse() on frontend
* weak typing
* Swagger/OpenAPI inconsistency
* maintainability issues

---

# Target Architecture

## Database Layer

Keeping JSON text storage in DB is acceptable.

Example DB value:

```json
["dashboard.admin.view","user.view","order.create"]
```

`Role.PermissionJson` may remain:

```csharp
public string PermissionJson { get; set; }
```

inside the entity model.

---

## API Contract

API responses must return strongly typed arrays:

```json
{
  "permissions": [
    "dashboard.admin.view",
    "user.view",
    "order.create"
  ]
}
```

NOT serialized JSON strings.

---

# Permission Standard

Use flat permission keys everywhere.

Examples:

```text
user.view
user.create
role.view
order.create
dashboard.admin.view
mango.type.manage
```

`RajMango.Shared.Permissions` remains the single source of truth.

Do not change existing permission constant names.

---

# Required Refactor Tasks

## 1. Refactor GetAuthUserDto

Replace:

```csharp
public string PermissionJson { get; set; }
```

with:

```csharp
public List<string> Permissions { get; set; } = new();
```

Do not expose serialized JSON permission strings in API contracts anymore.

---

## 2. Refactor GetAuthUserQuery

Current implementation still deserializes old hierarchical permission objects.

Remove old logic using:

* PermissionModel
* FeatureModel
* ActionModel

Current problematic flow:

```csharp
permissions = JsonConvert.DeserializeObject<List<PermissionModel>>(role.PermissionJson);
```

Replace with:

```csharp
permissions = JsonConvert.DeserializeObject<List<string>>(role.PermissionJson);
```

Then return:

```csharp
Permissions = permissions ?? new List<string>()
```

---

## 3. Remove Old Hierarchical Permission Architecture

The following old models are deprecated and must no longer participate in authentication/authorization flow:

* PermissionModel
* FeatureModel
* ActionModel

Do not use:

* Area
* FeatureModels
* ActionModels

for authorization anymore.

---

## 4. Refactor Role Create/Update Flow

Ensure role create/update APIs save flat permission string arrays into `Role.PermissionJson`.

Expected DB format:

```json
["user.view","order.view","order.create"]
```

NOT:

```json
[
  {
    "Area": "Dashboard",
    "FeatureModels": [...]
  }
]
```

---

## 5. Add Backward Compatibility Migration

Existing DB rows may still contain old hierarchical permission JSON.

Implement safe migration/conversion support:

* Detect old permission structure
* Convert into flat permission strings
* Save back in new format

The application must continue working for existing roles.

---

## 6. Seed Data

Ensure:

* `Permissions.AdminPermissions`
* `Permissions.GeneralPermissions`

are stored as flat permission arrays.

Seed data must generate valid `Role.PermissionJson`.

---

## 7. Keep Existing Authorization System

Do NOT modify:

```csharp
[RequirePermission(Permissions.Users.View)]
```

Existing authorization attributes and middleware must continue working unchanged.

---

## 8. Validation Requirements

Verify all of the following:

* Login API returns `permissions: string[]`
* Swagger shows permissions as array
* No JSON.parse requirement remains for frontend
* RequirePermission authorization still works
* Admin role has full access
* General role has restricted access
* Existing menus/pages continue working after frontend integration
* No dependency on old PermissionModel hierarchy remains in auth flow

---

# Important Constraints

## Keep

* RajMango.Shared.Permissions
* Flat permission key architecture
* RequirePermission attributes
* Existing RBAC approach

## Remove Gradually

* PermissionModel
* FeatureModel
* ActionModel
* permissionJson from API DTO contracts

---

# Final Expected Login Response

```json
{
  "userId": 1,
  "email": "admin@rajmango.com",
  "permissions": [
    "dashboard.admin.view",
    "user.view",
    "role.view",
    "order.view",
    "order.create"
  ]
}
```

No serialized JSON strings allowed in API response.
