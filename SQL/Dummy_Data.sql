-- Users table
INSERT INTO "Users" ("User_ID", "First_Name", "Last_Name", "Email", "Password")
VALUES
  (1, 'John', 'Doe', 'john.doe@example.com', 'password123'),
  (2, 'Jane', 'Smith', 'jane.smith@example.com', 'securepass'),
  (3, 'Alice', 'Johnson', 'alice.johnson@example.com', 'pass123');

-- Person.Task table
INSERT INTO "Person"."Task" ("Task_ID", "User_ID", "Task_Name", "Task_Discription", "Color")
VALUES
  (1, 1, 'Task 1', 'Description of Task 1', 'Blue'),
  (2, 2, 'Task 2', 'Description of Task 2', 'Red'),
  (3, 3, 'Task 3', 'Description of Task 3', 'Green');

-- Projects table
INSERT INTO "Projects" ("Project_ID", "User_ID", "Name", "Discription", "Color")
VALUES
  (1, 1, 'Project A', 'Description of Project A', 'Yellow'),
  (2, 2, 'Project B', 'Description of Project B', 'Purple'),
  (3, 3, 'Project C', 'Description of Project C', 'Orange');

-- Project.Tasks table
INSERT INTO "Project"."Tasks" ("Project_Task_ID", "Project_ID", "Task_Name", "Task_Discription", "Color")
VALUES
  (1, 1, 'Task A', 'Description of Task A in Project A', 'Green'),
  (2, 2, 'Task B', 'Description of Task B in Project B', 'Blue'),
  (3, 3, 'Task C', 'Description of Task C in Project C', 'Red');

-- Project.Calander table
INSERT INTO "Project"."Calander" ("Project_Calander_ID", "Project_ID", "Name", "Discription", "Date")
VALUES
  (1, 1, 'Event X', 'Description of Event X', '2023-12-01 10:00:00'),
  (2, 2, 'Event Y', 'Description of Event Y', '2023-12-05 15:30:00'),
  (3, 3, 'Event Z', 'Description of Event Z', '2023-12-10 12:00:00');
