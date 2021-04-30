----
category: fabians_mix
published: 2020-10-04
author: Fabian
----

# re-linq: Subquery boundaries after GroupBy, Union, and similar operators?

Working on [RM-4093](https://www.re-motion.org/jira/browse/RM-4093) (`UnionResultOperator` should act as a query source) made me think about the nature of result operators (i.e., query operators operating on the result of a `from`/`where`/`join`/`orderby`/`select` block) that mangle the incoming data so much that it can’t be associated with the original data any more.

For example, consider three queries:

```csharp
(from o in Orders
 select o)
    .Take (4)
    .Any (o2 => o2.OrderDate > DateTime.Now)
```

- The result of the `from`/`select` block is a sequence of Order objects that are directly traceable to the `MainFromClause`: `[o]` (re-linq’s notation for: reference to the query source called "o").
- The result of the Take operator is still a sequence of the same Order objects: `[o]`.
- Therefore, the "o2" in the `Any` operator still refers to the items produced by the `MainFromClause`: `[o].OrderDate > DateTime.Now`.

```csharp
(from o in Orders
 select o)
    .GroupBy (o => o.OrderDate)
    .Any (g => g.Key > DateTime.Now)
```

- As in the first query, the result of the `from`/`select` block is a sequence of items coming from the `MainFromClause`: `[o]`.
- The result of the GroupBy operator is a sequence of `IGrouping<DateTime, Order>` objects which are no longer traceable to the `MainFromClause`, but only to the `GroupResultOperator` (let’s call it "g"): `[g]`.
- Therefore, the "g" in the `Any` operator refers to items produced by the `GroupResultOperator`: `[g].Key > DateTime.Now`.

```csharp
(from o in Orders
 select o)
    .Union (OtherOrders)
    .Any (o2 => o2.OrderDate > DateTime.Now)
```

- As in the first query, the result of the `from`/`select` block is a sequence of items coming from the `MainFromClause`: `[o]`.
- The result of the Union operator is a sequence of Order objects which are, however, no longer traceable to the `MainFromClause`, since they could potentially come from the second query source (`OtherOrders`): `[u]`.
- Therefore, the "u" in the `Any` operator refers to items produced by the `UnionResultOperator`: `[g].Key > DateTime.Now`.

Okay, so far so good. However, the question is how useful it is to have a result operator refer to another result operator coming before it. Back-ends that produce SQL will always have to add a sub-query boundary after such a result operator, because the produced SQL should look something like this:

```sql
SELECT CASE
  WHEN EXISTS(
    SELECT *
    FROM (SELECT * FROM [OrderTable] AS [t0]
          UNION
          SELECT * FROM [OtherOrderTable]) AS [q0]
    WHERE ([q0].[OrderDate] > @1)
    )
  THEN 1
  ELSE 0
  END AS [value]
```

As you can see, the part before the `Any` (which is equivalent to the `EXISTS` clause) needs to be moved into a sub-query – there is a subquery boundary after the `UnionResultOperator`. Therefore, we could change re-linq’s front-end to (always) automatically insert such boundaries before operators such as `Union` and `GroupBy`:

```csharp
(from u in
     (from o in Orders
      select o)
     .Union (OtherOrders)
 select u)
    .Any (u => u.OrderDate > DateTime.Now)
```

The question I’m asking myself is whether there is a good reason for not making this change. Is there any advantage to keeping `GroupBy` and `Union` in the same query as the following operators?

I’d appreciate any input on this on our mailing list: <https://groups.google.com/d/topic/re-motion-users/MgZcKlHAn1g/discussion>.