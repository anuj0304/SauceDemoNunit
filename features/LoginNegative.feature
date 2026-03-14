@LoginNegative
Feature: Login Negative Scenarios
  As a user
  I should see error messages
  When I login with invalid credentials

  @WrongCredentials
  Scenario: Login with invalid username and password
    Given I attempt login with invalid credentials
    Then I should see an authentication error message

  @EmptyCredentials  
  Scenario: Login with empty username and password
    Given I attempt login with empty credentials
    Then I should see empty field error message
