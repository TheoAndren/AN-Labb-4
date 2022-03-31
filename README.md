Get all people in the Database

https://localhost:44385/api/person
-------------------------------------------------------------------------------------

Get all interests thats connected to ONE person 

https://localhost:44385/api/interest/person2
------------------------------------------------------------------------------

Get all websites thats connected to ONE person 

https://localhost:44385/api/website/person2
-------------------------------------------------------------------------------------------------

Connect a person to a new interest 

https://localhost:44385/api/interest/person2    // Connects person with id 2 to a new interest

{ "interestTitle": "Golf", "description": "Golf is played outside and you use a ball and clubs"}
------------------------------------------------------------------------------------


Add new links for a specific person and a specific interest 

https://localhost:44385/api/website/person3interest4  // adds a new website link to person with id 3 and interest id 4

{"link": "https://www.nhl.com" }
-------------------------------------------------------------------------------------
