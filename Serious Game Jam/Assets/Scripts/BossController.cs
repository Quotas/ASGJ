using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossController : MonoBehaviour
{

    // Settings for the speech display
    public float secondsPerCharacter;
    public int curIndex = 0;

    // Reference to the speech text
    public Text BossSpeech;
    public Image SpeechBubble;
    private Animator animator;

    public enum BossState { TALKING, EXIT, PRESENT }

    public BossState state;

    // speech parsing algorithms
    public bool speaking;
    private string speechToBeParsed;
    int currentCharacter;
    private float timer;
    private bool clicked = false;

    // reference to the current dialoge being displayed
    string text;

    // This is for a test

    // Use this for initialization
    void Start()
    {

        if (BossSpeech == null)
        {
            BossSpeech = GetComponentInChildren<Text>(); // If there is a button placed on the speech bubble it may return that
        }

        if (SpeechBubble == null)
        {
            SpeechBubble = GetComponentsInChildren<Image>()[1]; // 1 is the first image past the boss him/herself
        }

        // Get access to the animator
        animator = GetComponent<Animator>();

        timer = 0.0f;

        SpeechBubble.enabled = false;
        BossSpeech.enabled = false;



    }


    // Update is called once per frame
    void Update()
    {


        if (speaking == true)
        {

            if (SpeechBubble.enabled == false)
            {
                SpeechBubble.enabled = true;
                BossSpeech.enabled = true;
            }

            timer += Time.deltaTime;

            if (timer > secondsPerCharacter && currentCharacter < text.Length)
            {
                speechToBeParsed += text[currentCharacter];
                currentCharacter++;
                timer = 0.0f;
            }
            else if (currentCharacter == text.Length && clicked)
            {
                curIndex++;
                speaking = false;
                clicked = false;
            }

        }

        BossSpeech.text = speechToBeParsed;

    }

    void ProgressDialogue()
    {

        clicked = true;

    }

    public void BossSpeaks(string speech)
    {

        // Sets the dialogue to be parsed and starts the display

        text = speech;
        speaking = true;
        currentCharacter = 0;
        speechToBeParsed = "";


    }


    public void BossEnter()
    {

        // calls the boss into the level
        // Start the animation
        animator.SetTrigger("Enter");
        state = BossState.PRESENT;

    }


    public void BossExit()
    {

        // calls the boss into the level

        // Hide the speech Bubble
        SpeechBubble.enabled = false;
        BossSpeech.enabled = false;
        transform.FindChild("DialogueButton").gameObject.SetActive(false);

        // Start the animation
        animator.Play("BossExit");

        state = BossState.EXIT;

    }


}
