// vitals
import styled from 'styled-components';

export const FiltersContainerStyle = styled.div`
	align-self: center;
	color: #fff;
	display: flex;
	flex-flow: column;
	margin: 2rem 0;

	.aarim-search-btn-container {
		align-items: center;
		background-color: #edc516;
		box-shadow: #a68d1f 1px 1px 0, #a68d1f 2px 2px 0, #a68d1f 3px 3px 0, #a68d1f 4px 4px 0;
		display: flex;
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
	gap: 1rem;
`;

export const FilterCategory = styled.div`
	display: flex;
	flex-flow: column;
	margin: 0 auto;

	.filter-title {
		font-family: 'Work Sans', 'sans-serif';
		margin: 12px 0;
	}

	.filter-content {
		display: flex;
		flex-flow: column;
		font-family: 'Poppins', 'sans-serif';
		height: 100%;
		justify-content: space-between;
		list-style-type: none;
		margin: 0 auto;
		width: 95px;

		> li {
			align-items: center;
			display: flex;
			gap: 3px;
			margin: 5px 0;
			padding: 4px;
			transition: 100ms;
			width: max-content;
		}

		> li:hover {
			cursor: pointer;
			transform: scale(1.01);
			text-decoration: underline;
			background-color: #2b2e33;
		}
	}
`;

export const FilterItem = styled.li`
	align-items: center;
	background-color: ${(props) => props.activeFilter};
	border: ${(props) => props.activeFilter};
	display: flex;
	gap: 3px;
	margin: 5px 0;
	padding: 4px;
	transition: 100ms;
	width: max-content;
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
