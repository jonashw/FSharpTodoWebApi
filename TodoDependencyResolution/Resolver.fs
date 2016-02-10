namespace TodoDependencyResolution
open TodoDomain
open TodoInfrastructure

type Resolver = 
    static member GetService() = new TodoService(new TodoRepository())