using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ai Assets/Action/Exemple Action")]
public class ExempleAction : AiAction {
	
	public override void Action (AiController controller){
		DoSomething();
	}
	
	void DoSomething(){
		Debug.Log ("I think therefore I am");
	}


}
