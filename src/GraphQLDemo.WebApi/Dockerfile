FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["GraphQLDemo.WebApi/GraphQLDemo.WebApi.csproj", "GraphQLDemo.WebApi/"]
RUN dotnet restore "GraphQLDemo.WebApi/GraphQLDemo.WebApi.csproj"
COPY . .
WORKDIR "/src/GraphQLDemo.WebApi"
RUN dotnet build "GraphQLDemo.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GraphQLDemo.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQLDemo.WebApi.dll"]