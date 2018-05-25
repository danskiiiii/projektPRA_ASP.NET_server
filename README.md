## projektPRA_ASP.NET_server ##
This server app is part of university project for a programming class "PRAcownia Programowania". 

General idea was to create a client with CRUD functionality, 
communicating via REST API with a server connected to external database.

More detailed info about requirements http://tzietkiewicz.home.amu.edu.pl/?p=85

Link to the desktop client app https://github.com/danskiiiii/projektPRA_WPF_client


### How to run the server ###
You will need Visual Studio. After cloning the repository you'll have to create a local database. 
Execute Update-Database command in the Package Manager Console. 
Connection string is configuerd to create database files locally in App_Data folder.

Originally the server was connected to my university's MS SQL Server, but once the semester ended admins purged my database.
If you want connect to external database server, you'll have to configure your connection string in Web.config.
