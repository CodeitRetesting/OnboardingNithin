Feature: AddSkillFeature
	In order to update my profile 
	As a skill trader
	I want to add the Skills that I know
@mytag
Scenario: Check if user could able to add a skill 
	Given I clicked on the Skill tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings