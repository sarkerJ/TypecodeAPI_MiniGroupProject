# TypecodeAPI Mini Group Project
## Project Goal

The goal of this project was to create a comprehensive and thorough test framework for an API of our choosing. We chose the Typecode API, which is a straightforward API that mocks the response from a typical API without changing any resources on the server-side. This has the benefit of allowing us to test the GET, POST, PUT and DELETE HTTP verbs without needing to worry about the effects of requests persisting over the server lifetime.

## Project Definition of Done

- [ ] All of the user stories are marked as Done
- [ ] Documentation has been updated
- [ ] The product backlog has been updated
- [ ] All the unit tests pass
- [ ] The deliverable has been reviewed and approved
- [ ] Final deliverable completed by 05/02/2021 10:30am

## Framework

The structure of the framework is governed by APIRunners which get called by the service class to create the HTTP request using RestClient, and then execute that request before handling the response as a string. This response then gets passed back up to service to be deserialised into the appropriate DTO, depending on the endpoint being queried. The APIRunner hierarchy consisted of an IAPIRunner interface as the parent which was injected into the service, ensuring that dependency injection was adhered to. Deserialisation of the results into a DTO allowed for straightforward testing of the framework since it was trivial to check the response data from the request.

A simple utilities class was added for the users endpoint, whose purpose was to provide methods for performing queries on the list of all users, obtained when sending a GET request to the ".../users" URL.

## Testing

The testing of the created framework was focused on ensuring a comprehensive test coverage of the GET, POST, PUT and DELETE HTTP verbs for each endpoint, with careful consideration given to the scenarios in which requests would fail e.g. an incorrect resource ID was given.

## Sprint Review

## Sprint Retrospective

One of the key things that can be taken away from this project is an appreciation for how a well-structured framework can make the testing of a framework very straightforward. By adhering to object oriented principles, we minimised any code repeatibility (for example through inheritance of a base runner class), and dependency injection ensured the framework was as loosely-coupled as possible. By keeping a clear separation of concerns between the APIRunner and the service class, scalability of the framework was optimised and the single responsibility principle was not violated.


