# Desafio API

Desenvolvi essa API no Design Pattern Domain Driven, e visto que nunca tinha codado em C#, e nem havia tido contato com .NET antes, o código provavelmente estará bem parecido com uma arquitetura em Java/Spring, por exemplo. 
A API está baseada nos princípios de SOLID, por isso criei interfaces e garanti imutabilidade de recursos nas operações. 

Pensei que mesmo sendo um desafio simples, o ideal é sempre construir algo pensando na escalabilidade e performance, então implementei Singletons. Pesquisei alguma forma thread-safe de como implementá-los na documentação do C#, e acabei optando por utilizar a estratégia Lazy, porém, todas as dependências podem ser alteradas caso você deixe explícito no construtor, fiz dessa forma pensando que no futuro, tornaria mais fácil a implementação de testes, injetando depêndencias mockadas.

Tentei individualizar ao máximo a responsabilidade de cada classe, por isso o código está bem separado, seguindo o Single-responsibility Principle. 

Agora passando de decisões arquiteturais para algo mais lógico,  criei uma interface Gateway da API do Rick and Morty que define todos os métodos que serão utilizados (nesse caso, apenas o GET), que aceita parâmetros de espécie e status, caso um dia seja necessário implementar algum filtro diferente, e também criei enums com cada status disponível de acordo com a documentação.

A implementação desses métodos é feita sem regras de negócio chamando o cLient, que é a classe que de fato faz a requisição para a API, e por fim essa Classe de Implementação é utilizada pelo serviço da minha API, que é onde aplico a regra de negócio (A questão de aparecer em mais de um EP).
 
Ao invés de utilizar variáveis de ambiente no appsettings.json, usei um .env, para se assemelhar ao que seria feito em um ambiente de produção, no geral a API foi desenvolvida pensando em boas práticas Restful como um todo ;)

## Para a Aarim

* Curti muito desenvolver esse desafio, principalmente porque envolveu aprender algo novo, e juntar com conceitos que já utilizo em outras linguagens. Espero que gostem do código tanto quanto eu gostei de desenvolvê-lo, inclusive, aceito sugestões de melhoria e dicas de .NET ahaha 👾. 
Independente do resultado da avaliação, gostaria de agradecer a oportunidade!
