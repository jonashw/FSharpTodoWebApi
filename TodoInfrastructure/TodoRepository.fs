namespace TodoInfrastructure

open TodoDomain

type TodoRepository() =
    static let mutable todos: Todo list = 
        [
            { Id = 1; Label = "Milk";         Done = true };
            { Id = 2; Label = "Oatmeal";      Done = false };
            { Id = 3; Label = "Orange Juice"; Done = false };
            { Id = 4; Label = "Lucky Charms"; Done = false };
        ]

    interface ITodoRepository with
        member this.GetAll() : Todo list = todos

        member this.TryFind(id: int) : Todo option = 
            todos |> List.tryFind (fun t -> t.Id = id)
            
        member this.Add(todoLabel: string) : Todo =
            let newTodo = {
                Id = todos.Length + 1;
                Label = todoLabel;
                Done = false }
            todos <- todos @ [newTodo]
            newTodo

        member this.Update (todo : Todo): bool =
            let (newTodos, success) = 
                List.foldBack
                    (fun x (xs,updated) ->
                        if x.Id = todo.Id
                        then (todo :: xs, true)
                        else (x :: xs, updated)) 
                    todos
                    ([], false)
            todos <- newTodos
            success