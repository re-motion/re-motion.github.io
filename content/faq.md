# FAQ

re-motion Frequently Asked Questions

## What is re‑motion?

re‑motion is an open source framework to develop .NET enterprise applications. 

## What language is re‑motion written in?

re‑motion is implemented in C#. However, as it is developed using the .NET framework, it can be used from any .NET language.

## Is re‑motion open source software?

Yes. The re‑motion source code is dual‑licensed as open source as well as commercially.

## How is re‑motion different from ASP.NET?

ASP.NET is an all‑purpose, web application development framework, whereas re‑motion is a DDD framework with web components. Think of ASP.NET being a collection of bricks, mortar and builder’s tools (very flexible, but also low level) and re‑motion a collection of walls, staircases and office equipment complete with a doorman & a complete workforce, ready to get going.

## Where can I get re‑motion source code?

Please have a look on the download page on this site.

## Where can I find documentation on re‑motion?

Please look up our documentation page from this site. The docs in the community page shall provide an level 100 overview. If you get stuck, please do not hesitate to contact us.

## I want to contribute to re‑motion. What do I do?

There are several levels on which you can contribute: You can supply us with code which fixes a bug, for us to integrate, start your own contrib project, or implement something directly in the re‑motion framework. For the last point, for us to be able to include it directly into re‑motion, your code will need to adhere to the principles of [TDD](http://en.wikipedia.org/wiki/Test-driven_development).

## What do I need to use re‑motion?

To develop for re‑motion under Windows, you will need the following:

* Visual Studio 2010
* SQL Server 2008
* IIS 6/7.

## Does re‑motion run on Mono?

re‑motion is being developed with Mono compatibility in mind, however it is currently not tested under Mono on a regular basis.

## How mature is re‑motion?

re‑motion has been used in production at [rubicon](https://www.rubicon.eu) for years, for large and smaller projects. It powers a large variety of applications every day, from e‑government software to large scale enterprise applications. [rubicon](https://www.rubicon.eu)’s open source enterprise record management framework [Acta Nova](https://www.acta-nova.eu) (site in German) is also built on top of re‑motion.

## DDD – What does this abbrevations mean?

DDD is an approach that developers should concentrate on the domain logic, and not on implementation details. re-motion generates form‑driven ASP.NET web applications from (attribute‑qualified) C# classes representing your business objects, complete with persistence and security. So in general, a developer who creates his app with re-motion should not have to think how the data is stored to the database and in which controls the domain objects are displayed.