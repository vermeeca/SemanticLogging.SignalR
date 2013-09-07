#SemanticLogging.SignalR
SemanticLogging.SignalR is a sink for the [Semantic Logging Application Block](http://blogs.msdn.com/b/agile/archive/2013/02/07/embracing-semantic-logging.aspx) that exposes [Event Source](http://msdn.microsoft.com/en-us/library/system.diagnostics.tracing.eventsource.aspx) events to a client via SignalR.

This can be useful to be able to be able to take a look at a live application and see, in real time, the activity therein.

For an example, visit [http://slabsignalrdemo.azurewebsites.net/](http://slabsignalrdemo.azurewebsites.net/).  This site is a simple demo of the sink that outputs EventSource logging to the browser.

In addition to showing the EventSource logging directly in the browser, you also can run the ConsoleClient application under the Samples folder.  This application also receives all of the EventSource logging from the site.
