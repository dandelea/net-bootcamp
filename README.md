# .NET Bootcamp - Everis

## Introduction

This is a small project developed during the .NET Bootcamp 2018 of Everis. Its aim is simply to propose a small challenge to learn the typical technologies of the .NET stack (C #, ASP, MSSQL ...). It's meant to have been completed in 5 hours, so it can be defined as a class exercise.

## Requirements

* [MS SQL Server 2015](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) or higher.
* Entity Framework 4.6.1
* Visual Studio Community 2015 or higher (Recommended IDE).
* An open link to a database running in *localhost* with name: **NETBootcamp**.

## Quick Start

Once the database is linked to the project, execute the following to dump the scrap data in the NuGet package console (Visual Studio):

```sh
enable-migrations
update-database
```

The API is set to run on port `8008` and the webpage on port `8080` (development).

## Architecture

As good practice, it has been considered a layered architecture. The first layer (DataModel) contains a code first definition of the data model. The second layer (API) consumes the data from the database and offers a RESTFUL API. The third and last layer (MVC) offers the views of the application and consumes the API methods.

For academic purposes, it is recommended to expand with a user and cookie authentication system.

## Author

Daniel de los Reyes

## License

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org>

You can get a full copy of the [LICENSE.md](LICENSE).