@UI
Feature: Alerts

    Scenario Outline:Alert is visible
        Given Open the page for testing
        And user accepts cookies
        And user clicks 'Elements' button
        And user selects 'Alerts, Frame & Windows' category
        And user selects 'Alerts' tab
        When user clicks '<ButtonName>' button
        Then alert is visible
        Examples: 
        | ButtonName                                         |
        | Click Button to see alert                          |
        | On button click, alert will appear after 5 seconds |
        | On button click, confirm box will appear           |
        | On button click, prompt box will appear            |

    Scenario Outline: Confirm/Cancel Alert
        Given Open the page for testing
        And user accepts cookies
        And user clicks 'Elements' button
        And user selects 'Alerts, Frame & Windows' category
        And user selects 'Alerts' tab
        When user clicks 'On button click, confirm box will appear' button
        And alert is visible
        And User click to '<AlertButton>' alert
        Then user selected '<AlertAction>'
        Examples: 
        | AlertButton | AlertAction         |
        | OK          | You selected Ok     |
        | Cancel      | You selected Cancel |