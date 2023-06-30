﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	public GameObject pausePanel;
	private Board board;
	public bool paused = false;
	public Image soundButton;
	public Sprite musicOnSprite; // if sound == 0  mute; == 1 unmute
	public Sprite musicOffSprite;

	// Use this for initialization
	void Start () {
        pausePanel.SetActive(false);
        if (PlayerPrefs.HasKey("Sound"))
		{
			if(PlayerPrefs.GetInt("Sound") == 0)
			{
				soundButton.sprite = musicOffSprite;
			}
            else
            {
				soundButton.sprite = musicOnSprite;
            }
        }
		else
		{
			soundButton.sprite = musicOnSprite;
		}
		
		board = GameObject.FindWithTag("Board").GetComponent<Board>(); ;
	}
	
	// Update is called once per frame
	void Update () {
		if(paused && !pausePanel.activeInHierarchy)
		{
			pausePanel.SetActive(true);
			board.currentState = GameState.pause;  
		}
		if(!paused && pausePanel.activeInHierarchy)
		{
			pausePanel.SetActive(false);
			board.currentState = GameState.move;
		}
	}

	public void SoundButton()
	{
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                soundButton.sprite = musicOnSprite;
				PlayerPrefs.SetInt("Sound", 1);
            }
            else
            {
                soundButton.sprite = musicOffSprite;
                PlayerPrefs.SetInt("Sound", 0);
            }
        }
        else
        {
            soundButton.sprite = musicOffSprite;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }

	public void PauseGame()
	{
		paused = !paused;
	}

	public void ExitGame()
	{
		SceneManager.LoadScene(0);
	}
}
