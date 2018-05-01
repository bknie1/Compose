using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Key note sprite image model.
/// </summary>
public class KeyNotes {
	private static Object[] _keyNotes; // 0 = Low C, 1 = D, 2 = E, etc.
	private readonly string _SOUNDSDIR = "Images\\Notes"; // Specific directory for blanket load.
	//--------------------------------------------------------------------------
	/// <summary>
	/// Initializes a new instance of the <see cref="KeyNotes"/> class.
	/// </summary>
	public KeyNotes() {
		try {
			_keyNotes = Resources.LoadAll (_SOUNDSDIR, typeof(Sprite));
			Debug.Log ("KeyNotes: " + _keyNotes.Length + " sprites loaded.");
		} catch (MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Attempts to return the requested note sprite. Reports if it doesn't exist.
	/// </summary>
	/// <returns>The sprite.</returns>
	/// <param name="noteIndex">Note index.</param>
	public Object getNote(int noteIndex) {
		try { 
			return _keyNotes[noteIndex]; 
		}
		catch(MissingReferenceException mre) {
			Debug.Log (mre.StackTrace);
			Debug.Log ("KeyNotes: Failed to return sprite.");
			return new Sprite();
		}
	}
	//--------------------------------------------------------------------------
}
