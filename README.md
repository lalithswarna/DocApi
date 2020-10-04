# DocApi
Documents Api Sample
This is a sample code to create .Net Core Web API samlple with MongoDB Server 

MongoDB Server and Database Setup :
Download and install MongoDB from https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/
Add C:\Program Files\MongoDB\Server\<version_number>\bin to the Path environment variable
Choose a directory on your development machine for storing the data. For example, C:\DocumentsData on Windows
Open command prompt and run > mongod --dbpath C:\DocumentsData
Open another command prompt and run below:
mongo
use DocumentstoreDb
db.createCollection('Documents')
db.Documents.insertMany([{'Name':'Computer Graphics','Price':5.00,'Category':'Computers','Author':'Joe L'}, {'Name':'Microservices Architecture','Price':15.50,'Category':'Computers','Author':'C. Kevin'}])

Reference:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio
