1) Change connection string at MeetupApi-appsetings.json-"ConnectionStrings"-"sqlConnection" to your connection string.
2) Apply update-database
3) Use api/authentication for registration. Available roles: "user" - GET methods only, "admin" - all methods.
4) Use api/authentication/login to get bearer token. Use token to authorize.
