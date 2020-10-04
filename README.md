# DocApi
Documents Api Sample
This is a sample code to create .Net Core Web API samlple with MongoDB Server 

MongoDB Server and Database Setup :

1 Download and install MongoDB from https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/

2 Add C:\Program Files\MongoDB\Server\<version_number>\bin to the Path environment variable

3 Choose a directory on your development machine for storing the data. For example, C:\DocumentsData on Windows
 
4 Open command prompt and run > mongod --dbpath C:\DocumentsData

5 Open another command prompt and run below:

 5.1 mongo

 5.2 use DocumentstoreDb

 5.3 db.createCollection('Documents')

 5.4 db.Documents.insertMany([{'Name':'Computer Graphics','Price':5.00,'Category':'Computers','Author':'Joe L'}, {'Name':'Microservices Architecture','Price':15.50,'Category':'Computers','Author':'C. Kevin'}])


Reference:

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio
