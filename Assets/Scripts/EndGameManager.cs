using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameType
{
	Moves,
	Time
}

[System.Serializable]
public class EndGameRequirements
{
	public GameType gameType;
	public int counterValue;

}

public class EndGameManager : MonoBehaviour {

	public GameObject movesLabel;
	public GameObject timeLabel;
    public GameObject theEndPanel;
    public Text counter;
	public EndGameRequirements requirements;
	public int currentCounterValue;
	private float timerSeconds;
	private Board board;
	

	// Use this for initialization
	void Start () {
		board = FindObjectOfType<Board>();
		SetupGame();
	}
	void SetupGame()
	{
		currentCounterValue = requirements.counterValue;
		if(requirements.gameType == GameType.Moves)
		{
			movesLabel.SetActive(true);
			timeLabel.SetActive(false);
		}
		else
		{
			timerSeconds = 1;
            movesLabel.SetActive(false);
            timeLabel.SetActive(true);
        }
		counter.text = "" + currentCounterValue;
	}

	public void DecreaseCouterValue()
	{
		if (board.currentState != GameState.pause)
		{
            currentCounterValue--;
            counter.text = "" + currentCounterValue;
            if (currentCounterValue <= 0)
            {
				LoseGame();
            }
        }	
	}


	/*public void WinGame()
	{

	}*/

	public void LoseGame()
	{
        theEndPanel.SetActive(true);
        board.currentState = GameState.lose;
        Debug.Log("You Lose!");
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
    }

	// Update is called once per frame
	void Update () {
		if(requirements.gameType == GameType.Time && currentCounterValue > 0)
		{
			timerSeconds -= Time.deltaTime;
			if(timerSeconds <= 0)
			{
				DecreaseCouterValue();
				timerSeconds = 1;
			}
		}
	}
}
