# GymTrackerApp
How to run this app on your local:
1. Download the Code
Click the green "<> Code" button at the top of this page and select Download ZIP. Extract the folder to your computer.
2. Open the Project
Go into the folder and double-click the GymTrackerApp.sln file. This will automatically open the project in Visual Studio 2022.
3. Check the Database Connection
Before running the app, make sure it knows where your local SQL server is:
Open the appsettings.json file (located inside the GymApp.Web project).
Find the DefaultConnection line.
Change the Server= part to match your local SQL server (for example, Server=(localdb)\mssqllocaldb or Server=.\SQLEXPRESS).
4. Build the Database (1-Click)
Since this app uses a database to store workouts, we need to generate it on your machine:
In Visual Studio, go to the top menu and click: View > Other Windows > Package Manager Console.
Look for the "Default project" dropdown in that console and make sure GymApp.Data is selected.
Type this exact command and hit Enter:
Update-Database
5. Hit Play!
You are good to go! Just hit start and enjoy the app!!
