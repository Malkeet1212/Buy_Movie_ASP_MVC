1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
 Update-Database   -Context Buy_Movies_MVCIdentityContext



5. On the console execute the following command

Update-Database  -Context Buy_Movies_MVCDatabaseContext



6. After migration is successful Run the project 

7 if you click on Movies/Customers/MovieTransactions this will redirect you to ASP .net identity login page login from the following credentials

User : sysadmin@movies.com
Password: 1qaz2wsX@

8. Also you can register your own user via the Register link on menubar and login with that user.
