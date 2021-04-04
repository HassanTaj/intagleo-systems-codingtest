# Intagleo Systems Coding Test

#### Details
> Cantidate : Hassan Taj  
> Email :  hassantaj01@gmail.com  

Assignment Is Deployed At ["View Assignment"](http://intagleo-systems-codingtest.azurewebsites.net/)

### How to make it work on the first go ?

1. Clone the repository
2. Clean the solution
3. Rebuild the solution
4. Change SQL Server Connection String under  CodingAssignment > Web.Config  > ConnectionStrings section
5. Restore Nuget packages
6. Required Dependencies (in case one of them is missing from packages add) 
     1.  Ninject
     2.  Ninject.Web.Common
     3.  Ninject.Web.Common.WebHost
     4.  Ninject.Web.MVC
     5.  Ninject.Web.WebApi
     6.  Ninject.Web.WebApi.WebHost
     7.  Entity Framework 6
7. Open Project Manager Console and run update-database command.
8. Wait for migrations to be applied and seed method run complition
9. Press F5 And enjoy.