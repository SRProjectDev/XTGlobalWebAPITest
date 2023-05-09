# XT Global API

# Description
In this Project, We have two API which is "GetAllFruits" and "FruitsByFamily" which is GET and POST respectively. 
So bascially we need to consume Fruityvice API and return their result using this two API.


# Project Structure
We have three Project which is - FruityviceAPI, XTGlobalWebAPI and XTGlobalWebAPITest.

FruityviceAPI project - consuming the API using IHttpClientFactory.

XTGlobalWebAPI - This is main project where we have our API.

XTGlobalWebAPITest - This is Unit Test Project, we have used NUnit.


# Implementation
We are using .Net Core Web API, which having inbuilt Dependency Injection implemented, so we take advantage of it. Also we have integrated swagger as well.

We have different model for our own API and third party API response model, so we have used Mapper to map the models.

Error Handling - We have used the global level exception filter to handle exception. Also have App Insight integrated with application to see logs and exception.
