Feature: AddCertification
	In order to update my profile 
	As a skill trader
	I want to add the Education that I know
@mytag
Scenario: Check if user could able to add a certification
	Given I clicked on the certification tab under Profile page
	When I add a new certification
	Then that certification should be displayed on my listings