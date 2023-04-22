# Rick And Morty

O objetivo desse projeto é o consumo dos dados de personagens da API pública da série de animação Rick and Morty.

## Pré-requisitos

Para rodar essa aplicação em um ambiente local, você deve:

* Baixar e instalar o .NET 5 SDK
* Baixar a sua IDE de preferência

## API pública Rick And Morty

* [Documentação REST](https://rickandmortyapi.com/documentation/#rest)
* [Documentação de como filtrar os personagens](https://rickandmortyapi.com/documentation/#filter-characters)
* Objetos:
  * [Info e paginação](https://rickandmortyapi.com/documentation/#info-and-pagination)
  * [Personagens](https://rickandmortyapi.com/documentation/#character-schema)

## Estrutura

Considerando uma estrutura simples de projeto, foram definidas as seguintes camadas:

* **RickAndMorty**: Aplicação Web API, responsável por disponibilizar os recursos via protocolo HTTP. 
* **RickAndMortyApi.Wrapper**: Encapsulador da API pública Rick and Morty com as definições dos schemas e requests na API.
* **RickAndMorty.CrossCutting**: Camada transversal
  * A classe `AppSettings` representa as configurações definidas no arquivo de configuração `appsettings{env}.json` do projeto `RickAndMorty`, a escolha de estar nessa camada, é que ela pode ser injetada em qualquer nível, isso facilita o uso dos parâmetros em qualquer camada.

## Regras

* Devido o resultado da API pública Rick and Morty ser paginado com um limite de 20 registros por página, foi feito uma recursividade para obter e agrupar o resultado de todas as páginas.

## Resultado do desafio

Considerando os filtros abaixo:
* Status = unknown
* Species = alien
* Apareceram em mais de 1 episódio

O resultado são 4 registros:

~~~json
[
  {
    "id": 23,
    "name": "Arcade Alien",
    "status": "unknown",
    "species": "Alien",
    "type": "",
    "gender": "Male",
    "origin": {
      "name": [],
      "url": []
    },
    "location": {
      "name": [],
      "url": []
    },
    "image": "https://rickandmortyapi.com/api/character/avatar/23.jpeg",
    "episode": [
      "https://rickandmortyapi.com/api/episode/13",
      "https://rickandmortyapi.com/api/episode/19",
      "https://rickandmortyapi.com/api/episode/21",
      "https://rickandmortyapi.com/api/episode/25",
      "https://rickandmortyapi.com/api/episode/26"
    ],
    "url": "https://rickandmortyapi.com/api/character/23",
    "created": "2017-11-05T08:43:05.095Z"
  },
  {
    "id": 282,
    "name": "Revolio Clockberg Jr.",
    "status": "unknown",
    "species": "Alien",
    "type": "Gear-Person",
    "gender": "Male",
    "origin": {
      "name": [],
      "url": []
    },
    "location": {
      "name": [],
      "url": []
    },
    "image": "https://rickandmortyapi.com/api/character/avatar/282.jpeg",
    "episode": [
      "https://rickandmortyapi.com/api/episode/11",
      "https://rickandmortyapi.com/api/episode/13",
      "https://rickandmortyapi.com/api/episode/25"
    ],
    "url": "https://rickandmortyapi.com/api/character/282",
    "created": "2017-12-31T19:21:17.351Z"
  },
  {
    "id": 308,
    "name": "Scropon",
    "status": "unknown",
    "species": "Alien",
    "type": "Lobster-Alien",
    "gender": "Male",
    "origin": {
      "name": [],
      "url": []
    },
    "location": {
      "name": [],
      "url": []
    },
    "image": "https://rickandmortyapi.com/api/character/avatar/308.jpeg",
    "episode": [
      "https://rickandmortyapi.com/api/episode/11",
      "https://rickandmortyapi.com/api/episode/21"
    ],
    "url": "https://rickandmortyapi.com/api/character/308",
    "created": "2018-01-05T14:22:47.706Z"
  },
  {
    "id": 331,
    "name": "Squanchy",
    "status": "unknown",
    "species": "Alien",
    "type": "Cat-Person",
    "gender": "Male",
    "origin": {
      "name": [],
      "url": []
    },
    "location": {
      "name": [],
      "url": []
    },
    "image": "https://rickandmortyapi.com/api/character/avatar/331.jpeg",
    "episode": [
      "https://rickandmortyapi.com/api/episode/11",
      "https://rickandmortyapi.com/api/episode/16",
      "https://rickandmortyapi.com/api/episode/21"
    ],
    "url": "https://rickandmortyapi.com/api/character/331",
    "created": "2018-01-10T16:29:25.344Z"
  }
]
~~~