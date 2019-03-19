Feature: AddEducation
	In order to update my profile 
	As a skill trader
	I want to add the Education that I know
@mytag
Scenario: Check if user could able to add a education 
	Given I clicked on the education tab under Profile page
	When I add a new education
	Then that education should be displayed on my listings