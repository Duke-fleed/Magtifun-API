# Magtifun-API
C# Portable class library for Magtifun SMS service

How to install from Nuget:
PM> Install-Package MagtifunApi.dll 

How to use:
var sender = new MagtifunHelper("Account Number", "Account password");
sender.SendSMS("Recipient", "Text to send");

Additional features documented in Test project.
