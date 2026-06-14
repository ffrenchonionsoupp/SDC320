# SDC320
# The Pantry Fairy

## Project Description
The Pantry Fairy is a console-based C# application designed to help users organize recipes, ingredients, and pantry inventory. The system allows users to create, view, update, and delete recipes and grocery items while maintaining persistent storage through a SQL-based database. The project demonstrates strong use of OOP principles, database integration, and clean console output formatting.

---

## Project Tasks
- **Task 1: Design the application**
  - Define OOP architecture (interfaces, abstract classes, inheritance)
  - Create class diagrams and data models

- **Task 2: Implement core domain classes**
  - `FoodItem`, `Ingredient`, `GroceryItem`, `Recipe`, and derived recipe types

- **Task 3: Build the Pantry and Recipe systems**
  - Add/remove ingredients  
  - Add/remove grocery items  
  - Filter and categorize pantry items

- **Task 4: Implement database integration**
  - Create SQL tables for Recipes, Ingredients, GroceryItems  
  - Implement CRUD operations in `DatabaseService`

- **Task 5: Build the user interface**
  - Console menus for recipes and pantry management  
  - Consistent output using `IPrintable`

- **Task 6: Test the application**
  - Validate CRUD operations  
  - Test menu navigation and output formatting

- **Task 7: Document the project**
  - Write project summary  
  - Create README.md  
  - Provide requirement → design → implementation mapping

---

## Skills Learned
- Object-oriented programming (abstraction, inheritance, polymorphism, composition)
- C# class design and modular architecture
- SQL database design and CRUD operations
- Separation of concerns (UI, business logic, data access)
- Console application design and formatting
- Debugging multi-class systems
- Writing technical documentation

---

## Language & Technologies Used
- **C# (.NET)** — core application logic  
- **SQL (SQLite or similar)** — persistent storage  
- **LINQ & Collections** — data manipulation  
- **Console UI** — user interaction  

---

## Development Process
- Iterative development with incremental testing  
- OOP-first design approach  
- Database schema created before implementation  
- Continuous refinement of class structure and output formatting  

---

## Notes
- Ensure the database is initialized before first use  
- All SQL queries use parameterized commands  
- Recipe types can be extended by adding new derived classes  


