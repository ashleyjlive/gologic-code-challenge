# Vending Machine Technical Task

The vending machine in this solution is a simplified version of what one would expect in the real world. It provides the basic functionality of the finite-state machine behaviour a vending machine would implement.

Fundamentally, a "vending machine" has no concept of a user, it simply accepts money, dispenses a selected product (if there is enough entered in the money box) and returns any existing change if requested.
The "user" aggregate exists for the primary purpose of simulating a user in real life.

# Running

To run the application, simply execute `dotnet run` in the `VendingMachine.Presentation` directory and the application should compile and run.

# Known Issues / Improvements To Be Made

## Database Layer

The database layer in this example is very basic as it opts to rely on JSON files to capture the current state. 
If this was a "real" vending machine, a suggestion would be to use a lightweight locally hosted DB, such as a SQLite database. 
Scalability would not need to be a factor in this scenario as a vending machine has a single user and only a few operations, thus a SQLite db would be perfect for this.

## User Interface

The user interface could do with some signficant design changes in order to be more accessible to users who have disabilities (and to also look more visually appealing).

## Implementing a "Unit Of Work" (Transactional Based Commands)

The unit of work pattern is used for scenarios where changes to multiple aggregates must be done transactionally. 
This is especially useful for when funds are transferred between the user and the vending machine. If one "commit" works and another fails, then the whole operation should rollback. This prevents information loss and incorrect behaviour.

## More tests

Adding more tests across the project. These would include:
- Controller Tests
- UI Tests (Selenium as an example)
- API Tests