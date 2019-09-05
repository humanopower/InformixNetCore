FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY bin/Release/netcoreapp2.2/publish/ app/
COPY bin/Release/netcoreapp2.2/clidriver app/clidriver

ENV LD_LIBRARY_PATH="/app/clidriver/lib/"
Env PATH=$PATH:"/app/clidriver/bin:/app/clidriver/lib"

ENTRYPOINT ["dotnet", "app/ConsolaInforTest.dll"]