﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    // NOT IN USE - USED FOR OPTIMISATION
    //Displays FPS as Text on Screen
	float deltaTime = 0.0f;
	public Text FPSText;
	public GameObject cam;

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		//transform.position.x = cam.transform.rotation.y;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		//Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = h * 5 / 100;
		style.normal.textColor = new Color (0.0f, 0.0f, 0.5f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		FPSText.text = "FPS: " + text;
	}
}
