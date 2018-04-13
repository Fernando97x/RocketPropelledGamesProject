using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
// SCRIPT OBSOLETO, INCORPORADO AO PLAYERSCRIPT

	public Transform cam;
	public float velocity = 10;
	public float rotationSpeed = 30;

	Quaternion calculatedRotation;
	Vector3 input;
	float angle;

	void Update()
	{
		GetInput();

		if (input.x == 0 && input.y == 0) return;

		Direction();
		Rotate();
		Move();

	}

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

