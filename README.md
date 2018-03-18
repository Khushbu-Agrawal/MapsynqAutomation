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
```

### Configurations

You need to setup few environment variables to run the test. It's designed to be able to easily configure test data and store it individually, so that test data management is easy. Just configure following environment variables.
Either set below environment varibales on the Windows Environemnt Variable or in the DOS shell using command SET <variable_name> <value>

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

Run all tests from VS menu Test -> Run -> All Tests

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
