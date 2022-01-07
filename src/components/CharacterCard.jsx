// styles
import { CharacterCardStyle } from '../styles/CharacterCard';

function CharacterCard({ character }) {
	return (
		<CharacterCardStyle imageURL={character.image}>
			<div className="info-container">
				<div>{character.name}</div>
				<div>{character.species}</div>
				<div>{character.episode.length} episodes</div>
			</div>
		</CharacterCardStyle>
	);
}

export default CharacterCard;
