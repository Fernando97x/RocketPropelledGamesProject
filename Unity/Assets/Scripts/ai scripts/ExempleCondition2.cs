using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ai Assets/Condition/Exemple Condition 2")]
public class ExempleCondition2 : AiCondition {

	[SerializeField] AiState state;
	
	public override bool Condition (AiController controller){
		if (controller.state == state) return true;
		else return false;
	}
	
}
