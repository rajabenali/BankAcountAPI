Bank account kata API
=================

Think of your personal bank account experience. When in doubt, go for the simplest solution

 

Requirements
------------

·         Deposit and Withdrawal

·         Account statement (date, amount, balance)

·         Statement printing

 

User Stories
------------

US 1:
In order to save money

As a bank client

I want to make a deposit in my account

US 2:
In order to retrieve some or all of my savings

As a bank client

I want to make a withdrawal from my account

US 3:
In order to check my operations

As a bank client

I want to see the history (operation, date, amount, balance) of my operations


## Run the sample locally
### Requirements
1 - Visual studio installed
2 - .Net CORE 5.0 installed
3 - Mysql SGBD

### Generation de la base de donnée
This project uses Entity Framework core code first approach
To create the database:			
		1- Go to appsetting.development.json and set your ConnectionString 
		2- In Package Manager console, run update-database

### Testing with Swagger 
Run the project and go to https://localhost:44367/swagger/index.html to test the API
