// vitals
import { useEffect, useState } from 'react';
import axios from 'axios';

// components
import Header from './components/Header';

// styles
import './styles/global.css';
import CharacterCard from './components/CharacterCard';
import { CardsContainer, PaginationContainer } from './styles/Home';
import FiltersContainer from './components/FiltersContainer';

function Home() {
	const [currentPageNumber, setCurrentPageNumber] = useState(1);
	const [currentPageData, setCurrentPageData] = useState([]);

	const [nextPageLink, setNextPageLink] = useState('');
	const [previousPageLink, setPreviousPageLink] = useState('');

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

				const data = await fetchData.data;
				setPreviousPageLink(data.info.prev);
				setNextPageLink(data.info.next);
				setCurrentPageData(data.results);
			} catch (err) {
				console.log(err);
			}
		};

		fetchAPI(currentPageNumber);
	}, [currentPageNumber, filterOptions]);

	console.log(currentPageNumber);

	return (
		<main>
			<Header />

			<FiltersContainer
				filterOptions={filterOptions}
				setFilterOptions={setFilterOptions}
				setAarimSearch={setAarimSearch}
				setCurrentPageNumber={setCurrentPageNumber}
			/>

			<CardsContainer>
				{currentPageData
					// this is one of the requirements of the challenge, more than 1 episode among other filters
					.filter((item) => (aarimSearch ? item.episode.length > 1 : item))
					.map((character) => (
						<CharacterCard key={character.name + character.episode.length} character={character} />
					))}
			</CardsContainer>

			<PaginationContainer>
				<ul>
					<li
						onClick={() => {
							if (previousPageLink) {
								setCurrentPageNumber(currentPageNumber - 1);
							}
							return;
						}}
					>
						Previous
					</li>
					<li>{currentPageNumber}</li>
					<li
						onClick={() => {
							if (nextPageLink) {
								setCurrentPageNumber(currentPageNumber + 1);
							}
							return;
						}}
					>
						Next
					</li>
				</ul>
			</PaginationContainer>
		</main>
	);
}

export default Home;
