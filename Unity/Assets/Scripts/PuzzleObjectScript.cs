using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjectScript : MonoBehaviour {
	
	// [SerializeField] int difficultyLevel;

	public float d11;	//1st dial influence
	public float d12;
	public float d13;
	public float d21; //2nd dial influence
	public float d22;
	public float d23;
	public float d31; //3rd dial influence
	public float d32;
	public float d33;
	public float c1; //base values
	public float c2;
	public float c3;
	
	public bool hasEvent;
	
	public bool puzzleSolved;
	
	public void EndPuzzle(){	// Changes object type to 'other' after solving puzzle, so it can not be played again
		this.GetComponent<ObjectScript>().objectType = Enum.Type.other;
		Destroy (this);
	}
	
}
