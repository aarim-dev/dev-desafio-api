
# Desafio API

  Para concluir esse desafio pensei em criar uma API básica para retornar os nomes dos personagens, chamando a rota /.

## Execução

Para rodar a aplicação:

Garantir que tenha instalado o SDK do .NET 6.

```bash
  dotnet run
```

E depois acessar a raiz da API:

```bash
Ex: http://localhost:5149/?status=unknown&species=alien&episodesShownGreaterThan=1
```

Também é possível fazer uso do Swagger para consumir essa rota:

```bash
Ex: http://localhost:5149/swagger/index.html
```

E acessar a rota / preechendo seus parâmetros.

Resultado esperado será a lista dos nomes dos personagens :)