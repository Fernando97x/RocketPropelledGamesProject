using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Ai Assets/Trigger/New Trigger")]
public class AiTrigger : ScriptableObject {

	public AiCondition condition;
	public AiState newState;
}
