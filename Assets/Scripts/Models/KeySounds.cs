using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Model responsible for loading and returning the appropriate audio data.
/// </summary>
public class KeySounds {
	private static Object[] _xyloSounds; // 0 = Low C, 1 = D, 2 = E, etc.
	private readonly string _SOUNDSDIR = "Sounds\\Xylo"; // Specific directory for blanket load.
	//--------------------------------------------------------------------------
	/// <summary>
	/// Initializes a new instance of the <see cref="XyloKeyModel"/> class.
	/// Loads Xylo sounds from the resource folder.
	/// </summary>
	public KeySounds() {
		try {
			_xyloSounds = Resources.LoadAll (_SOUNDSDIR, typeof(AudioClip));
			Debug.Log ("KeySounds: " + _xyloSounds.Length + " audio clips loaded.");
		} catch (MissingReferenceException mre) { Debug.Log (mre.StackTrace); }
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Attempts to return the requested sound. Reports if it doesn't exist.
	/// </summary>
	/// <returns>The sound.</returns>
	/// <param name="noteIndex">Note index.</param>
	public Object getSound(int noteIndex) {
		try { 
			return _xyloSounds[noteIndex]; 
		}
		catch(MissingReferenceException mre) {
			Debug.Log (mre.StackTrace);
			Debug.Log ("KeySounds: Failed to return sound.");
			return new AudioClip();
		}
	}
	//--------------------------------------------------------------------------
}