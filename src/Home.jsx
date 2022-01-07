// vitals
import { useEffect, useState } from 'react';
import axios from 'axios';

// components
import Header from './components/Header';

// styles
import './styles/global.css';
import CharacterCard from './components/CharacterCard';
import { CardsContainer } from './styles/Home';
import FiltersContainer from './components/FiltersContainer';

function Home() {
	const [currentPageNumber, setCurrentPageNumber] = useState(1);
	const [currentPageData, setCurrentPageData] = useState([]);
	const [filterOptions, setFilterOptions] = useState({});

	const [aarimSearch, setAarimSearch] = useState(false);

	useEffect(() => {
		const fetchAPI = async (page) => {
			const BASE_URL = 'https://rickandmortyapi.com/api/character';
			try {
				const fetchData = await axios.get(BASE_URL, {
					params: {
						page,
						...filterOptions,
					},
				});

				const data = await fetchData.data.results;
				setCurrentPageData(data);
			} catch (err) {
				console.log(err);
			}
		};

		fetchAPI(currentPageNumber);
	}, [currentPageNumber, filterOptions]);

	return (
		<main>
			<Header />
			<FiltersContainer
				filterOptions={filterOptions}
				setFilterOptions={setFilterOptions}
				setAarimSearch={setAarimSearch}
			/>
			<CardsContainer>
				{currentPageData
					.filter((item) => (aarimSearch ? item.episode.length > 1 : item))
					.map((character) => (
						<CharacterCard key={character.name + character.episode.length} character={character} />
					))}
			</CardsContainer>
		</main>
	);
}

export default Home;
