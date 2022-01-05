// vitals
import styled from 'styled-components';

export const CharacterCardStyle = styled.div`
	align-items: flex-end;
	background-image: url(${(props) => props.imageURL});
	background-size: cover;
	border-radius: 8px;
	display: flex;
	height: 300px;
	margin: 1rem;
	width: 300px;

	.info-container {
		background-color: rgba(255, 255, 255, 0.3);
		color: #272727;
		font-family: 'Work Sans', sans-serif;
		font-size: 21px;
		font-weight: 600;
		border-radius: 0 0 8px 8px;
		width: 100%;
        padding: 0 0 5px 10px;
	}
`;
