Feature: Elements 
    
    Scenario: Go to Element page
        Given Open the page for testing
        And user accepts cookies
        When user clicks 'Elements' button
        Then text for testing is visible
        
       Scenario Outline: Open tabs 
        Given Open the page for testing
        And user accepts cookies
        And user clicks 'Elements' button
        When user selects '<Category>' category
        And user selects '<Tabs>' tab
        Examples: 
        | Category                | Tabs            |
        | Elements                | Text Box        |
        | Forms                   | Practice Form   |
        | Alerts, Frame & Windows | Browser Windows |
        
    Scenario: User fills the form
        Given Open the page for testing
        And user accepts cookies
        And user clicks 'Elements' button
        And user selects 'Forms' category
        And user selects 'Practice Form' tab
        When user set 'QWERTY' to 'First Name' field in Form
        When user set 'YTREWQ' to 'Last Name' field in Form
        When user set 'qwerty@gmail.com' to 'Email' field in Form
        When user set '1234567890' to 'Mobile' field in Form
        When user set '19 Jun 2001' to 'Date Of Birth' field in Form
        When user set Gender to 'Male' in Form
        When user fill 'English' to Subject Field in Form
        When user upload an image in Form
        And user click submit button