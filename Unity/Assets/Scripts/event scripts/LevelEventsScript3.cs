using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script específico para os eventos dessa fase
// Level Designer deve adicionar como componente ao objeto Game Maneger o levelscript apropriado no inspetor
// LEVEL: LOCKPICK TEST

public class LevelEventsScript3 : MonoBehaviour {
	
	public AudioManegerScript audioManeger;
	
	// CONDITIONS
	[SerializeField] GameObject Condition1;
	[SerializeField] Enum.Interaction interaction1;
	[SerializeField] GameObject Condition2;
	[SerializeField] Enum.Interaction interaction2;
	[SerializeField] GameObject Condition3;
	[SerializeField] Enum.Interaction interaction3;	
	
	// Flags
	[SerializeField] bool flag1;	// true: luz acesa
	[SerializeField] bool flag2;	// true: puzzle #1 solved
	[SerializeField] bool flag3;	// true: puzzle #2 solved
	
	// Event1
	[SerializeField] GameObject light;
	
	// Event2
	AudioClip song;
	
	void Start(){
		song = Resources.Load ("Sounds/Rick Roll", typeof(AudioClip)) as AudioClip;	
	}

	public void Event1 (GameObject obj, Enum.Interaction interaction){
		if (obj == Condition1 && interaction == interaction1){
			flag1 = !flag1;
			light.SetActive (flag1);
		}
	}
	
	public void Event2 (GameObject obj, Enum.Interaction interaction){
		if (obj == Condition2 && interaction == interaction2){
			flag2 = true;
			ObjectScript objScript = obj.GetComponent<ObjectScript>();
			objScript.hasEvent = false;
			if (flag2 && flag3)	audioManeger.PlaySong (song);
		}
	}
	
	public void Event3 (GameObject obj, Enum.Interaction interaction){
		if (obj == Condition3 && interaction == interaction3){
			flag3 = true;
			ObjectScript objScript = obj.GetComponent<ObjectScript>();
			objScript.hasEvent = false;
			if (flag2 && flag3)	audioManeger.PlaySong (song);
		}
	}
	
	public void Event4 (GameObject obj, Enum.Interaction interaction){
	//dummy
	}
	
	public void Event5 (GameObject obj, Enum.Interaction interaction){
	//dummy	
	}

}
