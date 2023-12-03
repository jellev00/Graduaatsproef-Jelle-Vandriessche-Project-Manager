CREATE TABLE "Users"(
    "User_ID" INT NOT NULL,
    "First_Name" VARCHAR(100) NOT NULL,
    "Last_Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(500) NOT NULL,
    "Password" VARCHAR(20) NOT NULL
);
ALTER TABLE
    "Users" ADD CONSTRAINT "users_user_id_primary" PRIMARY KEY("User_ID");
CREATE TABLE "Person"."Task"(
    "Task_ID" INT NOT NULL,
    "User_ID" INT NOT NULL,
    "Task_Name" BIGINT NOT NULL identity PRIMARY KEY,
    "Task_Discription" VARCHAR(200) NOT NULL,
    "Color" VARCHAR(20) NOT NULL
);
ALTER TABLE
    "Person"."Task" ADD CONSTRAINT "person_task_task_id_primary" PRIMARY KEY("Task_ID");
CREATE TABLE "Projects"(
    "Project_ID" INT NOT NULL,
    "User_ID" INT NOT NULL,
    "Name" VARCHAR(100) NOT NULL,
    "Discription" VARCHAR(300) NOT NULL,
    "Color" VARCHAR(20) NOT NULL
);
ALTER TABLE
    "Projects" ADD CONSTRAINT "projects_project_id_primary" PRIMARY KEY("Project_ID");
CREATE TABLE "Project"."Tasks"(
    "Project_Task_ID" INT NOT NULL,
    "Project_ID" INT NOT NULL,
    "Task_Name" VARCHAR(100) NOT NULL,
    "Task_Discription" VARCHAR(200) NOT NULL,
    "Color" VARCHAR(20) NOT NULL
);
ALTER TABLE
    "Project"."Tasks" ADD CONSTRAINT "project_tasks_project_task_id_primary" PRIMARY KEY("Project_Task_ID");
CREATE TABLE "Project"."Calander"(
    "Project_Calander_ID" INT NOT NULL,
    "Project_ID" INT NOT NULL,
    "Name" VARCHAR(100) NOT NULL,
    "Discription" VARCHAR(300) NOT NULL,
    "Date" DATETIME NOT NULL
);
ALTER TABLE
    "Project"."Calander" ADD CONSTRAINT "project_calander_project_calander_id_primary" PRIMARY KEY("Project_Calander_ID");
ALTER TABLE
    "Project"."Tasks" ADD CONSTRAINT "project_tasks_project_id_foreign" FOREIGN KEY("Project_ID") REFERENCES "Projects"("Project_ID");
ALTER TABLE
    "Person"."Task" ADD CONSTRAINT "person_task_user_id_foreign" FOREIGN KEY("User_ID") REFERENCES "Users"("User_ID");
ALTER TABLE
    "Project"."Calander" ADD CONSTRAINT "project_calander_project_id_foreign" FOREIGN KEY("Project_ID") REFERENCES "Projects"("Project_ID");
ALTER TABLE
    "Projects" ADD CONSTRAINT "projects_user_id_foreign" FOREIGN KEY("User_ID") REFERENCES "Users"("User_ID");