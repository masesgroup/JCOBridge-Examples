## Scala to .NET Example
In this example we call .NET object from Scala language via JCOBridge.
Before call compile and execute batch script Scala [binaries](https://downloads.lightbend.com/scala/2.12.8/scala-2.12.8.msi) shall be installed.


```java
import java.util.Iterator
import org.mases.jcobridge._

object Main extends App {
  try
  {
    JCOBridge.Initialize("");
  }
  catch
  {
    // catch to avoid problem with Trial mode of JCOBridge
    case jce: JCException => System.out.println(jce.getMessage)
  }

  val bridge = JCOBridge.CreateNew()

  // adds a new reference to WPF 
  bridge.AddReference("PresentationFramework")
  // get MessageBox type
  val msgType = bridge.GetType("System.Windows.MessageBox")
  // invoke static method to show a message box on the screen
	msgType.Invoke("Show", "Please press enter to continue")

  // get .NET type
  val enumType = bridge.GetType("System.Environment")
  // invokes static method
	val genObj = enumType.Invoke("GetLogicalDrives")
  // retrieve the iterator
  val iteratorObj = genObj.asInstanceOf[JCObject].iterator
  // iterate on all object and print the value
  while (iteratorObj.hasNext) println(iteratorObj.next)

  // invoke static method to show a message box on the screen
	msgType.Invoke("Show", "Please press enter")

  // event callback example
  val tObj = bridge.NewObject("System.Timers.Timer"); // create the timer object
  val timerObj = tObj.asInstanceOf[JCObject];
  // register an event handler when the Timer elaps
  timerObj.RegisterEventListener("Elapsed", new ScalaJCVoidEventEmit()); 
  // set Interval property
  timerObj.Set("Interval", 1000); // set properties
  // enable the Timer
  timerObj.Set("Enabled", true); // start timer

  // invoke static method to show a message box on the screen
	msgType.Invoke("Show", "Please press enter")
}

final class ScalaJCVoidEventEmit() extends JCVoidEventEmit {
  override def EventRaised(args: Object*) : Unit =
  {
		// scala seems to have a problem to translate var args argument into JVM bytecode. This method is needed to avoid compilation problems
  }
  // this method defines exactly the signature expected from the event
  def EventRaised(sender: Object, arg: Object) : Unit =
  {
		println("Timer Elapsed")
  }
}
```