Feature: AddDescription
	In order to update my profile 
	As a skill trader
	I want to add my Description
@mytag
Scenario: Check if user could able to add a Description
	Given I clicked on the description tab under Profile page
	When I add a new description
	Then that description should be displayed on my listings
