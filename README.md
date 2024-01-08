
"Nos envie através do `README` ou do e-mail um simples descritivo do seu processo nesse desafio, as dificuldades, descobertas, etc."

Não tive muitas dificuldades dado que já tenho alguma experiência com APIs, seja consultando ou desenvolvendo;
resolvi então testar um projeto de dotnet que não tinha testado antes, uma minimal api (comando **dotnet new web**).
Basta rodar o programa e acessar **https://localhost:7267/swagger/index.html** para testar.
O endpoint que retorna a solução se chama: **/rickyAndMorty/characters/challengeFilter**.

Apesar de não ter sido pedido aproveitei o projeto para fazer um teste que já queria fazer; testar o driver de MongoDb que
permite o uso de Queryable em suas coleções para tirar proveito do LINQ do C#, plenamente utilizável com sql.
Então iria carregar os  dados para um cluster gratuito do MongoDb, mas Quando vi que ia demorar um pouco mais, resolvi entregar logo
a solução já que, pelo que li do desafio, o intuito era entregar algo simples.
