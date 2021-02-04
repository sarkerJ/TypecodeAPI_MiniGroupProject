# TypecodeAPI_MiniGroupProject
**Project Goal**

The goal of this project was to create a comprehensive and thorough test framework for an API of our choosing. We chose the Typecode API, which is a straightforward API that mocks the response from a typical API without changing any resources on the server-side. This is beneficial because it allowed us to test the GET, POST, PUT and DELETE HTTP verbs without needing to worry about the effects of requests persisting over the server lifetime.

**Framework**

The structure of the framework is governed by APIRunners which get called by the service class to create the HTTP request using RestClient, and then execute that request before handling the response as a string. This response then gets passed back up to service to be deserialised into the appropriate DTO, depending on the endpoint being queried. The APIRunner hierarchy consisted of an IAPIRunner interface as the parent which was injected into the service, ensuring that dependency injection was adhered to. Deserialisation of the results into a DTO allowed for straightforward testing of the framework since it was trivial to check the response data from the request.

**Sprint Review**

**Sprint Retrospective**
