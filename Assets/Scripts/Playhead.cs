using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playhead View Model: Location and transformation.
/// </summary>
public class Playhead : MonoBehaviour {
	private readonly float _SPEED = 37.5f; // Required to calculate travel distance per second.
	private Transform _playheadTransform;
	private Vector3 _position;
	private Vector3 _startingPosition;
	public Vector3 _endPosition;
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
		_endPosition = _startingPosition; // Same Z, Y. X modified via method.
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
	/// Set the end position.
	/// </summary>
	public void setEndPositionX(float newX) {
		_endPosition.x = newX;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Resets the position of the playhead.
	/// </summary>
	public void resetPosition(bool reverse) {
		if (!reverse) {
			_playheadTransform.position = _startingPosition; // Move the sprite.
			Debug.Log ("Playhead: Resetting to forward position: " + _startingPosition);
		}
		else {
			_playheadTransform.position = _endPosition;
			Debug.Log ("Playhead: Resetting to reverse position: " + _endPosition);
		}
		_position = _playheadTransform.position; // Reset last known position, too.
		_currentX = _playheadTransform.position.x;
	}
	//--------------------------------------------------------------------------
	/// <summary>
	/// Increments or decrements the position of the playhead.
	/// </summary>
	public void adjustPlayheadPosition(bool reverse) {
		if(!reverse) _position.x += _traversalIncrement;
		else _position.x -= _traversalIncrement;

		_currentX = _position.x; // Keep our current position up to date for note placement.
		_playheadTransform.position = _position;
	}
	//--------------------------------------------------------------------------
}
