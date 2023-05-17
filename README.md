Author: Ian Richards

Version 1.0.0

Licence MIT

A program that takes two inputs and calculates the probability factor based on the calculation selected.

The output log can be found within the Calculate.UI root folder and is called probability_results.csv. This file is generated on the first calculation request and is updated per requst made.

The project is written in C# .Net 6 and requires the .Net 6 SDK/Runtime environment to be installed. You can run this project in either Visual Stuido IDE or smiilar product.

The back end is C# .Net 6 and is a single Core Dynamic Linked Library. This should allow any to implement another front end if required. You need only to reference the DLL to use this functionality.

The front end provided is written using Blazor. This decision was made due to the familiarity with the C# language and similarities to Razor views.

Unit tests can be found for the DLL and for the services in the UI. There are no UI tests nor are there any controller tests as the controller is simplstic in design. There are also no tests around the FileWrapper. This is because I did not want to mock the File class to prove we can save a file.
