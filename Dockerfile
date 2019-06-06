FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src

COPY VacationRental.Contact.Api.sln ./
COPY VacationRental.Contact.Api/*.csproj ./VacationRental.Contact.Api/
COPY VacationRental.Contact.DataRepository/*.csproj ./VacationRental.Contact.DataRepository/
COPY VacationRental.Contact.Domain/*.csproj ./VacationRental.Contact.Domain/
COPY VacationRental.Contact.Domain.Common/*.csproj ./VacationRental.Contact.Domain.Common/
COPY VacationRental.Contact.Api.Tests/*.csproj ./VacationRental.Contact.Api.Tests/

RUN dotnet restore
COPY . .
WORKDIR ./VacationRental.Contact.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "VacationRental.Contact.Api.dll"]