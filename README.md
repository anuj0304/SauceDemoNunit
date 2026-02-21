# 🚀 SauceDemo BDD Automation Framework

## 📌 Overview

This project is a scalable BDD automation framework built using:

- Selenium WebDriver
- C# (.NET)
- SpecFlow (BDD)
- NUnit

The framework follows the Page Object Model (POM) design pattern and clean separation of concerns to ensure maintainability, stability, and scalability.

---

# 🏗 Framework Architecture

## 📁 Project Structure

SauceDemoBDD  
│  
├── Features  
├── Steps  
├── Pages  
├── Support  
├── Config  
├── TestData  
└── README.md  

---

# 📂 Folder Responsibilities

## 🔹 Features

Contains Gherkin feature files written in business-readable format.

Example:

Scenario: Successful purchase of a single product  
Given I login as a standard user  
When I add "Sauce Labs Backpack" to the cart  
And I checkout with valid customer details  
Then I should see the order confirmation page  

These files describe behavior, not implementation.

---

## 🔹 Steps

- Maps Gherkin steps to C# methods
- Calls Page Object methods
- Contains assertions
- Does NOT contain locators

This ensures separation of concerns.

---

## 🔹 Pages (Page Object Model)

Each Page class contains:

- Element locators
- Page-specific interaction methods
- No test logic

Benefits:

- Centralized locator management
- Easy maintenance
- Reduced duplication
- Clean test structure

If a locator changes, it only needs to be updated in the corresponding Page class.

---

## 🔹 Support

### DriverFactory
- Initializes WebDriver
- Configures browser options
- Manages driver lifecycle

### Hooks
- BeforeScenario → Driver setup
- AfterScenario → Screenshot on failure
- Ensures proper cleanup

### WaitHelper
- Centralized explicit wait logic
- Avoids hard-coded sleeps
- Improves test stability

---

# 🧠 Locator Strategy

Preferred approach:

- Stable attributes like `id` or `data-test`
- Avoid index-based or brittle XPath selectors

Example:

By.Id("add-to-cart-sauce-labs-backpack")

Fallback approach:

- Relative XPath based on product name when stable attributes are unavailable

This improves maintainability and reduces flakiness.

---

# ⏳ Wait Strategy

The framework uses explicit waits centralized inside `WaitHelper`.

Why explicit waits?

- Wait for specific conditions (visibility, clickability)
- Reduce flaky failures
- Handle dynamic loading behavior
- More reliable than implicit wait alone

No hard-coded `Thread.Sleep()` is used in production logic.

---

# 📸 Screenshot on Failure

If a test fails:

- Screenshot is automatically captured
- Helps debugging locally and in CI environments

---

# 🚀 How to Run Tests

Restore dependencies:

dotnet restore

Build project:

dotnet build

Execute tests:

dotnet test

---

---

# 📈 Scalability Strategy

To scale this framework for larger test suites:

- Introduce BasePage abstraction
- Implement tag-based execution
- Enable parallel test execution
- Externalize environment configuration
- Add reporting integration

---

# 🤖 AI Usage Disclosure

AI tools were used for structural refinement and documentation improvements.  
All implementation, debugging, and final validation were performed manually.

---

# ✅ Non-Functional Compliance

- Clean separation of concerns
- Centralized locators
- Explicit wait strategy
- Screenshot on failure
- Reusable step definitions
- Scalable project structure

---

# 🎯 Conclusion

This framework demonstrates:

- Strong BDD implementation
- Page Object Model design
- Test stability practices
- Maintainable and scalable architecture