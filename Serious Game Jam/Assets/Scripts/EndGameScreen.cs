using System.Collections;
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

	// This is a reference to the button Object
	public Button resetButton;

	// Text Prefab
	public Text textPrefab;

	// References to the right and wrong player feedback
	public Sprite correct;
	public Sprite wrong;

	// These are reference to the text/Images/Button arrays 
	[SerializeField]
	public List<GameObject> results;

	// Prefab object for the solution screen
	public GameObject imageScreenPrefab;


	// Use this for initialization
	void Start () 
	{
		
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}

		animator.Play ("Reset");
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (EndGameState == true) 
		{

			// This is going to handle the transition and display of the end game
			if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) 
			{

				// Display the end of game text and stuff here.
				// Name Correct Button.For.Image

				for (int i = 0; i < questionList.Count; i++)
				{

					// set them active to start 
					results[i].SetActive(true);

					// Get the name of the object inspected
					results [i].GetComponent<Text> ().text = questionList [i].name;

					// Determine which image need to be applied
					if (questionList [i].GetComponent<Item> ().fake == playerThinksitsFake [i]) {

						// The player was right ( returns the first image allowing it to be changed
						results [i].GetComponentInChildren<Image> ().sprite = correct;

					} else {

						// The player was right ( returns the first image allowing it to be changed
						results [i].GetComponentInChildren<Image> ().sprite = wrong;

					}

				}

				// Check that there aren't any empty ones in the list 
				for (int i = 0; i < results.Count; i++) 
				{
					if (results [i].GetComponent<Text> ().text == "NAME") 
					{

						results [i].SetActive (false);

					}

				}

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


	public void buttonPressed( int indexImageLookUp)
	{

		// load the image with the ability to quit
		imageScreenPrefab.SetActive(true);

		// set the image of the button pressed
		imageScreenPrefab.GetComponent<Image>().sprite = questionList[indexImageLookUp].GetComponent<Item>().correctAnswerImage;

	}

}
