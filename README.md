# Shabdkosh
Shabdkosh API

- prerequisite
    - dotnet 5.0
    - and install report generator
    
            dotnet tool install -g dotnet-reportgenerator-globaltool

- clone repo
- dotnet build -c Release 

Build succeeded.
    0 Warning(s)
    0 Error(s)

- dotnet test

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     8, Skipped:     0, Total:     8, Duration: 5 s - Shabdkosh.Tests.dll (net5.0)

On wsl ubuntu

    To collect coverage

        dotnet test -c Release -v minimal --no-build --collect:"XPlat Code Coverage" --settings coverlet.runsettings --results-directory './CodeCoverageResults'

    To generate report

        reportgenerator "-reports:./CodeCoverageResults/{GUID}/coverage.cobertura.xml" "-targetdir:coveragereport"    
    
Build Docker image

    docker build -f Dockerfile -t shabdkosh:v1 ..
   
Few Assumptions

- Uses songhiawathathe00longrich_djvu.txt as a dictionary to get words, and it is an embedded resource in ASP.NET Web API Project. Update and upload this text file in the code repo, and the GitHub action would run to deploy again.
- The code is tested for 10K limits of the text file, and for the bigger file, it is required to be tuned.
- It uses owlbot.info API to define a keyword; it works well for the top 5 words in terms of occurrences. It may not work for higher numbers. It may be required to parallel tasks to optimize performance.

[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-white.svg)](https://sonarcloud.io/dashboard?id=amitpuri-Shabdkosh)
