<h1 align="center">the-cat-api-client</h1>

<br/>

A REST client application for [The Cat Api](https://thecatapi.com/), it allows search for cat breeds and consult their respective images and some of the characteristics available by the API: origin, temperament and description of the breed. It is also possible to favorite and recover your favorite breeds. Built using .NET 5, Windows Forms and RestSharp.

# 📋 Prerequisites

To run the application on your local machine you will need to have installed the following tools:

- [.NET SDK 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [Visual Studio](https://visualstudio.microsoft.com/)

# 🔧 Install

Some of The Cat API resources require authentication via API Key, they are: Add, get, and delete favorites. To unlock such resources you will need to generate an API Key, to do that go to the official website and [signup](https://thecatapi.com/signup).

Once you have generated your API Key, simply create a .env file using .env.example as a template.

```sh
# Replace "YOUR_API_KEY" with your own
API_KEY=YOUR_API_KEY
```

# 🛠 Technologies 

- [.NET 5](https://dotnet.microsoft.com/en-us/) - Technology used to create the REST client application.
- [Windows Forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-6.0) - Technology used to create the structure and interface of the REST client application.
- [RestSharp](https://restsharp.dev/) - HTTP client library for API requests and responses.

# Author

Made with ❤️ by <a href="https://br.linkedin.com/in/thiago-santos-6b6624182" >Thiago Santos.</a>