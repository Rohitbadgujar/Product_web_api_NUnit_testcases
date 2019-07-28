# Product_web_api_NUnit_testcases
Creating Product web api with NUnit_testcases in .Net Core 2.1

 ## Name – Rohit Badgujar			             			Date   28/July/2019
 Platform Used: ## MS Visual Studio Community 2019 Version 16.1.1
 Database Used: InMemory 
 
 Github Repository Link: 
 	https://github.com/Rohitbadgujar/Product_web_api_NUnit_testcases
	
 ## API is built in C# .Net Core 2.1 

## 1.	How to run the application:

	Open cmd -> go to project directory -> dotnet build 
	 	 			    ->  dotnet run
or
Open project in Visual Studio -> Cntrl+ f5 
To run test cases -> Test -> Run -> All Test case

## 2.	Functionality:

Made Product {ID, Name, Description} fields mandatory using Data annotation.

### i.	Get All products [HTTPGET]

	https://localhost:5001/api/WebApiProduct/getproduct

### ii.	Delete product by Id [HTTPDELETE]

	https://localhost:5001/api/WebApiProduct/deleteproductbyId/{productId}
	
	ex. https://localhost:5001/api/WebApiProduct/deleteproductbyId/2

### iii.	Get Product with specific ID [HTTPGET]
	
	https://localhost:5001/api/WebApiProduct/getproduct/{productId}
	
	ex.  https://localhost:5001/api/WebApiProduct/getproduct/3

### iv.	Update Product by Id [HTTPPUT]
	
	https://localhost:5001/api/WebApiProduct/updateproduct/{productId} and JSON Data to be updated
	
	https://localhost:5001/api/WebApiProduct/updateproduct/10 & JSON 
	
	```data  {
        "id": 10,
        "name": "updated Orange Juice",
        "description": "Juice made of fresh Oranges"}
	```

### v.	Add new product [HTTPPUT]

	https://localhost:5001/api/WebApiProduct/insertproduct
	
	JSON 
	```data  {
        "id": 12,
        "name": "Cheese Cake",
        "description": "Fresh Cheese Cake"}
	```
	
### vi.	Get Count of all products and products on the requested page

	https://localhost:5001/api/WebApiProduct/getpagelist/{page}/{pagesize}

	e.x https://localhost:5001/api/WebApiProduct/getpagelist/3/5 

API is tested using NUnit Test cases for various methods and HTTP requests 
NUnit Test Project – NunitTestWebApi

### Solution is also tested using the application Postman



