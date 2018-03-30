using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script específico para os eventos dessa fase
// Level Designer deve adicionar como componente ao objeto Game Maneger o levelscript apropriado no inspetor
// LEVEL: AI SYSTEM TEST

public class EventScriptLevel2 : MonoBehaviour {
	
	public AudioManeger audioManeger;
	
	// Objetos para condições
	[SerializeField] GameObject Condition1;
	[SerializeField] GameObject Condition2;
	
	// Objectos afetados e Assets
	[SerializeField] GameObject light;
	AudioClip song;
	
	// Flags
	[SerializeField] bool flag1;	// true: luz acesa
	
	
	void Start(){
		song = Resources.Load ("Sounds/Rick Roll", typeof(AudioClip)) as AudioClip;	
	}

	public void Event1 (GameObject obj, Enum.Interaction interaction){
		if (obj == Condition1 && interaction == Enum.Interaction.use){
			flag1 = !flag1;
			light.SetActive (flag1);
			print ("A");
			
		}
	}
	
	public void Event2 (GameObject obj, Enum.Interaction interaction){
		if (obj == Condition2 && interaction == Enum.Interaction.use){
			audioManeger.PlaySong (song);
			ObjectScript objScript = obj.GetComponent<ObjectScript>();
			objScript.hasEvent = false;
		}
	}
	
	public void Event3 (GameObject obj, Enum.Interaction interaction){
	//dummy	
	}
	
	public void Event4 (GameObject obj, Enum.Interaction interaction){
	//dummy
	}
	
	public void Event5 (GameObject obj, Enum.Interaction interaction){
	//dummy	
	}

}
