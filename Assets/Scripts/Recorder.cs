using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Recording controller.
/// </summary>
public class Recorder : MonoBehaviour {
	public List<NoteRecord> recording { get; set; }
	public bool reverse { get; set; }
	//--------------------------------------------------------------------------
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		recording = new List<NoteRecord> ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Adds the note to our recording.
	/// </summary>
	/// <param name="noteIndex">Note index.</param>
	/// <param name="time">Time played.</param>
	public void addNote(int noteIndex, float time) {
		NoteRecord nrm = new NoteRecord (noteIndex, time);
		recording.Add (nrm);
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Clears the recorded data.
	/// </summary>
	public void clearRecording() {
		recording.Clear ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Reverses the recording.
	/// </summary>
	/// <param name="recording">Recording.</param>
	public void reverseRecording() {
		// We don't want to accidentally affect our original.
		Debug.Log("Recorder: Recording reversal.");
		reverse = !reverse;
		recording.Reverse(); // Flip order.
		foreach (var note in recording) {
			// Adjust the time signature: 5.0 - this note's time.
			note.time = 5.0f - note.time; 
		}
	}
	//--------------------------------------------------------------------------
}
