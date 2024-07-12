FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR PermissionApi

COPY ./Employee.Permissions.sln ./
COPY ./Employee.Permissions.Api/*.csproj ./Employee.Permissions.Api/
COPY ./Employee.Permissions.Application/*.csproj ./Employee.Permissions.Application/
COPY ./Employee.Permissions.Domain/*.csproj ./Employee.Permissions.Domain/
COPY ./Employee.Permissions.Infrastructure/*.csproj ./Employee.Permissions.Infrastructure/

RUN dotnet restore ./Employee.Permissions.sln

COPY . .
RUN dotnet publish -c Release -o publish

#IMAGE
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /PermissionApi
COPY --from=build /PermissionApi/publish .

EXPOSE 80
EXPOSE 7225

ENTRYPOINT ["dotnet", "Employee.Permissions.Api.dll"]