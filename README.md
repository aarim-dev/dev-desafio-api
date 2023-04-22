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

* Devido o resultado da API pública Rick and Morty ser paginado com um limite de 20 registros por página, foi feito uma recursividade para obter e agrupar todas as páginas.

## Resultado do desafio

Considerando os filtros abaixo:
* Status = unknown
* Species = alien
* Apareceram em mais de 1 episódio

O resultado são 4 registros.