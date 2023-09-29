Feature: API_RickAndMorty_Characters

@mytag
Scenario Outline: TC_1_Characters - Basic Details of Characters by ID
	Given We make a GET request for character <id> 
	When We receive a response
	Then The associated values for the character match the following '<id>' '<name>' '<status>' '<species>' '<gender>'

	Examples: 

	| id | name         | status | species | gender |
	| 1  | Rick Sanchez | Alive  | Human   | Male   |
	| 2  | Morty Smith  | Alive  | Human   | Male   |