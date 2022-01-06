// vitals
import styled from 'styled-components';

export const FiltersContainerStyle = styled.div`
	align-self: center;
	border: 1px #fff solid;
	color: #fff;
	display: flex;
	flex-flow: column;
	margin: 2rem 0;

	.aarim-search-btn-container {
		align-items: center;
		display: flex;
		background-color: #edc516;
		margin: 1rem auto;
		padding: 2px 10px 0 0;
		transition: 200ms;
		width: max-content;

		> img {
			max-width: 58px;
		}

		> button {
			background-color: rgba(0, 0, 0, 0);
			border: none;
			font-family: 'Poppins', sans-serif;
			outline: none;
		}

		> button:hover {
			cursor: pointer;
		}
	}
	.aarim-search-btn-container:hover {
		cursor: pointer;
		transform: scale(1.03);
	}
`;

export const GeneralFiltersContainer = styled.div`
	display: flex;
`;

export const FilterCategory = styled.div`
	display: flex;
	flex-flow: column;
	margin: 0 1rem;

	.filter-title {
		text-align: center;
	}

	.filter-content {
		display: flex;
		flex-flow: column;
		height: 100%;
		justify-content: space-between;
		list-style-type: none;

		> li {
			align-items: center;
			display: flex;
			gap: 3px;
		}
	}
`;

export const AliveIcon = styled.span`
	background-color: #55cc44;
	border-radius: 50px;
	display: flex;
	height: 10px;
	width: 10px;
`;

export const DeadIcon = styled.span`
	background-color: #e13a17;
	border-radius: 50px;
	display: flex;
	height: 10px;
	width: 10px;
`;

export const UnknownIcon = styled.span`
	background-color: #5d928f;
	border-radius: 50px;
	display: flex;
	height: 10px;
	width: 10px;
`;
