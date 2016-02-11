namespace TodoDomain

type UpdateResult =
    | Success of Todo list
    | Failure of string

type TodoService(repo : ITodoRepository) = 
    let update(id: int, transformer: (Todo -> Todo) ): UpdateResult =
        match (repo.TryFind id) with 
        | Some todo -> 
            if transformer(todo) |> repo.Update
            then Success <| repo.GetAll()
            else Failure "Failed to update"
        | None -> Failure "Not found"

    let setDone(id: int, isDone: bool): UpdateResult =
        update(id, fun todo -> {todo with Done = isDone})

    member this.GetTodos() = repo.GetAll()
    member this.AddTodo(todoLabel: string) = repo.Add(todoLabel)
    member this.MarkDone(id: int) = setDone(id,true)
    member this.MarkNotDone(id: int) = setDone(id,false)
    member this.ReLabel(id: int, label: string) = 
        update(id, fun todo -> {todo with Label = label})
