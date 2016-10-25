/*
 LevelManager.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: This class is responsible to load or quit a specific level scene.
 */

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel(string name)
    {
        //Loads the intended level(scene) using by the passed name value
		Application.LoadLevel (name);
	}

	public void QuitRequest()
    {
        //Quits the intended level(scene) using by the passed name value
		Application.Quit ();
	}

}
