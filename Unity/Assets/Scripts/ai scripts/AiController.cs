using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

	public AiState state;
	
	// add vars relating to each possible action
	//
	//
	//
	
	
	void Update(){
		state.AiUpdate(this);
	}
	
	public void ChangeState (AiState newState){
		state = newState;
		// add instructions related to changing state
	}
	
}
