﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanelController : MonoBehaviour {

	

	IEnumerator GameStartCo()
	{
		yield return new WaitForSeconds(1f);
		Board board = FindObjectOfType<Board>();
		board.currentState = GameState.move;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
