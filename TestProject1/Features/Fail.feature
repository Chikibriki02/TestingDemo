   Feature: Fail

   Scenario: Go to Element page
        Given Open the page for testing
        And user accepts cookies
        When user clicks 'Elements' button
        Then text for testing is visible