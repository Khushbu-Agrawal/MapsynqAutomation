# MapsynqAutomation

Automation of web application using Selenium WebDriver and C# language. This project performs automation of the www.mapsynq.com site using POM based model and configurable approach to run various test cases.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See detailed notes below to setup project and running automation.

### Prerequisites

```
* Visual Studio 2013
* Windows 10 OS
```

### Installing

```
* Clone or download this project
* Build project in VS2013
* Configure TestData (more details below)
* Add MSTest.exe to your environment variable
```

### Configurations

You need to setup few environment variables to run the test. It's designed to be able to easily configure test data and store it individually, so that test data management is easy. Just configure following environment variables.
Either set below environment variables on the Windows Environment Variable or in the DOS shell using command 'SET <variable_name> <value>'

#### TestConfigFilePath
Set environment variable with name 'TestConfigFilePath' and point it to a json file with below structure.
```
{
	"URL": "http://www.mapsynq.com",
	"Browser": "Chrome"
}
```
A sample of this this file is avaible in TestData/Config.json file.

#### TestDataFolder
Set environment variable with name 'TestDataFolder' and point it to a folder which contains all the test data files for each web page test cases.
Each Web page will have 1 or more test cases, all test data pertaining to a web page is stored in a single separate json file.
Below is the sample json structure for test data for SignIn page.
```
{
	"TestName": "Login Test",
	"UserName": "mapsynqtesting@gmail.com",
	"Password": "mapsynqtesting"
}
```
A sample of this this file is avaible in TestData/SignIn.json already.


## Running the tests

You can also run tests using MsTest.exe on DOS prompt which provides detailed test report along with the test report file.
```
C:\Users\khushbu>mstest.exe /testcontainer:MapsynqAutomation.dll /resultsfile:TestResult.trx
Microsoft (R) Test Execution Command Line Tool Version 12.0.21005.1
Copyright (c) Microsoft Corporation. All rights reserved.

Loading MapsynqAutomation.dll...
Starting execution...

Results               Top Level Tests
-------               ---------------
Passed                MapsynQ.Tests.SignInPageTest.TestInvalidSignIn
Passed                MapsynQ.Tests.SignInPageTest.TestSignIn
2/2 test(s) Passed

Summary
-------
Test Run Completed.
  Passed  2
  ---------
  Total   2
Results file:  C:\Users\khushbu\TestResults.trx
Test Settings: Default Test Settings
```

## Coding/Design guidelines

```
* Modular classes with single responsibility
* Use classes and inheritence to maintain code reusability
* Decoupled functionalities to organize code
* Configurable approach to change external factors
* Configurable test data
* Use camel casing for variable names
* blah blah blah ...
```

## Authors

* **Khushbu Agrawal** - (https://github.com/Khushbu-Agrawal)
