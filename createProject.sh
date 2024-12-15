#!/bin/bash

readonly PROJECT_NAME=$1

echo "Create new class project"
dotnet new classlib -o src/$PROJECT_NAME

echo "- Rename file to Solution.cs..."
mv src/$PROJECT_NAME/Class1.cs src/$PROJECT_NAME/Solution.cs

echo "- Create new Test project"
dotnet new nunit -o tests/$PROJECT_NAME.Tests

echo "- Rename file to SolutionTests.cs"
mv tests/$PROJECT_NAME.Tests/UnitTest1.cs tests/$PROJECT_NAME.Tests/SolutionTests.cs

echo "- Add projects to solution"
dotnet sln add src/$PROJECT_NAME/$PROJECT_NAME.csproj
dotnet sln add tests/$PROJECT_NAME.Tests/$PROJECT_NAME.Tests.csproj

echo "- Add main project as reference for unit tests."
cd tests/$PROJECT_NAME.Tests
dotnet add reference ../../src/$PROJECT_NAME/$PROJECT_NAME.csproj

echo "- Run tests"
dotnet test
