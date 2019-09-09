


#FROM microsoft/dotnet:2.2-runtime AS base
#WORKDIR /app
#FROM microsoft/dotnet:2.2-sdk AS build
#WORKDIR /src
#COPY *.csproj ./
#RUN dotnet restore
#COPY . ./

#RUN dotnet build -c Release -o /app
#FROM build AS publish
#RUN dotnet publish -c Release -o /app
#COPY bin/Release/netcoreapp2.2/clidriver app/clidriver
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENV LD_LIBRARY_PATH="/app/clidriver/lib/"
#ENV PATH=$PATH:"/app/clidriver/bin:/app/clidriver/lib"
#ENTRYPOINT ["dotnet", "app/ConsolaInforTest.dll"]



FROM microsoft/dotnet:2.1-sdk

ENV APP_DIR=/app \
    LD_LIBRARY_PATH=/app/bin/clidriver/lib:/app/bin/clidriver/lib/libdb2.so \
    PATH=${PATH}:/app/clidriver/bin:/app/clidriver/lib

RUN set -e; \
    mkdir -p ${APP_DIR}; \
    apt-get update; \
    apt-get install -y libxml2-dev;

WORKDIR ${APP_DIR}

COPY ConsolaInforTest ConsolaInforTest

RUN set -e; \
    dotnet build .; \
    dotnet publish --no-restore --no-build \
        -o ${APP_DIR}/bin \
        ConsolaInforTest/ConsolaInforTest.csproj

ENTRYPOINT ["dotnet", "/app/bin/ConsolaInforTest.dll"]




#COPY bin/Release/netcoreapp2.2/publish/ app/
#COPY bin/Release/netcoreapp2.2/clidriver app/clidriver

#ENV LD_LIBRARY_PATH="/app/clidriver/lib/"
#ENV PATH=$PATH:"/app/clidriver/bin:/app/clidriver/lib"

#ENTRYPOINT ["dotnet", "app/ConsolaInforTest.dll"]