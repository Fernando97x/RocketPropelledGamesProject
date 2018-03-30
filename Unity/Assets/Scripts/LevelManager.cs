using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[SerializeField] int level;
	
	public EventScriptLevel1 eventLevel1;
	public EventScriptLevel2 eventLevel2;
	public EventScriptLevel3 eventLevel3;
	public EventScriptLevel4 eventLevel4;
	
	
	public AudioManeger audioManeger;
	
	
	// Use this for initialization
	void Start () {
		audioManeger = GetComponent<AudioManeger>();
		
		if (level ==1 )	eventLevel1 = GetComponent<EventScriptLevel1>();
		if (level ==1 )	eventLevel1.audioManeger = audioManeger;
		
		if (level ==2 )	eventLevel2 = GetComponent<EventScriptLevel2>();
		if (level ==2 )	eventLevel2.audioManeger = audioManeger;

		if (level ==3 )	eventLevel3 = GetComponent<EventScriptLevel3>();
		if (level ==3 )	eventLevel3.audioManeger = audioManeger;

		if (level ==4 )	eventLevel4 = GetComponent<EventScriptLevel4>();
		if (level ==4 )	eventLevel4.audioManeger = audioManeger;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RunEvent(GameObject obj, Enum.Interaction interaction){
		if (level == 1){
			eventLevel1.Event1(obj, interaction);
			eventLevel1.Event2(obj, interaction);
			eventLevel1.Event3(obj, interaction);
			eventLevel1.Event4(obj, interaction);
			eventLevel1.Event5(obj, interaction);
		}
		if (level == 2){
			eventLevel2.Event1(obj, interaction);
			eventLevel2.Event2(obj, interaction);
			eventLevel2.Event3(obj, interaction);
			eventLevel2.Event4(obj, interaction);
			eventLevel2.Event5(obj, interaction);
		}
		if (level == 3){
			eventLevel3.Event1(obj, interaction);
			eventLevel3.Event2(obj, interaction);
			eventLevel3.Event3(obj, interaction);
			eventLevel3.Event4(obj, interaction);
			eventLevel3.Event5(obj, interaction);
		}
		if (level == 4){
			eventLevel4.Event1(obj, interaction);
			eventLevel4.Event2(obj, interaction);
			eventLevel4.Event3(obj, interaction);
			eventLevel4.Event4(obj, interaction);
			eventLevel4.Event5(obj, interaction);
		}
	}

}