# Shabdkosh
Shabdkosh API

- prerequisite
    - dotnet 5.0

- clone repo
- dotnet build

Build succeeded.
    0 Warning(s)
    0 Error(s)

- dotnet test

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 3 m 24 s - Shabdkosh.dll (net5.0)

- Test URL https://shabdkoshapi.azurewebsites.net/swagger/index.html

Few Assumptions

- Uses songhiawathathe00longrich_djvu.txt as dictionary to get words and it is embedded resource in ASP.NET Web API Project. To update, it is required to be uploaded in code repo and GitHub action would run to deploy again.
- The code is test for 10K limits of text file and it is required to be tuned for bigger file.
- It uses owlbot.info API to get definition of a keyword, It works well for top 5 words in term of occurances. It may not work for higher numbers. It may be required to parallel tasks to optimize performance.
