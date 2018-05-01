using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playhead View Model: Location and transformation.
/// </summary>
public class Playhead : MonoBehaviour {
	private Transform _playheadTransform;
	private Vector3 _position;
	private Vector3 _startingPosition;
	public float _currentX { get; set; } // x for our note placement.
	private float _traversalIncrement; // How far to move 
	//--------------------------------------------------------------------------
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		_playheadTransform = gameObject.GetComponent<Transform> ();
		_position = _playheadTransform.position;
		_startingPosition = _position;
		_traversalIncrement = 1.0f; // Default, immediately updated.
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Sets the traversal increment. Calculated by the staff.
	/// </summary>
	/// <param name="ti">Ti.</param>
	public void setTraversalIncrement(float ti) {
		_traversalIncrement = ti;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Resets the position of the playhead.
	/// </summary>
	public void resetPosition() {
		Debug.Log ("Playhead: Resetting Position: " + _startingPosition);
		_playheadTransform.position = _startingPosition; // Move the sprite.
		_position = _startingPosition; // Reset last known position, too.
		_currentX = _startingPosition.x;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Sets the position of the playhead.
	/// </summary>
	public void incrementPlayheadPosition() {
		_position.x += _traversalIncrement;
		_currentX = _position.x; // Keep our current position up to date for note placement.
		_playheadTransform.position = _position;
	}
	//--------------------------------------------------------------------------
}
