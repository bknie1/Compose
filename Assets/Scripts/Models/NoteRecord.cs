using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Note record model.
/// </summary>
public class NoteRecord {
	public int noteIndex { get; set; } // Note played.
	public float time { get; set; } // When it was played.
	//--------------------------------------------------------------------------
	/// <summary>
	/// Initializes a new instance of the <see cref="NoteRecord"/> class.
	/// </summary>
	/// <param name="noteIndex">Note index.</param>
	/// <param name="time">Time.</param>
	public NoteRecord(int noteIndex, float time) {
		this.noteIndex = noteIndex;
		this.time = time;
	}
	//--------------------------------------------------------------------------
}
