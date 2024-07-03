ASP.NET Core offerrs 6 middleware methods (Use, UseMiddleware, Run, Map, and MapWhen) provide flexibility in handling HTTP requests and responses.

Understanding these methods allows you to build complex request processing pipelines tailored to your application's needs:

**Use**: For adding inline middleware with a next delegate.

**UseMiddleware**: For adding middleware classes.

**Run**: For adding terminal middleware that doesn't call the next middleware.

**Map**: For branching the pipeline based on request paths.

**MapWhen**: For conditionally branching the pipeline based on a predicate.
