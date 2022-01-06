// styles
import {
	FiltersContainerStyle,
	GeneralFiltersContainer,
	FilterCategory,
	AliveIcon,
	DeadIcon,
	UnknownIcon,
} from '../styles/FiltersContainer';
import aarimIcon from '../assets/aarim-icon.jpg';

function FiltersContainer() {
	return (
		<FiltersContainerStyle>
			<div className="aarim-search-btn-container">
				<img src={aarimIcon} alt="" />
				<button>Busca Genial</button>
			</div>

			<GeneralFiltersContainer>
				<FilterCategory>
					<div className="filter-title">Status</div>
					<ul className="filter-content">
						<li>
							<AliveIcon />
							Alive
						</li>
						<li>
							<DeadIcon />
							Dead
						</li>
						<li className="unknown-icon">
							<UnknownIcon />
							Unknown
						</li>
					</ul>
				</FilterCategory>
				<FilterCategory>
					<div className="filter-title">Species</div>
					<ul className="filter-content">
						<li>Human</li>
						<li>Alien</li>
						<li>Robot</li>
						<li>Creature</li>
						<li>Unknown</li>
					</ul>
				</FilterCategory>
				<FilterCategory>
					<div className="filter-title">Gender</div>
					<ul className="filter-content">
						<li>Male</li>
						<li>Female</li>
						<li>Genderless</li>
						<li>Unknown</li>
					</ul>
				</FilterCategory>
			</GeneralFiltersContainer>
		</FiltersContainerStyle>
	);
}

export default FiltersContainer;
