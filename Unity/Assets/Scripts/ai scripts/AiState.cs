using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ai Assets/State/New State")]
public class AiState: ScriptableObject {

	public AiAction[] actions;
	public AiTrigger[] triggers;
	
	public void AiUpdate(AiController controller){
		for (int i = 0; i < actions.Length; i++){
			actions[i].Action(controller);
		}
		for (int i = 0; i < triggers.Length; i++){
			bool condition = triggers[i].condition.Condition(controller);
			if (condition){
				controller.ChangeState (triggers[i].newState);
			}
		}
	}
	
}
