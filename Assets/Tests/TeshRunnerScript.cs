using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TeshRunnerScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TeshRunnerScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TeshRunnerScriptWithEnumeratorPasses()
        {

           UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            yield return new WaitForSeconds(2f);


            var task = GameObject.FindObjectOfType<TaskController>();

            var g1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g1.name = "Task_3";

            Debug.Log(task.CheckIfGameObjectContainsNo(g1));


            var g2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g2.name = "Task";

            Debug.Log(task.CheckIfGameObjectContainsNo(g2));




            yield return null;
        }
    }
}
