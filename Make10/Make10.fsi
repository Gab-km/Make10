namespace Make10
    module Main =
        type Result =
            | Success of int * string
            | Failure of string
        val make10 : (int * int * int * int) -> string []
