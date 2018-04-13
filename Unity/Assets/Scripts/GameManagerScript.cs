﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	PuzzleManagerScript puzzleManager;
	GameObject puzzlePanel;
	
	void Start(){
		puzzleManager = GetComponent<PuzzleManagerScript>();
		puzzlePanel = GameObject.FindWithTag("Puzzle Panel");
		puzzleManager.puzzlePanel = puzzlePanel;
		puzzlePanel.SetActive(false);
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)){
			print ("Application.LoadLevel");
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Escape)){
			print ("Application.Quit");
			Application.Quit();
		}
	}
	

}
