using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Staff model: For staff dimensions.
/// </summary>
public class StaffData : MonoBehaviour {
	private RectTransform _staffDimensions;
	public float height { get; set; } // Staff Max Y: Not really needed right now, but could be useful for another feature.
	public float width { get; set; } // Staff Max X: We need the dimensions of our staff to move the playhead.
	public Resources[] notes;
	//--------------------------------------------------------------------------
	/// <summary>
	/// Keeps our staff dimensions up to date for the playhead.
	/// </summary>
	void Update () {
		_staffDimensions = GameObject.Find ("StaffCanvas").GetComponent<RectTransform> ();
		height = _staffDimensions.rect.height;
		width = _staffDimensions.rect.width;
	}
	//--------------------------------------------------------------------------
}
