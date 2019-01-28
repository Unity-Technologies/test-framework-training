# test-framework-training
## Exercise 1 - Scene content

Write an EditMode test that verifies the content of the ball scene.
* Load the scene.
* Enter into Playmode.
* Verify the ball is there.
* Verify that the ball has the BallControl script assigned to it.

## Exercise 2 - Swap materials

Write a test that verifies the functionality of SwapMaterial on the ball control.
* To interact with the ball control, it needs to be assigned to a game object.
* The game object will need a renderer (you can create object using GameObject.CreatePrimitive).
* The SwapMaterial method interacts with an array of Materials on the ball control.
* To create material use new Material(Shader.Find("Specular"));
* In EditMode you can use renderer.sharedMaterial to inspect the current material.

## Exercise 3 - Applied force

Write two or more playmode tests verifying the behavior of the ball control over time.
* When initializing the ball control, set the Force and SecondsForceApplied values.
* Yield the WaitForSeconds and WaitForFixedUpdate commands to elapse time.
* Evaluate on the transform.position of the ball
* You can use the UnitySetUpAttribute or SetUpAttribute to create a common setup method

## Exercise 4 - MonoBehaviorTest

Make a MonoBehaviorTest for the ball control that verifies the position after force is no longer applied.
* Create an testable extension of BallControl and let that implement IMonoBehaviourTest. E.g. BallControlTestable
* Use the IsTestFinished to control when the test should stop sending updates on the control.
* In a unity test create a new MonoBehaviorTest<BallControlTestable> and yield that object, once it is set up.
* After yielding the monoBehaviorTest, you can verify the position
* You can use GameObject.Find("MonoBehaviourTest: " + typeof(BallControlTestable).FullName); to find the gameObject that has the ball control.
