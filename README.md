# Magtifun-API
C# Portable class library for Magtifun SMS service

How to install from Nuget:
PM> Install-Package MagtifunAPI 

##How to use:
###Constructor:
var helper = new MagtifunHelper("Account Number", "Account password");

###Sending message:
sender.SendSMS("Recipient", "Text to send");

###Getting remaining messages:
sender.GetRemainingMessages();

##Getting contacts list:
helper.GetContactsList();

###Adding new contact:
helper.AddNewContact(firstname, mobilenumber, [*other optional parameters*])

All features documented in Test project.
