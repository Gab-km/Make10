namespace Make10Test

open FsCheck
open NUnit.Framework
open Make10

[<TestFixture>]
module Make10Testing =
    [<Test>]
    let ``All 0 cannot make 10`` () =
        Assert.IsEmpty(Make10.Main.make10 (0, 0, 0, 0))

    [<Test>]
    let ``Any 4 integers without 0 can make 10 with 1 pattern`` () =
        // This test is only to learn FsCheck and this will fail. :-)
        let filteredInput =
            Gen.choose (1, 9)
            |> Gen.four
            |> Arb.fromGen
        let make10with1pattern (x: int, y: int, z: int, w: int) =
            let result = Make10.Main.make10 (x, y, z, w)
            result.Length = 0 || (Array.forall (fun (s: string) -> s.Contains("+")) result)
        let property = Prop.forAll filteredInput make10with1pattern
        Check.Quick property