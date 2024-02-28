Feature: API Tests

	Scenario: Generate Token
	Given Create user via API
	Given Generate Token
	Given Authorize user
	Given Get info for user
	When delete user