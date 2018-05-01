using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reacts to user input, plays the appropriate sound, and passes that data to 
/// the Recording View.
/// </summary>
public class XylophoneManager : MonoBehaviour {
	private static Timer _timer; // Time manager.
	private Speaker _speaker; // Audio controller.
	private Staff _staff; // Interaction w/ recording and playhead.
	public bool playback { get; set; } // Are we playing back notes?
	//--------------------------------------------------------------------------
	/// <summary>
	/// Awake this instance. Locked to 30 frames; might impact playhead movement.
	/// </summary>
	void Awake() {
		Application.targetFrameRate = 30;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Start this instance and defaults to accepting user input.
	/// </summary>
	void Start () {
		playback = false;
		_timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		_speaker = GameObject.Find ("Speaker").GetComponent<Speaker> ();
		_staff = GameObject.Find ("Staff").GetComponent<Staff> ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Attempts to play and record the sound.
	/// </summary>
	/// <param name="noteIndex">Note index.</param>
	public void playNote(int noteIndex) {
		// First, we only record if we're not playing back.
		if (!playback) {
			// Turn on timer and reset everything.
			if (!_timer.timerEngaged) {
				reset ();
			}

			// Timer is on, so we're allowed to record.
			if (_timer.timerEngaged) {
				// Start moving playhead.


				// Play
				// Delegate the actual play to our audio source controller.
				_speaker.playNote(noteIndex);

				// Record
				// Likewise, delegated to our staff controller, which owns the recording.
				_staff.drawNote (noteIndex);
				_staff.recordNote (noteIndex);
			}
		}
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Full reset of timer, staff.
	/// </summary>
	private void reset() {
		_staff.resetStaff ();
		_staff.resetRecording ();
		_timer.timerEngaged = true;
		Debug.Log ("Recording started.");
	}
	//--------------------------------------------------------------------------
	private void playbackReset() {
		_staff.resetPlayhead ();
		_timer.timerEngaged = true;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Plays back the recording. Delegate to Speaker and Staff's recorder.
	/// </summary>
	public void playbackRecording() {
		// We don't want to overlap playbacks.
		if (!playback) {
			playbackReset ();
			Debug.Log ("Playback started.");
			playback = true;
			StartCoroutine (waitForPlayback());
			List<NoteRecord> recording = _staff.getRecording ();
			_speaker.playRecording (recording);
		}
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Pauses listeners while we play back the recording.
	/// </summary>
	private IEnumerator waitForPlayback() {
		yield return new WaitForSeconds(5.0f);
		playback = false;
		Debug.Log ("Playback finished.");
	}
	//--------------------------------------------------------------------------
}
