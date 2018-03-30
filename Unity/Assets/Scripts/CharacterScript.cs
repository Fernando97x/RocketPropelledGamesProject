using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

	public GameObject gm;
	public LevelManager levelManager;
	public PuzzleManager puzzleManager;
	
	//Use Object
	public GameObject objUsed;
	public bool	usingPanel;
	
	
	//Movimento
	public Transform cam;
    public float velocity = 10;
    public float rotationSpeed = 30;
    Quaternion calculatedRotation;
    Vector3 input;
    float angle;
	
	void Start(){
		gm = GameObject.FindWithTag("GameController");
		levelManager = gm.GetComponent <LevelManager>();
		puzzleManager = gm.GetComponent <PuzzleManager>();
	}

    void Update()
    {
        GetInput();
        if (input.x != 0 || input.y != 0){
			Direction();
			Rotate();
			Move();
		}
		if (Input.GetKeyDown(KeyCode.E)) Use();
    }
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "InteractibleObject"){
			objUsed = other.gameObject;
			print ("Object near");
		}
	}
	
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "InteractibleObject"){
			objUsed = null;
			print ("Object no longer near");
		}
	}
	
	void Use(){
		print ("Use object!");
		if (objUsed == null) return;
		if (objUsed.GetComponent<ObjectScript>().hasEvent) levelManager.RunEvent(objUsed, Enum.Interaction.use);
		if (objUsed.GetComponent<ObjectScript>().objectType == Enum.Type.puzzlePanel) UsePuzzlePanel (objUsed);
	}

	void UsePuzzlePanel (GameObject objUsed){
		print ("use panel");
		if (!usingPanel){
			PuzzleObjectScript puzzle = objUsed.GetComponent<PuzzleObjectScript>();
			OpenPuzzlePanel(objUsed, puzzle);
			usingPanel = !usingPanel;
			return;
		}
		if (usingPanel){
			PuzzleObjectScript puzzle = objUsed.GetComponent<PuzzleObjectScript>();
			ClosePuzzlePanel(objUsed, puzzle);
			usingPanel = !usingPanel;
			return;
		}
	}
	
	void OpenPuzzlePanel(GameObject objUsed, PuzzleObjectScript puzzle){
		print ("open panel");
		levelManager.RunEvent(objUsed, Enum.Interaction.openPuzzle);
		puzzleManager.OpenPanel(puzzle);
	}
	
	void ClosePuzzlePanel(GameObject objUsed, PuzzleObjectScript puzzle){
		print ("close panel");
		if (puzzle.puzzleSolved) levelManager.RunEvent(objUsed, Enum.Interaction.solvePuzzle);
		if (!puzzle.puzzleSolved) levelManager.RunEvent(objUsed, Enum.Interaction.failPuzzle);
		puzzleManager.ClosePanel();
	}
	
	/////MOVEMENT
    void GetInput() //Coleta o valor do Axis com o valor de 0 ou 1 sem smooth
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void Direction() //Calculo do ângulo para que devemos rotacionar
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    void Rotate() //Aplicação da rotação
    {
        calculatedRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, calculatedRotation, rotationSpeed * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }
}
