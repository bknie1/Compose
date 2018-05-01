using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
	private AudioSource _as;
	private KeySounds _keySounds; // Key Sound Resource Model
	public bool reverse { get; set; }
	//--------------------------------------------------------------------------
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		_keySounds = new KeySounds ();
		reverse = false;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Play the specified sound.
	/// </summary>
	/// <param name="sound">Sound clip.</param>
	private void play(AudioClip ac) {
		GetComponent<AudioSource> ().PlayOneShot (ac);
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Plays the audio passed from our xylophone keyboard controller.
	/// </summary>
	/// <param name="ac">Note sound.</param>
	public void playNote(int noteIndex) {
		// GetComponent<AudioSource> ().Stop(); Optional; less realistic, but less overhead.
		AudioClip currentSound = (AudioClip)_keySounds.getSound (noteIndex);
		play(currentSound);
	}
	//--------------------------------------------------------------------------
	public void playRecording(List<NoteRecord> recording) {
		// Generate delayed playback from modified list.
		foreach (var note in recording) {
			AudioClip currentSound = (AudioClip)_keySounds.getSound (note.noteIndex);
			StartCoroutine(playDelayed(currentSound, note.time));
		}
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Queues a delayed audio clip.
	/// </summary>
	/// <returns>The delayed.</returns>
	/// <param name="ac">Note sound.</param>
	/// <param name="timeDelay">Time delay.</param>
	private IEnumerator playDelayed(AudioClip ac, float timeDelay) {
		yield return new WaitForSeconds(timeDelay);
		play (ac);
	}
	//--------------------------------------------------------------------------
}
