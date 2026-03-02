# Arquivo de teste da api com o xunit
## Get start
### Baixar 
```bash
dotnet new xunit -n {name_file.Tests}
```
### Referenciar
```bash 
dotnet add {name_file.Tests} reference ./{directory_api}
```
O Xunit ele ja esta pronto para ser utilizado, contudo precisamos baixar uma biblioteca que gera requesições <b>Http</b> não somente isso mas tambem precisamos de uma biblioteca que tambem gere um padrão <b>MVC</b>.

## Comando de adição de outras bibliotecas de HTTP

### Biblioteca para subir a api em memoria
```bash
dotnet add package Microsoft.AspNetCore.Mvc.Testing
```
### Comando para melhor visualização do teste (Opcional)

```bash
dotnet add package FluentAssertion
```


```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory