Feature: LogoutFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Validate the pop up menu displayed when user click on Welcome text
Given I am at Dashboard page
And Dashboard Page load successfully
When I click on Welcome Text from the top right 
Then Pop up sub menu displayed


Scenario: Validate the click functionality of About pop up sub menu
Given I am at Dashboard page
And Dashboard Page load successfully
When I click on Welcome Text from the top right
And select About from pop up sub menu
Then About Pop up should be displayed


Scenario: Validate the click functionality of Logout pop up sub menu
Given I am at Dashboard page
And Dashboard Page load successfully
When I click on Welcome Text from the top right
And select Logout from pop up sub menu
Then user must navigate to Login screen


