﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiAction : ScriptableObject {

	public abstract void Action (AiController controller);
}
