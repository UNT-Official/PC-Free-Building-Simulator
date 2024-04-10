using System.Net.Mail;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraControllAndriod : MonoBehaviour
{
	public Transform Player;
	
	[Range(0, 10)]
	[SerializeField] private float sensativity;
	
	Vector3 firstPoint;
	Vector3 secondPoint;
	
	float xAngle;
	float yAngle;
	float xAngleTemp;
	float yAngleTemp;
	
	void Start()
	{
		yAngle = Player.transform.localRotation.eulerAngles.y;
	}
	
	void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (touch.position.x > Screen.width/2 & touch.phase == TouchPhase.Began)
			{
				firstPoint = touch.position;
				xAngleTemp = xAngle;
				yAngleTemp = yAngle;
			}

			if (touch.position.x > Screen.width/2 & touch.phase == TouchPhase.Moved)
			{
				secondPoint = touch.position;
				xAngle = xAngleTemp - (secondPoint.y - firstPoint.y) * 90/Screen.height * sensativity;
				yAngle = yAngleTemp + (secondPoint.x - firstPoint.x) * 180/Screen.width * sensativity;
				Player.transform.rotation = (Quaternion.Euler(0, yAngle, 0));
				xAngle = Mathf.Clamp (xAngle, -90f, 90f);
				transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
			}
		}
	}
}