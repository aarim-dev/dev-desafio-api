// vitals
import { useEffect, useState } from 'react';

// styles
import {
	FiltersContainerStyle,
	GeneralFiltersContainer,
	FilterCategory,
	FilterItem,
	AliveIcon,
	DeadIcon,
	UnknownIcon,
} from '../styles/FiltersContainer';
import aarimIcon from '../assets/aarim-icon.jpg';

function FiltersContainer({
	filterOptions,
	setFilterOptions,
	setAarimSearch,
	setCurrentPageNumber,
}) {
	const [statusFilter, setStatusFilter] = useState('');
	const [speciesFilter, setSpeciesFilter] = useState('');
	const [genderFilter, setGenderFilter] = useState(false);

	useEffect(() => {});

	return (
		<FiltersContainerStyle>
			<div className="aarim-search-btn-container">
				<img src={aarimIcon} alt="" />
				<button
					onClick={() => {
						setFilterOptions({ status: 'unknown', species: 'alien' });
						setAarimSearch(true);
						setCurrentPageNumber(1);
					}}
				>
					Busca Genial
				</button>
			</div>

			<GeneralFiltersContainer>
				<FilterCategory>
					<div className="filter-title">Status</div>
					<ul className="filter-content">
						<FilterItem
							activeFilter={statusFilter === 'Alive' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, status: 'alive' });
								setStatusFilter(evt.target.lastChild.data);
							}}
						>
							<AliveIcon />
							Alive
						</FilterItem>
						<FilterItem
							activeFilter={statusFilter === 'Dead' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, status: 'dead' });
								setStatusFilter(evt.target.lastChild.data);
							}}
						>
							<DeadIcon />
							Dead
						</FilterItem>
						<FilterItem
							activeFilter={statusFilter === 'Unknown' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, status: 'unknown' });
								setStatusFilter(evt.target.lastChild.data);
							}}
						>
							<UnknownIcon />
							Unknown
						</FilterItem>
					</ul>
				</FilterCategory>
				<FilterCategory>
					<div className="filter-title">Species</div>
					<ul className="filter-content">
						<FilterItem
							activeFilter={speciesFilter === 'Human' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, species: 'Human' });
								setSpeciesFilter(evt.target.lastChild.data);
							}}
						>
							<p>👩</p>
							Human
						</FilterItem>
						<FilterItem
							activeFilter={speciesFilter === 'Alien' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, species: 'Alien' });
								setSpeciesFilter(evt.target.lastChild.data);
							}}
						>
							<p>👽</p>
							Alien
						</FilterItem>
						<FilterItem
							activeFilter={speciesFilter === 'Robot' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, species: 'Robot' });
								setSpeciesFilter(evt.target.lastChild.data);
							}}
						>
							<p>🤖</p>
							Robot
						</FilterItem>
						<FilterItem
							activeFilter={speciesFilter === 'Creature' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, species: 'Creature' });
								setSpeciesFilter(evt.target.lastChild.data);
							}}
						>
							<p>🦄</p>
							Creature
						</FilterItem>
						<FilterItem
							activeFilter={speciesFilter === 'Unknown' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, species: 'Unknown' });
								setSpeciesFilter(evt.target.lastChild.data);
							}}
						>
							<p>⁉️</p>
							Unknown
						</FilterItem>
					</ul>
				</FilterCategory>
				<FilterCategory>
					<div className="filter-title">Gender</div>
					<ul className="filter-content">
						<FilterItem
							activeFilter={genderFilter === 'Male' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, gender: 'Male' });
								setGenderFilter(evt.target.lastChild.data);
							}}
						>
							<p>♂️</p>
							Male
						</FilterItem>
						<FilterItem
							activeFilter={genderFilter === 'Female' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, gender: 'Female' });
								setGenderFilter(evt.target.lastChild.data);
							}}
						>
							<p>♀️</p>
							Female
						</FilterItem>
						<FilterItem
							activeFilter={genderFilter === 'Genderless' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, gender: 'Genderless' });
								setGenderFilter(evt.target.lastChild.data);
							}}
						>
							<p>🌀</p>
							Genderless
						</FilterItem>
						<FilterItem
							activeFilter={genderFilter === 'Unknown' ? '1px #fff solid' : 'none'}
							onClick={(evt) => {
								setFilterOptions({ ...filterOptions, gender: 'unknown' });
								setGenderFilter(evt.target.lastChild.data);
							}}
						>
							<p>⁉️</p>
							Unknown
						</FilterItem>
					</ul>
				</FilterCategory>
			</GeneralFiltersContainer>
		</FiltersContainerStyle>
	);
}

export default FiltersContainer;
