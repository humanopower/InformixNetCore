


FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . ./

RUN dotnet build -c Release -o /app
FROM build AS publish
RUN dotnet publish -c Release -o /app
#COPY bin/Release/netcoreapp2.2/clidriver app/clidriver
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV LD_LIBRARY_PATH="/app/clidriver/lib/"
ENV PATH=$PATH:"/app/clidriver/bin:/app/clidriver/lib"
ENTRYPOINT ["dotnet", "app/ConsolaInforTest.dll"]




#COPY bin/Release/netcoreapp2.2/publish/ app/
#COPY bin/Release/netcoreapp2.2/clidriver app/clidriver

#ENV LD_LIBRARY_PATH="/app/clidriver/lib/"
#ENV PATH=$PATH:"/app/clidriver/bin:/app/clidriver/lib"

#ENTRYPOINT ["dotnet", "app/ConsolaInforTest.dll"]