

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ENV ASPNETCORE_URLS=http://+:80 
WORKDIR /app
copy /bin/Release/net5.0/publish .
ENTRYPOINT ["dotnet", "Payment.API.dll"]
