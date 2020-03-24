Public Class VBClass
    '<summary>The method <c>HelloWorld</c> return the "Hello World!!" string</summary>
    Public Function HelloWorld() As String
        Return "Hello World from C#!!"
    End Function

    '<summary>The method <c>Add</c> return the sum of two double</summary>
    Public Function Add(a As Double, b As Double) As Double
        Return a + b
    End Function


    '<summary>The method <c>Add</c> return the sin of a double</summary>
    Public Function Sin(a As Double) As Double
        Return Math.Sin(a)
    End Function

End Class
