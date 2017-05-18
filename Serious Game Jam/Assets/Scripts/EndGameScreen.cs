﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour {

	// Player Score 
	List<bool> playerThinksitsFake = new List<bool> ();
	List<GameObject> questionList = new List<GameObject> ();

	// references for controlling animation
	private Animator animator;

	// This bool manages the update cycle
	bool EndGameState;

	// Numberic data for displaying stats on the end game screen
	int playerScore;

	// THIS IS FOR TEST 
	public Text testText;

	// Use this for initialization
	void Start () 
	{
		
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}

		animator.Play ("Reset");

		testText.text = "";
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (EndGameState == true) 
		{

			// This is going to handle the transition and display of the end game
			if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) 
			{

				testText.text = "Test Text";

			}


		}

		if (Input.GetKeyDown (KeyCode.LeftApple)) 
		{
			ShowTheResults ();
		}
		
	}


	public void ShowTheResults()
	{

		// Call when the game has ended this will prompt the game end screen

		// Calculate the players Score
		for(int i = 0; i < playerThinksitsFake.Count; i++)
		{

			if(questionList[i].GetComponent<Item>().fake == playerThinksitsFake[i])
			{
				playerScore++;
			}

		}
			
		animator.Play("EndGame");

		// This bool enables the user interaction and update checking 
		EndGameState = true;


	}


	public void AddAnswer(GameObject item, bool playersAnswer)
	{

		// call when the player makes a guess on the current item - it will the results for end of the game

		playerThinksitsFake.Add (playersAnswer);
		questionList.Add (item);

	}


	public void ResetScore()
	{

		// used to reset the score and end gamescree for the start of a new game

		// reset the scores 
		playerThinksitsFake.Clear ();
		questionList.Clear ();
		playerScore = 0;

		// reset the visual Image
		animator.Play("Reset");

	}

}