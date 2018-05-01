using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Xylo staff controller.
/// </summary>
public class Staff : MonoBehaviour {
	private static Timer _timer; // Time manager.
	private StaffData _staffData; // Dynamic staff data. Dimensions for playhead.
	private Playhead _playhead; // How we interact with our playhead.
	private float _staffWidth; // Used to calculate our playhead increment.
	private KeyNotes _keyNotes; // Key Note Sprite Resource Model
	private Recorder _recorder; // Records note data, stores in model.

	private readonly float _PLAYSECONDS = 5.0f; // In case we want to increase play time.
	private readonly float _SPEED = 37.5f; // Required to calculate travel distance per second.
	private readonly float _VERTICALOFFSET = 450.0f; // Better note alignment.
	//--------------------------------------------------------------------------
	/// <summary>
	/// Start this instance by getting dynamic data from our staff canvas
	/// and playhead.
	/// </summary>
	void Start () {
		_keyNotes = new KeyNotes (); // Note sprite data.

		_staffData = GameObject.Find ("StaffCanvas").GetComponent<StaffData> ();
		_staffWidth = _staffData.width;

		_timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		_playhead = GameObject.Find ("PlayheadSprite").GetComponent<Playhead> ();
		_recorder = GameObject.Find ("Recorder").GetComponent<Recorder> ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		_playhead.setTraversalIncrement (calculateIncrement());
		// Timer on?
		if (_timer.timerEngaged) {
			// In bounds?
			if (_playhead._currentX <= _staffWidth) {
				_playhead.incrementPlayheadPosition ();
			}
		}
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Resets the staff.
	/// </summary>
	public void resetStaff() {
		resetPlayhead ();
		eraseNotes();
		resetRecording ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Resets the playhead position.
	/// </summary>
	public void resetPlayhead() {
		_playhead.resetPosition ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Resets the recording in staff's recorder.
	/// </summary>
	public void resetRecording() {
		_recorder.clearRecording ();
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Gets the recording from staff's recorder data.
	/// </summary>
	/// <returns>The recording.</returns>
	public List<NoteRecord> getRecording() {
		return _recorder.recording;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Erases drawn notes from the staff. Used tags so we only clean up temp notes.
	/// </summary>
	public void eraseNotes() {
		GameObject[] notesToDestroy = GameObject.FindGameObjectsWithTag ("TempNote");
		foreach (var note in notesToDestroy) {
			Destroy (note);
		}
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Records the note.
	/// </summary>
	/// <param name="noteIndex">Note index.</param>
	public void recordNote(int noteIndex) {
		_recorder.addNote (noteIndex, _timer.time);
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Draws the note.
	/// </summary>
	/// <param name="noteIndex">Note index.</param>
	public void drawNote(int noteIndex) {
		// Create object, attach sprite renderer w/ note sprite, instantiate.
		GameObject currentNote = new GameObject("Note");
		SpriteRenderer renderer = currentNote.AddComponent<SpriteRenderer> ();
		renderer.sprite = (Sprite)_keyNotes.getNote (noteIndex);
		renderer.sortingOrder = 1; // Make visible.
		currentNote.tag = "TempNote";
		GameObject note = Instantiate (currentNote);

		// Resize note.
		Vector3 newScale = new Vector3(50.0f, 50.0f);
		note.transform.localScale = newScale;

		// Get appropriate position.
		float x = _playhead._currentX; // Current playhead position.
		float y = ((noteIndex + 1) * 100) - _VERTICALOFFSET; // Vertical offset by note index.
		Vector2 position = new Vector2(x, y);

		// Position note.
		note.transform.position = position;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Calculates the increment, based on staff sized, for our playhead movement.
	/// </summary>
	private float calculateIncrement() {
		_staffWidth = _staffData.width;
		return _staffWidth / _PLAYSECONDS / _SPEED;
	}
	//--------------------------------------------------------------------------
}
