# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8082
EXPOSE 8083


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrionTest/OrionTest.csproj", "OrionTest/"]
RUN dotnet restore "./OrionTest/OrionTest.csproj"
COPY . .
WORKDIR "/src/OrionTest"
RUN dotnet build "./OrionTest.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrionTest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Executa os testes
CMD ["dotnet", "test", "--logger:console;verbosity=detailed", "--results-directory=/app/test-results"]
