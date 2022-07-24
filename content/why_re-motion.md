# Why re-motion

## Focus on the domain

Software development is expensive. Many companies cut their budgets for IT even if there are ongoing requests for new software. The remaining budget is probably spent much on maintenance of existing old software.

The little money available has to be spent carefully, even though there is a huge demand for new business application in that company. There is probably money for one or two projects. The rest has to wait.

As an external software developer or company, you want to get these projects. You deliver your proposal with all the rich stuff, you consider essential. Rich UI, optimized database access, etc. You are prepared to optimize every part of the software to your client needs.

If your clients often do not sign the contract, consider the thought:

Car maintenance is expensive. Most readers of this page will probably have spent a lot of money in car repair shop. Sometimes maybe more than expected. They know exactly how it feels to leave the car repair shop with some hundred dollars or euros less.

Looking on the bills, we sometimes discover order items that were only needed indirectly to fix the car. For example, if we want to fix a scratch in the paint of a car, someone has to prepare the paint. And he has to remove the part of the car to be painted from the car to get started. The real fix, the painting, is probably only a small part of the bill. We pay a lot for preparing the color, removing the part with the scratch from the car, put this part somewhere and add this part to the car again.

Have you experienced the pain to pay the mechanics hours and hours for “supportive tasks”? Then why do you think your customer wants to pay for “supportive tasks”

The customer does not want to pay us to write select statements, consider transaction strategies in detail or designing a GUI. What he expects to pay is the work to be done in the business logic.

And that is where re-motion fits in: It is a DDD framework. To use it, you have to focus on the domain. Implementation details – those parts that the customer probably does not want to pay – are parts of the framework.

## Closing the Gap between fast prototypes and maintainable code

In the 90ties there was the idea of RAD (rapid application development). The basic idea was: With new designers it is possible to create prototytpes with masks fast. The customer can approve that we are right (or wrong) and once the UI is okay, the rest shall be okay too.

The real problem with RAD was that the customer thought that the application was about to be finished when he saw the prototyp.

re-motion is different. You create your domain and generate databases and forms. You might want to adapt some forms, but what is done, is done.

## Built-In Security

Security is built into every layer of re-motion. The database and UI abstractions prevent technical attacks like SQL injection or cross-site scripting. Authorization is respected in every layer: The UI can automatically decide that certain data fields should be invisible or read-only, or certain menu items or links should not be displayed depending on a user’s permissions. In case a user tries to circumvent these measures using forged HTTP requests, everything will be checked again on the application server.

An application can provide its own authorization logic or use the ACL-based authorization system of re-strict.

## Integration and Modularization

The architecture of re-motion is componentized and pluggable. If a certain feature needs adaptions, you can easily plug your code in to assemble it in a slightly different manner. For instance: The data-binding components are not bound to re-motion’s O/R mapper, but an adapter provides additional information from the O/R mapping definition to the UI. If you decide to bring your own O/R mapper or use some other data access paradigm, you can use a generic adapter for .NET objects (POCOs) or provide your own adapter to expose additional information. 