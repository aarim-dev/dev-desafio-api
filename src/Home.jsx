// vitals
import { useEffect, useState } from 'react';
import axios from 'axios';

// components
import Header from './components/Header';

// styles
import './styles/global.css';
import CharacterCard from './components/CharacterCard';
import { CardsContainer } from './styles/Home';

function Home() {
	const [currentPageNumber, setCurrentPageNumber] = useState(1);
	const [currentPageData, setCurrentPageData] = useState([]);

	useEffect(() => {
		const fetchAPI = async (page) => {
			const BASE_URL = 'https://rickandmortyapi.com/api/character';
			try {
				const fetchData = await axios.get(BASE_URL, {
					params: {
						page,
					},
				});

				const data = await fetchData.data.results;
				setCurrentPageData(data);
			} catch (err) {
				console.log(err);
			}
		};

		fetchAPI();
	}, []);

	return (
		<main>
			<Header />
			<CardsContainer>
				{currentPageData.map((character) => (
					<CharacterCard character={character} />
				))}
			</CardsContainer>
		</main>
	);
}

export default Home;
