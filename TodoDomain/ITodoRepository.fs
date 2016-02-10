namespace TodoDomain

type ITodoRepository =
    abstract member TryFind : int -> Todo option
    abstract member GetAll : unit -> Todo list
    abstract member Add: string -> Todo
    abstract member Update : Todo -> bool
