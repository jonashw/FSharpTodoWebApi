namespace TodoDependencyResolution
open TodoDomain
open TodoInfrastructure

type Resolver = 
    static member GetService() : TodoService = new TodoService(new TodoRepository())