## Project 3 | ToDo List Management App with Minimal API
### Project Description
A Fullstack application for managing tasks, developed using Minimal API in .NET. The project includes the development of a Minimal API server, a React client application, and integration with a MySQL database. The application enables users to create, edit, and manage a personal task list.

### Technologies Used
**Server-side:** .NET Minimal API
**Database:** MySQL
**Client-side:** React
**Development Tools:** Entity Framework Core, Dotnet CLI, Visual Studio, Visual Studio Code, Axios
### Key Features
**Task Creation:** Adding new tasks to the list.
**Task Update:** Editing details of existing tasks.
**Task Deletion:** Removing tasks from the list.
**Task Retrieval:** Displaying the list of all tasks.
### Installation and Running
Clone the project:
```bash
git clone https://github.com/talyaAmar/ToDoApi
```

### Server-side (Minimal API)
1. Database Setup:
   - Install MySQL and MySQL Workbench.
   - Create a table named Items with the fields Id, Name, and IsComplete.
   - Configure the Connection String in the appsettings.json file.
2. Run the server:
```bash
dotnet watch run
```


### Client-side (React)
1. Install dependencies:
```bash
npm install
```


2. Configure API address:
Update the route in service.js to your API address.
3. Run the client:
```bash
npm start
```
### Additional Notes
- The application uses Entity Framework Core to access the database.
- The API is configured with CORS to allow requests from the client application.
- The API includes Swagger for documentation and testing of endpoints.
- Axios is used to make HTTP requests from the client application.




-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------



### פרויקט 3 | אפליקציית ניהול משימות ב-Minimal API
### תיאור הפרויקט
אפליקציית Fullstack לניהול משימות, המפותחת באמצעות Minimal API ב-.NET. הפרויקט כולל פיתוח של שרת API ב-Minimal API, אפליקציית לקוח ב-React ואינטגרציה עם מסד נתונים MySQL. האפליקציה מאפשרת למשתמשים ליצור, לערוך, ולנהל רשימת משימות אישית.

### טכנולוגיות בשימוש
**צד שרת:** .NET Minimal API
**מסד נתונים:** MySQL
**צד לקוח:** React
**כלי פיתוח:** Entity Framework Core, Dotnet CLI,Visual Studio, Visual Studio Code, Axios
### תכונות עיקריות
**יצירת משימות:** הוספת משימות חדשות לרשימה.
**עדכון משימות:** עריכת פרטי משימות קיימות.
**מחיקת משימות:** הסרת משימות מהרשימה.
**שליפת משימות:** הצגת רשימת כל המשימות.
### התקנה והרצה
שיבוט הפרויקט:
```bash
git clone https://github.com/talyaAmar/ToDoApi
```


צד שרת (Minimal API)
1. הגדרת מסד נתונים:
   - התקינו MySQL ו-MySQL Workbench.
   - צרו טבלה בשם Items עם השדות Id, Name, ו-IsComplete.
   - הגדירו את Connection String בקובץ appsettings.json.
2. הרצת השרת:
```bash
dotnet watch run
```


### צד לקוח (React)
1. התקנת תלויות:

```bash
npm install
```
2. הגדרת כתובת API:
  עדכנו את ה-route ב-service.js לכתובת ה-API שלכם.
4. הרצת הלקוח:
```bash
npm start
```

### הערות נוספות
- האפליקציה משתמשת ב-Entity Framework Core לגישה למסד הנתונים.
- ה-API מוגדר עם CORS כדי לאפשר קריאות מאפליקציית הלקוח.
- ה-API כולל Swagger לתיעוד וניסיון של נקודות הקצה.
- נעשה שימוש ב-Axios לביצוע קריאות HTTP מאפליקציית הלקוח.
