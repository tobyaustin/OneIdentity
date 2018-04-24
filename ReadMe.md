One Identity API Example
========================

Clone or download from https://github.com/tobyaustin/OneIdentity

API *Swagger* documentation  at http://localhost:58066/swagger/

Requirements...
* .Net Core 2.0 framework
* MongoDB server 3.6 (may run on earlier versions)

Written in .Net Core MVC Web API the solution consists of three main projects...
* **OneIdentity.<span></span>Web** - Web API
* **OneIdentity.Business** - simplified business logic
* **OneIdentity.Db** - data access layer

There are also a couple of other projects included in the solution...
* **OneIdentity.Test** - skeleton unit testing class using 
* **OneIdentity.Debug** - simple console application (for trying code quickly)

Notes
* The business tier and repositories in the data access layer are something of an overkill for an application of this complexity but aid future development and hopefully demonstrate good practice.
* The test project is only designed to test the business logic. My choice to test the Web API would be to use [Postman](https://www.getpostman.com/) to build scripts. These tests could then be included as part of the build/deployment process.

Toby Austin