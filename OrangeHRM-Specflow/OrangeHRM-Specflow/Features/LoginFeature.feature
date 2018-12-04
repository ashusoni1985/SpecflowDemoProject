Feature: LoginFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Validate the Login functionality when user enter invalid credentials 
Given I am at login page
And Page load successfully
When I enter invalid user name and password
And Click on Login button 
Then Application shouuld display an error message


Scenario: Validate the Login functionality when user enter valid credentials 
Given I am at login page
And Page load successfully
When I enter valid user name and password
And Click on Login button 
Then user must navigate to Dashboard




Scenario: Validate the Login functionality when user enter valid User name and invalid password 
Given I am at login page
And Page load successfully
When I enter valid valid user name and invalid password
And Click on Login button 
Then Application shouuld display an error message




