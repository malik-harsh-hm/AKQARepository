# AKQARepository
Repository for AKQA Web Application

APPLICATION ARCHITECTURE

The solution includes following projects - 

AKQA.UI2- Web application project built with  ASP.Net MVC. Has a front end Javascript View that consumes Web API
AKQA.API- Web API project built with ASP.Net Web-API
AKQA.Service-  Webservice project built with WCF
AKQA.xUnit - Unit test project built with xUnit
AKQA.Business- Class Library project for Business layer
AKQA.SharedLogic- Class Library project for Shared interfaces
AKQA.Common- Class Library project containing the WCF Service Factory
FRAMEWORKS USED

Dependency Injection - Have demonstrated use of  Ninject in UI, API and Service layers using constructor injection
Unit Testing - Have used xUnit to write automated unit test cases for API and MVC controllers. 
Mocking- Mocking framework has been implemented by using Moq library
WEB TECHNIQUES DEMONSTRATED

Web API Call using Ajax- The MVC application also has a javascript view, using Ajax to call Web API
CORS- Enabling CORS in Web API layer using NuGet Package (Microsoft.AspNet.WebApi.Cors)
HOW TO RUN

Run an instance of AKQA.Service project
In the browser, http://localhost:64936/ConvertService.svc should open
Run an instance of AKQA.API project. 
Navigate to postman and try calling the API http://localhost:65309/api/person/Convert as per screenshot.
Use following JSON format - { "Name": "Harsh Malik", "DecimalAmount": 10.22 }
Now, Run an instance of  AKQA.UI2 project and navigate to the Index (razor form) or AjaxApp(javascript form) page of Home controller.
