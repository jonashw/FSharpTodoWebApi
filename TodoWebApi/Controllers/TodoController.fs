namespace TodoWebApi.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open TodoDomain
open TodoDependencyResolution

type TodoController() =
    inherit ApiController()

    let svc = Resolver.GetService()

    [<HttpGet>]
    member x.Get() = svc.GetTodos()

    [<HttpGet>]
    member x.Add([<FromUri>] label: string) = 
        let todo = svc.AddTodo(label)
        sprintf "Thanks for the new todo: %A" todo

    [<HttpGet>]
    member x.MarkDone(id: int) = svc.MarkDone(id)