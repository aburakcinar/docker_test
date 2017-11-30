FROM microsoft/dotnet:2.0-sdk
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./

# Expose port 80 for the Web API traffic
ENV ASPNETCORE_URLS http://+:80
EXPOSE 80

RUN dotnet restore

# copy and build everything else
COPY . ./
#RUN dotnet run
#RUN dotnet publish -c Release -o out
#ENTRYPOINT ["dotnet", "out/core_webapi.dll"]