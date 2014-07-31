namespace Make10

module Main =
    type Result =
    | Success of int * string
    | Failure of string
        member self.Symbol =
            match self with
            | Success(i, s) -> s
            | Failure(s)    -> s

    type InterimResult =
    | Infinity of string
    | NotInteger of float * string
    | Integer of float * string

    let make10Async (x: float) (y: float) (z: float) (w: float) =
        let computeAsync (f: unit -> float * string) =
            async {
                let computed, symbols = f()
                let result =
                    if System.Double.IsInfinity(computed) then Infinity(symbols)
                    elif (float (int computed)) = computed then Integer(computed, symbols)
                    else NotInteger(computed, symbols)
                return result
            }
        [
            fun () -> (x + y + z + w, "+++")
            fun () -> (x + y + z - w, "++-")
            fun () -> (x + y + z * w, "++*")
            fun () -> (x + y + z / w, "++/")
            fun () -> (x + y - z + w, "+-+")
            fun () -> (x + y - z - w, "+--")
            fun () -> (x + y - z * w, "+-*")
            fun () -> (x + y - z / w, "+-/")
            fun () -> (x + y * z + w, "+*+")
            fun () -> (x + y * z - w, "+*-")
            fun () -> (x + y * z * w, "+**")
            fun () -> (x + y * z / w, "+*/")
            fun () -> (x + y / z + w, "+/+")
            fun () -> (x + y / z - w, "+/-")
            fun () -> (x + y / z * w, "+/*")
            fun () -> (x + y / z / w, "+//")
            fun () -> (x - y + z + w, "-++")
            fun () -> (x - y + z - w, "-+-")
            fun () -> (x - y + z * w, "-+*")
            fun () -> (x - y + z / w, "-+/")
            fun () -> (x - y - z + w, "--+")
            fun () -> (x - y - z - w, "---")
            fun () -> (x - y - z * w, "--*")
            fun () -> (x - y - z / w, "--/")
            fun () -> (x - y * z + w, "-*+")
            fun () -> (x - y * z - w, "-*-")
            fun () -> (x - y * z * w, "-**")
            fun () -> (x - y * z / w, "-*/")
            fun () -> (x - y / z + w, "-/+")
            fun () -> (x - y / z - w, "-/-")
            fun () -> (x - y / z * w, "-/*")
            fun () -> (x - y / z / w, "-//")
            fun () -> (x * y + z + w, "*++")
            fun () -> (x * y + z - w, "*+-")
            fun () -> (x * y + z * w, "*+*")
            fun () -> (x * y + z / w, "*+/")
            fun () -> (x * y - z + w, "*-+")
            fun () -> (x * y - z - w, "*--")
            fun () -> (x * y - z * w, "*-*")
            fun () -> (x * y - z / w, "*-/")
            fun () -> (x * y * z + w, "**+")
            fun () -> (x * y * z - w, "**-")
            fun () -> (x * y * z * w, "***")
            fun () -> (x * y * z / w, "**/")
            fun () -> (x * y / z + w, "*/+")
            fun () -> (x * y / z - w, "*/-")
            fun () -> (x * y / z * w, "*/*")
            fun () -> (x * y / z / w, "*//")
            fun () -> (x / y + z + w, "/++")
            fun () -> (x / y + z - w, "/+-")
            fun () -> (x / y + z * w, "/+*")
            fun () -> (x / y + z / w, "/+/")
            fun () -> (x / y - z + w, "/-+")
            fun () -> (x / y - z - w, "/--")
            fun () -> (x / y - z * w, "/-*")
            fun () -> (x / y - z / w, "/-/")
            fun () -> (x / y * z + w, "/*+")
            fun () -> (x / y * z - w, "/*-")
            fun () -> (x / y * z * w, "/**")
            fun () -> (x / y * z / w, "/*/")
            fun () -> (x / y / z + w, "//+")
            fun () -> (x / y / z - w, "//-")
            fun () -> (x / y / z * w, "//*")
            fun () -> (x / y / z / w, "///")
        ]
        |> Seq.map computeAsync
        |> Async.Parallel
        |> Async.RunSynchronously

    let make10 (tpl : int * int * int * int) =
        let xi, yi, zi, wi = tpl
        let x, y, z, w = (float xi, float yi, float zi, float wi)
        make10Async x y z w
        |> Array.map
            (function
                | Integer(c, s) when c = 10.0                    -> Success(int c, s)
                | Integer(_, s) | NotInteger(_, s) | Infinity(s) -> Failure(s))
        |> Array.filter
            (function
                | Success(i, s) -> true
                | _             -> false)
        |> Array.map (fun r -> r.Symbol)
