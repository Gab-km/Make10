# Make 10

Make10 is to solve the game whose name is 'Make 10'.

## Rule

This game's rule is following:

1. There are 4 digits, usually from 0 to 9.
2. These digits keeps their order, and they have spaces between each of them.

```
ex) 9 5 3 1
```

3. You can put operators of four arithmetic operations -- '+', '-', '*' and '/' -- on the spaces.

```
ex) 9+5-3*1
```

4. When you make 10 with these 4 digits and 3 arithmetic operatiors, you win this game.

```
ex) 9+5-3-1 = 10
```

## Usage of Make10

```fsharp
open Make10

Main.make10 (9, 5, 3, 1)
//=> [|"+--"|]

Main.make10 (7, 7, 2, 5)
//=> [|"-+*"; "/**"|]
```

## Copyright and License

This software is distributed under the [MIT License](http://opensource.org/licenses/mit-license.php). See also [here](https://github.com/Gab-km/Make10/blob/master/LICENSE.txt).
