The project originated from a real need to access product prices in supermarkets without leaving home. I developed a robust application in C#, utilizing the development of a Web API, a web scraping service, Entity Framework libraries, 
and SQL Server to store all the collected data.

The main idea of the project is to provide users with the ability to conveniently check product prices and daily promotions. Although the use of OCR for reading flyers was initially considered, I opted to use the supermarkets' own websites, 
extracting prices directly via the XPath of products on their web pages. As a result, I created an API that sends this data directly to the database, with plans to connect it to a frontend in the future.

The frontend will allow users to enter the name of a product and get its current price, along with other functionalities, such as querying a list of products to return the total value.
This project is being developed by Miguel Bacellar with the intention of addressing a real demand, anticipating technological advancements, and meeting the needs of consumers who seek convenience and savings when shopping.
