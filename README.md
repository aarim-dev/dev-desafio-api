# Rick and Morty Character API

![FastAPI](https://img.shields.io/badge/FastAPI-005571?style=for-the-badge&logo=fastapi)
![Python](https://img.shields.io/badge/Python-3.12+-blue.svg?style=for-the-badge&logo=python)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

Este projeto é uma API construída com FastAPI que recupera informações sobre personagens da série "Rick and Morty", filtrando por personagens de status "unknown", espécie "alien" e que apareceram em mais de um episódio.

## Tecnologias Utilizadas

- **FastAPI**: Framework moderno e rápido (de alta performance) para construção de APIs com Python 3.12+ baseado em padrões Python type hints.
- **HTTPX**: Uma biblioteca HTTP assíncrona para Python 3.
- **Docker**: Utilizado para containerizar a aplicação e garantir que ela funcione em qualquer ambiente.
- **Pydantic**: Utilizado para a validação de dados e a conversão entre tipos de dados complexos e representações primitivas.


## Características da API

- Busca dinâmica por personagens baseada em critérios pré-definidos.
- Uso de modelos Pydantic para validação de entrada e saída de dados.
- Documentação automática gerada via Swagger UI.


## Estrutura do Projeto

Abaixo está a estrutura de diretórios do projeto:
```plaintext
/nome-do-projeto
│
├── app/                      # Pasta que contém o código fonte da aplicação
│   └── main.py               # Script principal que contém a lógica da API
│
├── Dockerfile                # Dockerfile para construir a imagem do container
└── requirements.txt          # Lista todas as dependências Python do projeto
```

## Instalação
Siga as instruções abaixo para configurar o ambiente de desenvolvimento e executar o projeto.

### Pré-Requisitos

- **Docker**: Essencial para rodar o container onde a aplicação é executada.

### Usando Docker

Para construir e rodar a aplicação usando Docker, execute:

```bash
docker build -t rickandmortyapi .
docker run -d --name rickandmortyapi -p 8000:8000 rickandmortyapi
```

Após estes comandos, a aplicação estará acessível em http://localhost:8000/challengeapi.

## Documentação Swagger UI

FastAPI gera automaticamente uma interface de documentação para a API utilizando Swagger UI. Para acessar esta documentação:

1. Navegue até http://localhost:8000/docs no seu navegador.
2. Você encontrará uma interface interativa que descreve todos os endpoints da API, incluindo o método GET /challengeapi.
Através desta interface, você pode também testar os endpoints diretamente, fornecendo os parâmetros necessários e visualizando a resposta da API.
3. Esta documentação Swagger é ideal para desenvolvedores que desejam entender rapidamente todas as funcionalidades da API e experimentar as requisições em tempo real.

## Uso
A API possui um único endpoint que retorna uma lista de personagens que correspondem aos critérios especificados.


#### Endpoint Detalhado
**GET /challengeapi**

![GET Request](https://img.shields.io/badge/GET-/challengeapi-green?style=flat-square)

- **Descrição**: Retorna todos os personagens com status "unknown", espécie "alien" e que apareceram em mais de um episódio.
- **Query Parameters**:
  - **status**: Filtra personagens pelo seu status (`unknown` por padrão).
  - **species**: Filtra personagens pela espécie (`alien` por padrão).
  - **min_episodes**: O número mínimo de episódios em que o personagem deve ter aparecido (`1` por padrão).
- **Resposta de Sucesso**: `200 OK` com lista de personagens.
- **Resposta de Erro**: `500 Internal Server Error` se ocorrer um erro durante o processamento da solicitação.

### Exemplo de Resposta

```json
{
  "success": true,
  "data": [
    {
      "id": 1,
      "name": "Rick Sanchez",
      "status": "unknown",
      "species": "Human",
      "type": "",
      "gender": "Male",
      "origin": "Earth (C-137)",
      "location": "Earth (Replacement Dimension)",
      "image": "https://rickandmortyapi.com/api/character/avatar/1.jpeg",
      "episode_count": 31,
      "episodes": ["https://rickandmortyapi.com/api/episode/1", "https://rickandmortyapi.com/api/episode/2"]
    }
  ],
  "message": null
}
```

### Campos de Resposta

- success: Booleano indicando se a operação foi bem-sucedida.
- data: Lista de personagens (vazia se nenhum personagem for encontrado).
- id: Identificador único do personagem.
- name: Nome do personagem.
- status: Status atual do personagem.
- species: Espécie do personagem.
- type: Tipo específico do personagem, se aplicável.
- gender: Gênero do personagem.
- origin: Local de origem do personagem.
- location: Localização atual do personagem.
- image: URL da imagem do personagem.
- episode_count: Número de episódios em que o personagem apareceu.
- episodes: Lista de URLs dos episódios em que o personagem apareceu.
- message: Mensagem adicional sobre o resultado da operação (por exemplo, erro ou informação adicional).