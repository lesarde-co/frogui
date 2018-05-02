# frog`ui`

## Wednesday, May 2, 2018 Notice
THIS IS UNDER DEVELOPMENT AND SHOULD BE READY WITHIN A DAY OR TWO. THE NUGET PACKAGE IS NOT MUCH USE WITHOUT INSTRUCTIONS.

## Introduction
**Frogui** is an proof-of-concept framework that allows developers familiar with C# and Visual Studio to build native client *web apps* using their existing skills, with no need to learn or use JavaScript or other web technologies. At the moment, it's very minimal, allowing the creation of lightweight [Console applications](https://docs.microsoft.com/en-us/dotnet/standard/building-console-apps).

Before talking about Frogui, some historical perspective is in order.

## The Past and Present
You may have used a technology that involved C# and .NET to create for the web in some form, but never to create a *native .NET web app*. For instance, [Silverlight](https://www.microsoft.com/silverlight/), a sentimental favorite, created web apps using C# and a lightweight .NET but ran in a browser plug-in; plug-ins are prehistoric in 2018, thanks to web ~~2.0~~, ~~3.0~~, whatever! You may use [ASP.NET](https://www.asp.net/) with [Razor](https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c) on the server-side to get many of the benefits of C#, .NET and Visual Studio but, alas, ultimately what runs in the browser is plain old web technology. Still yet, you may use [Typescript](https://www.typescriptlang.org/)  to get a pseudo-C# development experience sans .NET.

The obvious theme is *C# developers are clamoring ways to use their existing skills to build for the web*, and each of the aforementioned excellent technologies is proof. 

## The Future
Creating a native .NET web app has been a developer pipe dream. And it still is impossible *officially*, but unofficially the future is open for business, thanks to the immensely exciting new [WebAssembly](https://developer.mozilla.org/en-US/docs/WebAssembly) standard and Microsoft's newfound commitment to see C# and .NET Standard run everywhere, including the web via the experimental [mono-wasm](http://www.mono-project.com/news/2018/01/16/mono-static-webassembly-compilation/) project.

WebAssembly is already being exploited by [C++](http://webassembly.org/docs/c-and-c++/) and [Rust](https://github.com/rust-lang-nursery/rust-wasm) developers, resulting in native browser apps performing on par with their non-browser counterparts, all while completely bypassing JavaScript, thank you very much. Because the C#'s and Java's of the world require a garbage-collected runtime environment, they are lagging behind for now but, before too long, will be commonplace.

Fortunately, Microsoft's commitment to allowing C# and .NET to run natively in the browser is serious. Consider, [Blazor](https://github.com/aspnet/Blazor), an "*experimental .NET web framework using C#/Razor and HTML that runs in the browser via WebAssembly*." Don't be thrown by the "Razor" reference; Blazor *is not* ASP.NET or server-side, it uses the Razor parser to do for code that runs in the client what ASP.NET does to code on the server.

Less well known, but worth mentioning is the recently created open source [Ooui](https://github.com/praeclarum/Ooui) project by Frank Krueger. Ooui and Frank's input was instrumental in putting together Frogui, though Frogui does not use Ooui since the goals differ.

## Using Frogui
Frogui is built on top of WebAssembly and mono-wasm, though besides adding the nuget package, these do not need to be added since WebAssembly is built into the browser and the mono-wasm bits are including in the package.

^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

~~~~continue here

What makes this particularly exciting is the code runs *natively* in the browser, all with the nearly the ease of the "F5" experience.

Given that there are already a variety of ways to get C#
 which is already widely supported in desktop and mobile browsers (save Internet Explorer)

 - List item

 , and Microsoft's newfound commitment to see C# and .NET Standard run everywhere

 that is already available 
 The goal is to maintain the "F5"
