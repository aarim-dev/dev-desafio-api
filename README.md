# Desafio API

O desafio foi bem tranquilo, não tive dificuldades em executar.

A documentação foi suficiente para definir os esquemas e endpoints.

Observei que a API dispõe de alguns pré-filros por queryString, então utilizei esse atalho para ganhar agilidade, em contraponto, optei por não utilizar o SDK indicado nas referencias da documentação, justamente por ser um desafio simples. Julguei mais proveitoso implementar todo o app sem consumir nunhum pacote adicional. 


## Projeto (Resumo)
[...]
A demanda é consumir os dados de personagens da API e listar os que atendam a todos os seguintes critérios:
* Status = unknown
* Species = alien
* Apareceram em mais de 1 episódio


## Detalhes de Implementação

O projeto foi constuído baseado num WebApp com o objetivo de exibir em uma visalização básica (razor + bootstrap) os itens do requisito. 

Acessando a rota padrão "GET: /" o app exibe os personagens conforme o requisito do desafio. 

* Controller: Home
* Action: Index
* Serviço: RickAndMoryApiService.GetChallengeAsync()

Acessando a rota "/Home/All" a app exibe todos os personagens listados pela API. 

* Controller: Home
* Action: All
* Serviço: RickAndMortyService.GetAllCharactersAsync()

## Arquitetura
#### ./DesafioRickMorty/Helpers/
###### Reune utilitários para o desenvolvimento.

* HttpClientHelper.cs
*       Define um httpclient genérico, onde no método GET devolve um objeto construido de acordo com a referencia de tipo generico passado como referencia. 
* HttpContentExtensions.cs
*       Implementa a conversão do contentStream para o objeto tipado anteriormente. 
* StringExtensions.cs
*       Implementa uma classe de extensão para string, onde foi incluído o métod HasValue() que abstrai a verificação se a string tem um valor atribuído. <> nulll, empty & WhiteSpaces. 

#### ./DesafioRickMorty/Models/
###### Implementa os modelos conforme esquemáticos da documentação. 

#### ./DesafioRickMorty/Services/
###### Reune as definições de Interface e implementações do serviço de consumo da API do desafio. 

##### Interfaces:
*        GetPaginatedAsync()
    ######  Recebe o número da página como argumento e devolve a resposta conforme esquema da [API](https://rickandmortyapi.com/documentation/#rest)

*       GetAllCharactersAsync()
    ###### Retorna todos os personagens da API correnco a paginação até o fim. Pode receber os [filtros](https://rickandmortyapi.com/documentation/#filter-characters) conforme o esquema da api e retorna uma lista de [personagens](https://rickandmortyapi.com/documentation/#character-schema). 

*       GetChallengeAsync()

    ###### Executa a consulta na API invocando internamente a implementação de GetAllCharactersAsync passando os filtros de Status e Species e em seguida, filtra seu retorno com Linq para itens onde tenham mais de 1 episódio. 

Outros itens seguem o padrão básico de projeto, não acho necessário aprofundar. 
Mas caso queira, fico a disposição...

## Obrigado!

Agradeço novamente a oportunidade, foi um projetinho legal :) 