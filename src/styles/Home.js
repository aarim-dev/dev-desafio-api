// vitals
import styled from 'styled-components';

export const CardsContainer = styled.section`
	display: flex;
	flex-flow: row wrap;
	justify-content: center;
	margin: auto;
	width: 95%;
`;

export const PaginationContainer = styled.div`
	color: #fff;
	display: flex;
	margin: auto;

	> ul {
		display: flex;
		list-style-type: none;
		gap: 3px;
		font-family: 'Poppins', 'sans-serif';
	}

	li {
		border: 1px #fff solid;
		padding: 4px;
	}

	li:nth-child(2) {
		width: 25px;
		text-align: center;
		font-weight: bold;
	}

	li:hover {
		cursor: pointer;
	}
`;
