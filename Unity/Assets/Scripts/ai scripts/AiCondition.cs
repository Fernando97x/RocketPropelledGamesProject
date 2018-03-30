using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiCondition : ScriptableObject {

	public abstract bool Condition (AiController controller);
	
}
