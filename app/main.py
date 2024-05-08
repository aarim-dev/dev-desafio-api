from fastapi import FastAPI, HTTPException
from typing import List, Optional
from pydantic import BaseModel, Field
import httpx

class Character(BaseModel):
    id: int
    name: str
    status: str
    species: str
    type: str
    gender: str
    origin: str
    location: str
    image: str
    episode_count: int
    episodes: List[str]

    class Config:
        json_schema_extra = {
            "example": {
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
        }

class ResponseEnvelope(BaseModel):
    success: bool
    data: Optional[List[dict]] = None
    message: Optional[str] = None


app = FastAPI()

@app.get("/challengeapi", response_model=ResponseEnvelope, summary="Retrieve characters", description="Retrieve character data and list those that meet all of the following criteria: Status = unknown, Species = alien, appeared in more than 1 episode" )
async def read_characters():
    try:
        characters = await get_characters_with_criteria()
        if not characters:
            return {"success": False, "message": "No characters found matching criteria"}
        return {"success": True, "data": characters}
    except ValueError:
        raise HTTPException(status_code=400, detail="Invalid parameters")
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))
    
    
async def get_characters_with_criteria():
    base_url = 'https://rickandmortyapi.com/api/character'
    # Define os parâmetros fixos diretamente
    status = "unknown"
    species = "alien"
    min_episodes = 1
    url = f'{base_url}?status={status}&species={species}'
    results = []
    
    async with httpx.AsyncClient() as client:
        while url:
            response = await client.get(url)
            data = response.json()
            characters = data['results']

            # Inclui todas as informações sobre os personagens
            results.extend([
                {
                    'id': char['id'],
                    'name': char['name'],
                    'status': char['status'],
                    'species': char['species'],
                    'type': char['type'],
                    'gender': char['gender'],
                    'origin': char['origin']['name'],
                    'location': char['location']['name'],
                    'image': char['image'],
                    'episode_count': len(char['episode']),
                    'episodes': char['episode']  # URLs dos episódios
                }
                for char in characters if len(char['episode']) > min_episodes
            ])
            
            url = data['info']['next']
    
    return results
