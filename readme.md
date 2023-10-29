# Google OAuth2 .NET Core Example 

Simple example showing the use of Google's OAuth2 libraries in ASP.NET Core, see [this tutorial](https://developers.google.com/api-client-library/dotnet/guide/aaa_oauth#web-applications-asp.net-core-3). 

Will open up to a page and show a list of files in a user's Google Drive. 

### To run

- Ensure you have a [Google Cloud Project](https://cloud.google.com/resource-manager/docs/creating-managing-projects) with [Drive Api enabled](https://developers.google.com/identity/protocols/oauth2/web-server#enable-apis).
- Create some [credentials](https://developers.google.com/identity/protocols/oauth2/web-server#creatingcred):
  - Set the redirect URL to `http://localhost:5056/signin-oidc`.
  - When created, store the client ID by opening a terminal at the project root and using `dotnet user-secrets set "Authentication:Google:ClientId" "[your-client-id]"`
  - Repeat the same for the client secret with `dotnet user-secrets set "Authentication:Google:ClientSecret" "[your-client-secret]"`
- Run with `dotnet run`.
- Navigate to `http://localhost:5056` and sign in to your account. 

