# marcore 6

marIntegraal API on Microsoft dotnet 6.x

## Publishing

dotnet publish -c Release

## Check and update dotnet Entity Framework tool

dotnet tool list -g
dotnet tool update -g dotnet-ef --version 6.0.6

### Some EF commands

dotnet ef migrations add InitAllTables
dotnet ef database update

dotnet ef database drop
dotnet ef migrations remove

## appsettings.json

You have to add appsettings.json with your secret settings

```json
{
  "AppSettings": {
    "Token": "??"
  },
  "ConnectionStrings": {
    "marDB": "Data Source=??"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "CloudinarySettings": {
    "CloudName": "??",
    "ApiKey": "??",
    "ApiSecret": "??"
  },
  "MailSettings": {
    "SendMailAddress": "exampleadmin@yourmaildomain",
    "SendMailUrl": "yourmaildomain",
    "SendMailPassword": "??",
    "AdminCCMailAddress": "yourCCmail",
    "AdminCCFullName": "yourorganisationname",
    "MailGuid": "your guid key"
  }
}
```

## WebDAVModule

On some Microsoft IIS hosting services WebDAVModule should be disabled

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <modules>
        <remove name="WebDAVModule" />
      </modules>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath=".\marcore.api.exe" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
```

## Playing in vscode terminal

### Old time MSDOS/PSDOS/CPM

In terminal type cmd + enter
color 2 + enter
