namespace TodoDomain

type UpdateResult =
    | Success of Todo list
    | Failure of string

type TodoService(repo : ITodoRepository) = 
    let setDone(id: int, isDone: bool): UpdateResult =
        match (repo.TryFind id) with 
        | Some todo -> 
            let updatedTodo = {todo with Done = isDone}
            if repo.Update updatedTodo
            then Success <| repo.GetAll()
            else Failure "Failed to update"
        | None -> Failure "Not found"

    member this.GetTodos() = repo.GetAll()
    member this.AddTodo(todoLabel: string) = repo.Add todoLabel
    member this.MarkDone(id: int) = setDone(id,true)
    member this.MarkNotDone(id: int) = setDone(id,false)
