import java.lang._

final class ScalaClass(aString: String, val anInteger: Int) {
    def this() {
        this("defaultString", -1)
    }

    def this(aBool: Boolean) {
        this("defaultString", -1)
    }

    val scalaString = "This is a Scala String"

    def add(x: Int, y: Int): Int = x + y

    def stringConcat(args: Array[String]): String = 
    {
        return args.mkString(", ")
    }
}