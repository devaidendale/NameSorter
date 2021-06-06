# NameSorter

This is a simple .NET 5.0 console app. It will read data from the ```input filename```, sort it, and then both print and write the result to screen and ```sorted-names-list.txt```.

### Running ###

From most modern IDEs (eg. VSCode, Visual Studio 2019), activate a prompt or shell (usually ctrl+`) after loading the solution.

From a CLI prompt or shell, navigate to the NameSorter project and ```dotnet run <input filename>```, or navigate to the .exe when built and ```name-sorter <input filename>```.

### Testing ###

From Visual Studio 2019, navigate to the test explorer to run the tests. The tests use the Xunit framework.

Alternatively, from a CLI prompt or shell, navigate to the NameSorter.Tests project and ```dotnet test```.
