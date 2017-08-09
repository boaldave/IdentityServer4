# IdentityServer4-Fork

## Important Notices:
!!! THIS REPO IS JUST STARTING AND FOR NOW SHOULD BE CONSIDERED WORK IN PROGRESS!!!
I will remove this notice when the code is working.  All of the work I am doing in this repository is being done in the "DaveDemo" Branch.  Please switch to the "DaveDemo" Branch to see the exciting work-in-progress!

## Acknowledgements
!!! THIS REPO IS DEPENDENT on other github repositories for much of the source code:
https://github.com/IdentityServer/IdentityServer4 - IdentityServer4 Authentication ASP.Net Core 2 WebApi and ASP.Net Core 2 MVC UI for "Login" and "Claims Consent".
https://github.com/jmurphzyo/Angular2OidcClient - ASP.Net Core 2 Angular.io UI Client
https://github.not/WebApiResource - ASP.Net Core 2 WebApi Service that will be called by both ASP.Net Core 2 MVC UI and ASP.Net WebForms UI.

## Purpose of this repo:
This demo will allow you to see project differences, via repo history, between a WebForms Application with no Authentication, and one with Authentication provided by Identity Server 4. The theory is, if you already know how to remove an existing Membership Provider from your WebForms app (ie., no Authentication), then by examining the before and after project differences, you should be able to see how to replace it with and ASP.Net Identity 4 and Identity Server 4 SSO solution.

It will also show you how to modify the default Identity Server 4 application to limit  Authorization Flows to only those flows that are suitable for secure connections from WebForms, ASP.Net Core (MVC and WebApi), and Angular Clients.

My contribution in this repository is as follows (please see "Release Notes.md" below for more detail):
DONE:
1. Initial Preparation: Create a single Authentication Server application that will host both the Authentication WebApi and the Login, Consent, Forgot Password, and Revoke Access UI. It will be built by forking the https://github.com/IdentityServer/IdentityServer4 and creating a branch called "DaveDemo" that branches from:
orig/Release:
- Date: 7/30/2017 5:20:47 AM 
- Commit hash:ac4b6cacdef697161fad87bca7d957d0e1ceb8c2).
TODO:
2. Remove some IdentityServer4 Authentication Schemes that are not necessary for this project. 
3. Create a "WebForms project" from scratch that will connect to the IdentityServer4 Authorization Server via OWIN Middleware. 
4. Create an Angular UI application that will connect to the same IdentityServer4 Authorization Server. This app has an iFrame that will host the WebForms UI, which will allow the migration of an existing WebForms application to Angular over time. It will be built by extending the https://github.com/jmurphzyo/Angular2OidcClient project.
5. Create ASP.Net Core 2 WebApi Service that will be called by both ASP.Net Core 2 MVC UI and ASP.Net WebForms UI, that will demononstrate how it can examine and validate an access token (or alternatively request token validation from the Authentication Server). It will be built by extending the https://github.not/WebApiResource project.
6. Create a Xamarin UI Application sharing the same Authentication Server.
7. Enable demonstratration of Single Sign On (SSO) for all clients with Refresh Token and Token Revocation features.
8. Convert InMemory Services to EntityFramework Services.
9. Remove the Database Seeding into a separate Console App.

## To start IdentityServer4 Authentication Server
This enables Authorization WebApi calls and MVC UI's for "Login" and "Claims Consent".

Clone this IdentityServer4 repo.
Checkout the DaveDemo Branch
Rebuild the IdentityServer.sln
Set the "Host" project as Startup Project
Here is an optional step if you want to override defaults port:
```csharp
  var host = new WebHostBuilder()
          .UseKestrel()
          .UseUrls("http://localhost:5000")
          ....etc
```
Start the site:
```cmd
c:\> cd C:\YourSourceFolder\IdentityServer4
C:\YourSourceFolder\IdentityServer4> cd src\host
C:\YourSourceFolder\IdentityServer4> dotnet run
  Hosting environment: Production
  Content root path: C:\Github\IdentityServer4\src\Host
  Now listening on: http://localhost:5000
  Application started. Press Ctrl+C to shut down.
```

## To Login:
http://localhost:5000/account/login

## Comments:
Once you realize that Identity Server 4 can be implemented as one or more applications, you may decide to split "Identity Server 4" into the 3 individual applications and host them on separate servers. For the purpose of this demo, the 3 applications that are intended to be deployed as one Authentication Server are: 
- ASP.Net Core MVC Login UI
- ASP.Net Core WebApi Authorization Services
- ASP.Net Core WebApi Token Services

