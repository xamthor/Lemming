FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY Lemming.csproj Lemming.csproj
RUN dotnet restore Lemming.csproj
COPY . .
RUN dotnet publish -c Release
CMD ["dotnet", "bin/Release/net5.0/Lemming.dll"]
