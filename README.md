# 💰 CrudUsuario

API em .NET Core integrada ao **Supabase** (PostgreSQL), utilizando **Newtonsoft.Json** para serialização.

## 🛠 Tecnologias
* .NET 8 / C#
* Supabase (Database & Auth)
* Newtonsoft.Json
* Swagger

## ⚙️ Configuração
Crie o arquivo `appsettings.json` na raiz com suas chaves:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Supabase": {
    "Url": "SUA_URL_DO_SUPABASE",
    "Key": "SUA_KEY_ANON_DO_SUPABASE"
  },
  "AllowedHosts": "*"
}
```

## ▶️ Como rodar
### 1. Restaurar pacotes:
```bash
dotnet restore
```
### 2. Iniciar a API:
```bash
dotnet run
```
### 3. Acessar Documentação: Abra http://localhost:5090/swagger no navegador.
