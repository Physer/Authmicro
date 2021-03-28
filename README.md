# Authmicro
## Introduction
Authmicro is a demo application showcasing a potential authentication and authorization solution across Microservices from a Domain-Driven Design standpoint.

The demo consist out of 3 separate services.
* The Authentication API
* The Administration API
* The Forum API

## Table of contents
- [Authmicro](#authmicro)
  * [Introduction](#introduction)
  * [How does it work?](#how-does-it-work-)
  * [How to run](#how-to-run)
    + [Using Docker](#using-docker)
    + [Using Visual Studio](#using-visual-studio)
  * [Services](#services)
    + [Authentication API](#authentication-api)
      - [Description](#description)
      - [Endpoints](#endpoints)
    + [Administration API](#administration-api)
      - [Description](#description-1)
      - [Endpoints](#endpoints-1)
    + [Forum API](#forum-api)
      - [Description](#description-2)
      - [Endpoints](#endpoints-2)
  * [Users and roles](#users-and-roles)
  * [Contributing or ideas?](#contributing-or-ideas-)
  * [Contact me](#contact-me)

## How does it work?
Authmicro works by simulating a separate authentication service that is responsible for issuing tokens based on a user's credentials. Once a user has authenticated itself, the application is issued a token. This token can then be used to make calls to protected resources accordingly, providing the user has got the authorization to do so.

## How to run
There are currently two ways of running the applications.
Before choosing either path, make sure you either download or clone this Git repository

By default, the following host mappings are used:
| Service| Host | Port |
|--|--|--|
| Authentication API | localhost | 5001 |
| Administration API | localhost | 6001 |
| Forum API | localhost | 7001 |


### Using Docker
1. Make sure you have Docker and docker-compose installed
2. From the root folder of the Git repository, run **docker-compose up -d**
3. That's it! Your services are now running as containers according to the previously described mappings

### Using Visual Studio
1. Open and build the solution in Visual Studio
2. Start the desired project(s) in your desired configuration
3. By default, the Kestrel profiles (Project name in Debug toolbar) point to the previously mentioned ports

**Note**
If you choose to pick your own hostnames and ports, make sure your configuration across the solution is updated accordingly.  

## Services
### Authentication API
#### Description
The cornerstone of this application is the Authentication API. This API is solely responsible for generating secure access tokens based on a user's credential. In other words, you can consume this API by giving it a username and a password. In return you'll receive an access token.

The access token that you receive is only valid for a limited period of time and is tailored specific to your user. You can only use this access token for the sources your user has the correct rights to.
#### Endpoints
There is one endpoint available. Use this to authenticate your user credentials and try to receive an access token:

**URL**: `/users/authenticate`

**Method**: `POST`

**Request body** All fields are required
```json
{
"username":  "user.name",
"password":  "password",
"audience":  "desiredApiAccess"
}
```
**Field information**
|Field|Value  |
|--|--|
| username | This can be one of the users specified below  |
| password | The corresponding password |
| audience| The audience can either be 'Administration' or 'Forum'. Depending on your selected user, you may not have access |

**Success response**
Your response will contain an access token for your specified user.

*Condition*: The combination of the username, password and audience is correct
*Code*: 200 OK
*Content example*:
```json
{
"accessToken":  "eyJhbGciOiJIUzIj81NiIsInR5cCI6IkpXVCJ9.eyJz67dWIiOiJqb2huLmRvZSIsImV4cCI6MTYxNjg2OTcwMywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsIm90nmF1ZCI6IkFkbWluaXN0cmF0aW9uIiwicm9sZXMiOls0iQWRtaW5pc3RyYXRvciIsIlJlYWRlciJdfQ.ArM0TSTZNQFHqWpsOc_hb43Z67Sd0tZm90-0GTSFJT3K0L6c"
}
```
**Error responses**
*Condition*: The combination of the username, password and audience is correct
*Code*: 401 Unauthorized
*Content example*:
```json
{
"type":  "https://tools.ietf.org/html/rfc7235#section-3.1",
"title":  "Unauthorized",
"status":  401,
"traceId":  "00-53ee12ec0180934687fbb21d6893193d-9410cfa4913c394c-00"
}
```

*Condition*: Something went wrong unexpectedly
*Code*: 400 Bad Request
*Content example*:
```json
{
"type":  "https://tools.ietf.org/html/rfc7231#section-6.5.1",
"title":  "Bad Request",
"status":  400,
"traceId":  "00-a229a27be4dd7e4cbb4804bedd64052d-dae1fdfbece95941-00"
}
```

### Administration API
#### Description
The Administration API is a restricted API that can retrieve user data. In a real-life situation this could be an API giving administrators access to changing users, permissions or other sensitive data.
#### Endpoints
For the Administration API, there is one endpoint available. This endpoint allows you to query user data.

**URL**: `/administration/users`

**Method**: `GET`

**Headers** Authorization - Bearer xxxx

**Success response**
The response contains user information

*Condition*: The specified access token contains the correct credential data
*Authentication required*: **Yes**
*Code*: 200 OK
*Content example*:
```json
[
   {
      "id":1,
      "name":"Leanne Graham",
      "username":"Bret",
      "email":"Sincere@april.biz",
      "phone":"1-770-736-8031 x56442",
      "website":"hildegard.org",
      "address":{
         "street":"Kulas Light",
         "suite":"Apt. 556",
         "city":"Gwenborough",
         "zipcode":"92998-3874",
         "geo":{
            "lat":"-37.3159",
            "long":null
         }
      },
      "company":{
         "name":"Romaguera-Crona",
         "catchPhrase":"Multi-layered client-server neural-net",
         "bs":"harness real-time e-markets"
      }
   },
   {
      "id":2,
      "name":"Ervin Howell",
      "username":"Antonette",
      "email":"Shanna@melissa.tv",
      "phone":"010-692-6593 x09125",
      "website":"anastasia.net",
      "address":{
         "street":"Victor Plains",
         "suite":"Suite 879",
         "city":"Wisokyburgh",
         "zipcode":"90566-7771",
         "geo":{
            "lat":"-43.9509",
            "long":null
         }
      },
      "company":{
         "name":"Deckow-Crist",
         "catchPhrase":"Proactive didactic contingency",
         "bs":"synergize scalable supply-chains"
      }
   }
]
```



### Forum API
#### Description
The Forum API is responsible for retrieving forum posts. These posts can be viewed by any authenticated user with a reader role. The reader role is default role, any registered user should have this role.

#### Endpoints
One endpoint is available. To retrieve forum posts.
**URL**: `/posts`

**Method**: `GET`

**Headers** Authorization - Bearer xxxx

**Success response**
The response contain forum posts

*Condition*: The specified access token contains the correct credential data
*Authentication required*: **Yes**
*Code*: 200 OK
*Content example*:
```json
[
   {
      "userId":1,
      "id":1,
      "title":"sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
      "body":"quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
   },
   {
      "userId":1,
      "id":2,
      "title":"qui est esse",
      "body":"est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
   }
]
```
## Users and roles
In order to access the above mentioned endpoints and services, you'll need the required access. In order to simulate this, several (in-memory) users are available. An overview of the users and their roles follow.
| Username | Password  | Role(s) | Authorized for
|--|--|--|--|
| john.doe | password | Administrator, Reader | Administration, Forum
| jane.doe | b3tt3rp4ssw0rd | Reader | Forum

In other words, only John Doe can access both the Administration API and Forum API. Jane Doe can only access the Forum API.

If a token is requested for a user and the request made doesn't correspond with the access restrictions, the user will not able to consume the API endpoint.

## Contributing or ideas?
For all your issues, feature requests, bug reports, comments, questions and otherwise anything you'd like to mention, you can create a issue right here at Github!

Do you wish to contribute and improve this project? Please fork the Git repository and make a pull request! All input is welcome. :-)

## Contact me
Would you like to get in touch with me? You can send me an e-mail at alex_schouls@live.com.