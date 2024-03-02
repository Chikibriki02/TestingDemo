Feature: API Tests

@ignore
	Scenario: Generate Token
	Given Create user via API
	Given Generate Token
	Given Authorize user
	Given Get info for user
	When delete user

Scenario: Create User
	Given Create user via API
	Given Generate Token
	Given Authorize user

Scenario: Get list of Books
	When Send a request to get list of books
	Then Status code is '200'
	And Response contains a list of books