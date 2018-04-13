using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ai Assets/Action/Exemple Action 2")]
public class ExempleAction2 : AiAction {
	
	public override void Action (AiController controller){
		DoSomething();
	}
	
	void DoSomething(){
		Debug.Log ("I am therefore I think");
	}


}
