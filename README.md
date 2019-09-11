# Manao.Warehouse.Management.Service

# What we implement here.
- MongoDB integration: specified MongoDB port and db's name on web.config
- Ready-to-use service with an automatically database creation: since a deployer has specified a correct MongoDB configure, the whole database with its collection and fields will be created along with a creation of the 1st POST API call is requested, in-case if there's no collection/data has been yet created, empty list will be returned '[]'.
- Viewmodel layer cut-off: ability to directly passing a primary class to an API's JSON output.
- DTO layer cut-off: specific returning JSON field by passing '?field={field1,field2}' on a query string.
- Unit test: with 100% skeleton covered and ready-to-extend.
- Asynchronous Logging with Log4Net: Log every request and response when an API is called.
- Generic repository: Covered get(), create(), update(), delete() without an extra  implementation. (you may need an extra implement on a business logic layer)
- MS IoC Unity integration: Use the Unity IoC framework directly from Microsoft so we don't need to worry about an update of the .NET and 3rd party confliction anymore.
- Swagger: Integrated!.

# How to run
* Pull the project.
* Rebuild the project to execute an automatically nu-get preparation.
* Make sure if the MongoDB is installed on your machine.
* Specified MongoDB route and port on the project's web.config.
* Run the project.
# To create your first record e.g. item.
- POST '/api/items' to create a new item
- GET '/api/items' to get 'ALL' items
- GET '/api/items/{id}' to get a specific item.
- PUT '/api/items/{id}' to update a specific item.
- DELETE '/api/items/{id}' to delete a specific item.
- These logics are apply to an all implemented routes.
