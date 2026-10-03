# Critique — Procedural Order System

## 1. Parallel Arrays

The program uses many arrays for the same customer data.

For example, customer ID, name, email, city, and VIP status are stored in different arrays.

The arrays depend on the same index to represent one customer.

This can cause problems if one array is changed or reordered.

---

## 2. Global State

The program uses global variables and arrays to store the main data.

Many functions can access and change this data directly.

This makes the data hard to control and can cause unwanted changes.

---

## 3. Using `double` for Money

The program uses `double` for prices and money calculations.

`double` can have small rounding errors with decimal numbers.

This can cause wrong results when calculating prices, discounts, or totals.

---

## 4. Mixing Business Logic with Console Output

Some functions do the work and print messages at the same time.

For example, some validation and order operations use `cout` directly.

This makes the code harder to reuse in another type of application, such as a GUI or web app.

---

## 5. Insufficient Validation

Some input values are not checked correctly.

For example, the program checks the product ID and capacity, but it does not properly check the price or stock.

This allows invalid data, such as a negative price, to enter the system.

---

## 6. Limited Code Reusability

The code is closely connected to its current data and structure.

If the system changes, we may need to change the code in many places.

This makes the code harder to extend and maintain.

---

## 7. Multiple Responsibilities in One Function

Some functions do more than one job.

For example, `printOrder()` calculates the order total and also prints the order.

It would be better to separate the calculation from the printing.

This makes the code easier to maintain and reuse.