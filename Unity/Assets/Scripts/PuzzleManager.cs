using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {
	
	public GameObject puzzlePanel;
	public PuzzleObjectScript puzzle;
	
	[SerializeField] GameObject dial1;
	[SerializeField] Scrollbar scrollbar1;
	[SerializeField] GameObject[] lights1;
	[SerializeField] int controlValue1;
	[SerializeField] GameObject dial2;
	[SerializeField] Scrollbar scrollbar2;
	[SerializeField] GameObject[] lights2;
	[SerializeField] int controlValue2;	
	[SerializeField] GameObject dial3;
	[SerializeField] Scrollbar scrollbar3;
	[SerializeField] GameObject[] lights3;
	[SerializeField] int controlValue3;
	
	private float dialValue1 = 0;
	private float dialValue2 = 0;
	private float dialValue3 = 0;
	
	// THESE VARIABLES SHOULD BE MOVED TO A SCRIPT COMPONENT OF THE GAME OBJECT THAT STARTS THE PUZZLE
	float d11;	//1st dial influence
	float d12;
	float d13;
	float d21;	//2nd dial influence
	float d22;
	float d23;
	float d31;	//3rd dial influence
	float d32;
	float d33;
	float c1;	//base values
	float c2;
	float c3;
	
	public void OpenPanel (PuzzleObjectScript puzzleNew){
		if(puzzleNew == null) return;	// ERROR ON CHARACTER SCRIPT?
		puzzlePanel.SetActive(true);
		puzzle = puzzleNew;
		dial1.transform.Find("Dial Image").rotation = Quaternion.Euler(new Vector3(0,0,(0.5f - scrollbar1.value)*80));	// Initial dial positions
		dial2.transform.Find("Dial Image").rotation = Quaternion.Euler(new Vector3(0,0,(0.5f - scrollbar2.value)*80));
		dial3.transform.Find("Dial Image").rotation = Quaternion.Euler(new Vector3(0,0,(0.5f - scrollbar3.value)*80));	
		d11 = puzzle.d11;	// Dial response on light display
		d12 = puzzle.d12;
		d13 = puzzle.d13;
		d21 = puzzle.d21;
		d22 = puzzle.d22;
		d23 = puzzle.d23;
		d31 = puzzle.d31;
		d32 = puzzle.d32;
		d33 = puzzle.d33;
		c1 = puzzle.c1;		// Constant deviation on light display
		c2 = puzzle.c2;
		c3 = puzzle.c3;
	
		ChangeControlValues();
		
	}
	
	public void ClosePanel (){
		if(puzzle.puzzleSolved) puzzle.EndPuzzle();
		scrollbar1.value = 0.5f;
		scrollbar2.value = 0.5f;
		scrollbar3.value = 0.5f;
		puzzlePanel.SetActive(false);	
	}

	public void TurnDial1 (){
		RectTransform rect = dial1.transform.Find("Dial Image").GetComponent<RectTransform>();
		float dialValueNext = (0.5f - scrollbar1.value)*10;
		
		rect.Rotate (new Vector3 (0, 0, -8 * (dialValue1 - dialValueNext)));
		
		ChangeControlValues();
		
		dialValue1 = dialValueNext;	
	}
	
	public void TurnDial2 (){
		RectTransform rect = dial2.transform.Find("Dial Image").GetComponent<RectTransform>();
		float dialValueNext = (0.5f - scrollbar2.value)*10;
		
		rect.Rotate (new Vector3 (0, 0, -8 * (dialValue2 - dialValueNext)));
		
		ChangeControlValues();
		
		dialValue2 = dialValueNext;
	}

	public void TurnDial3 (){
		RectTransform rect = dial3.transform.Find("Dial Image").GetComponent<RectTransform>();
		float dialValueNext = (0.5f - scrollbar3.value)*10;
		
		rect.Rotate (new Vector3 (0, 0, -8 * (dialValue3 - dialValueNext)));
		
		ChangeControlValues();
		
		dialValue3 = dialValueNext;
		
	}
	
	void ChangeControlValues(){
		float f1 = (scrollbar1.value - 0.5f)*10*d11 + (scrollbar2.value - 0.5f)*10*d21 + (scrollbar3.value - 0.5f)*10*d31 + 5 + c1;
		controlValue1 = (int) f1;
		float f2 = (scrollbar1.value - 0.5f)*10*d12 + (scrollbar2.value - 0.5f)*10*d22 + (scrollbar3.value - 0.5f)*10*d32 + 5 + c2;
		controlValue2 = (int) f2;
		float f3 = (scrollbar1.value - 0.5f)*10*d13 + (scrollbar2.value - 0.5f)*10*d23 + (scrollbar3.value - 0.5f)*10*d33 + 5 + c3;
		controlValue3 = (int) f3;
		
		ChangeLights();
		
		if (controlValue1 == 5 && controlValue2 == 5 && controlValue3 == 5){	// Puzzle solved
			print ("ENGLISH, MOTHERFUCKER! DO YOU SPEAK?!");
			puzzle.puzzleSolved = true;
		}
		if (controlValue1 != 5 || controlValue2 != 5 || controlValue3 != 5){	// Puzzle solved
			print ("SAY 'WHAT' AGAIN! I DARE YOU! I DOUBLE DARE YOU!");
			puzzle.puzzleSolved = false;
		}
		
		//print ("c1: " + controlValue1);
		//print ("c2: " + controlValue2);
		//print ("c3: " + controlValue3);
	}
	
	void ChangeLights(){	
		//1st row
		if (controlValue1 > 5){
			for (int i = 0; i < 6; i++){
				lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			for (int i = 5; i < lights1.Length; i++){
				if (i <= controlValue1) lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light red") as Texture;
				if (i > controlValue1) lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
		}
		if (controlValue1 == 5){
			for (int i = 0; i < lights1.Length; i++){
				lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			lights1[5].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light green") as Texture;	
		}
		if (controlValue1 < 5){
			for (int i = 6; i < lights1.Length; i++){
				lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			for (int i = 0; i <= 5; i++){
				if (i >= controlValue1) lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light red") as Texture;
				if (i < controlValue1) lights1[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
		}
		//2nd row
		if (controlValue2 > 5){
			for (int i = 0; i < 6; i++){
				lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			for (int i = 5; i < lights2.Length; i++){
				if (i <= controlValue2) lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light red") as Texture;
				if (i > controlValue2) lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
		}
		if (controlValue2 == 5){
			for (int i = 0; i < lights2.Length; i++){
				lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			lights2[5].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light green") as Texture;	
		}
		if (controlValue2 < 5){
			for (int i = 6; i < lights2.Length; i++){
				lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			for (int i = 0; i <= 5; i++){
				if (i >= controlValue2) lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light red") as Texture;
				if (i < controlValue2) lights2[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
		}
		//3rd row
		if (controlValue3 > 5){
			for (int i = 0; i < 6; i++){
				lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			for (int i = 5; i < lights3.Length; i++){
				if (i <= controlValue3) lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light red") as Texture;
				if (i > controlValue3) lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
		}
		if (controlValue3 == 5){
			for (int i = 0; i < lights3.Length; i++){
				lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			lights3[5].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light green") as Texture;	
		}
		if (controlValue3 < 5){
			for (int i = 6; i < lights3.Length; i++){
				lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
			for (int i = 0; i <= 5; i++){
				if (i >= controlValue3) lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light red") as Texture;
				if (i < controlValue3) lights3[i].GetComponent<RawImage>().texture = Resources.Load("Images/puzzle light grey") as Texture;
			}
		}
		
	}
}

