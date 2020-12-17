# Shabdkosh
Shabdkosh API

- prerequisite
    - dotnet 5.0
    - and install report generator
    
            dotnet tool install -g dotnet-reportgenerator-globaltool  

- clone repo
- dotnet build

Build succeeded.
    0 Warning(s)
    0 Error(s)

- dotnet test

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     4, Skipped:     0, Total:     4, Duration: 3 s - Shabdkosh.dll (net5.0)

Few Assumptions

- Uses songhiawathathe00longrich_djvu.txt as a dictionary to get words, and it is an embedded resource in ASP.NET Web API Project. Update and upload this text file in the code repo, and the GitHub action would run to deploy again.
- The code is tested for 10K limits of the text file, and for the bigger file, it is required to be tuned.
- It uses owlbot.info API to define a keyword; it works well for the top 5 words in terms of occurrences. It may not work for higher numbers. It may be required to parallel tasks to optimize performance.

To collect coverage

    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura

    reportgenerator "-reports:C:\Users\amitp\source\repos\Github\Shabdkosh\Shabdkosh.Tests\TestResults\{Guid}\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html


The code is self-explanatory.

