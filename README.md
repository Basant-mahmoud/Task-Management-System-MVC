# Task Management System (MVC)

A task management system built using ASP.NET MVC. It helps teams organize their work, manage projects and tasks, assign team members, and track progress. The system supports notifications and activity logs to ensure effective collaboration.

---

## 📌 Features

- Create and manage projects.
- Assign tasks to users and track their status (ToDo, InProgress, Done).
- Add comments and file attachments to tasks.
- Organize teams and link them to projects.
- Log user activities (Activity Logs).
- Notify users via a built-in notification system.
- Use **DTOs** for clean data transfer between layers.
- Use **AutoMapper** to map between models and DTOs.

---

## 🧰 Technologies Used

- **ASP.NET MVC 5**
- **C#**
- **Entity Framework**
- **SQL Server**
- **AutoMapper**
- **DTO (Data Transfer Objects)**
- **DevExpress WinForms** (for UI)
- **Layered Architecture**

---

## 🧱 Project Entities

### 👤 User
Users can create tasks, get assigned to tasks, and receive notifications.

### 📂 Project
- Contains title, description, start/end dates, and status.
- Each project has many tasks, team members, and linked teams.

### 📋 Task
- Includes title, description, priority, status, and due date.
- Linked to a project, the creator, and the assigned user.
- Can contain comments and file attachments.

### 💬 TaskComment
- Linked to a task and the user who made the comment.

### 📎 TaskAttachment
- Stores task-related files (you can extend this later).

### 👥 Team / ProjectTeam / TeamMember
- Organizes team structure and associates members with projects.

### 🔔 Notification
- Stores messages, read status, creation time, and email-sent status.

### 📝 ActivityLog
- Records actions taken by users and when they occurred.

---

## 📦 Project Structure

- `Models`: Contains database entities.
- `DTOs`: Used for transferring data safely between layers.
- `Controllers`: Contains logic for handling user requests.
- `Services`: (If implemented) Business logic layer.
- `Views`: User interface pages (Razor).
- `AutoMapper Profiles`: Configuration for DTO-model mappings.
