import requests

filters = {'status': 'unknown', 'specie': 'alien'}
requisicao = requests.get("https://rickandmortyapi.com/api/character/", params=filters)

print(requisicao.json())