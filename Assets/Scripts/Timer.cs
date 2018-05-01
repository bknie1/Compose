using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Timer controller.
/// </summary>
public class Timer : MonoBehaviour {
	public float time { get; set; }
	public readonly float maxTime = 5.0f;
	public bool timerEngaged { get; set; }
	//--------------------------------------------------------------------------
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		timerEngaged = false;
		time = 0.0f;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		// Wait for key press from currentKey.
		// Play Note

		if (timerEngaged) {
			// Are we out of time?
			if (time >= maxTime) {
				reset ();
			}
			// No? Keep counting.
			time += Time.deltaTime;
			// Debug.Log ("Timer: " + time);
		}
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Reset the timer.
	/// </summary>
	public void reset() {
		time = 0.0f;
		timerEngaged = false;
	}
	//--------------------------------------------------------------------------
}