using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour {

	// List of rooms (game objects)
	
	// Enemies per room (list of integers)
	
	// Assets (enemy prefab, 
	
	
	void Start (){
		// resources load	(enemy prefab)
		// resources load	(state 1)
		//		(...)		(state 2, etc...)
		print ("start EnemyManagerScript");
	}
	
	public void Spawn(){
		// Spawns enemies with standard starting state
		print ("spawn");
	}
	
	public void Spawn (Enum.AiState state){
		// Spawns enemies with specific starting state
		print ("spawn in a state");
	}
	

}
