# Summary

Here are some examples of how to use the [Dejavu](https://github.com/zhongjie-cai/dejavu) library for recording / replaying code.

## [Web App](./WebApp)

This example shows how to configure an AspNetCore web application using Dejavu with HttpContextProvider.

Use [Postman](https://www.postman.com/) or other API testing tool to play with the hosted application:

- for recording, provide any non-empty text value in the request header with name "dcir"; all recordings are stored in the response headers of the web request with name prefix "dcec-"
- for replaying, provide any non-empty text value in the request header with name "dcip", as well as the headers with name prefix "dcec-" from previous a recording

## [Console App](./ConsoleApp)

This example shows how to configure a console application using Dejavu with FileContextProvider.

Use any commandline prompt tool, e.g. [PowerShell](https://docs.microsoft.com/en-us/powershell/), to play with the application:

- for recording, provide "r" as the first argument (mandatory) and any non-empty text value as the second argument (optional as file name)
- for replaying, provide "p" as the first argument (mandatory) and optionally the file name as the second argument if specified
