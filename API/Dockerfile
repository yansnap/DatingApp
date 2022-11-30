FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

# copy csproj and restore as distinct laters
COPY *.csproj ./
RUN dotnet restore 

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.9
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "API.dll" ]