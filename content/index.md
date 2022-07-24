# Overview

## re-motion in four sentences

**Open Source Framework:** re-motion is a development framework for .NET under the LPGL License.

**Domain Driven Design:** Concentrate on business logic, let the framework take care of implementation details.

**Maintainable:** Separate Domain, UI and (optionally) application layers to keep modifications simple.

**Extensible:** Extend the business object model and UI of any re-motion-based product without touching the product’s source code.

## Components Overview

**re‑store** manages the implementation details for persistence. re-store maps properties of domain classes to data base tables. Developers can decorate domain classes with class and method attributes to alter the default behavior. re‑store features powerful in-memory transactions with atomic sub-transactions.

**re‑form** manages the implementation details for data entry. Domain objects are bound to web controls and forms. re-form includes a rich custom control set from basic data types to complex list controls with inline editing and a powerful mechanism to call other re-form pages like a subroutine.

## Technology overview

re-motion also consists of two powerful technologies. For information on them visit their CodePlex Pages.

* [re-mix: Mixins for C# and VB.NET](https://github.com/re-motion/Remix)
* [re-linq: Generic LINQ provider](https://github.com/re-motion/Relinq)
