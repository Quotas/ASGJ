using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossController : MonoBehaviour
{

    // Settings for the speech display
    public float secondsPerCharacter;
    public int curIndex = 0;

    public enum ISpeechStatus { PENDING, FAILED, SUCCESS }

    // Reference to the speech text
    public Text BossSpeech;
    public Image SpeechBubble;
    private Animator animator;

    // speech parsing algorithms
    public bool speaking;
    private string speechToBeParsed;
    int currentCharacter;
    private float timer;

    // reference to the current dialoge being displayed
    Dialogue currentDialogue;

    // This is for a test
    Dialogue test;
    Dialogue test2;

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

        test = new Dialogue();
        test.text = "This is a test what do you think";

        test2 = new Dialogue();
        test2.text = "I hope you like this little test. I am not sure if it works well, lets see!!!";

        timer = 0.0f;

        SpeechBubble.enabled = false;
        BossSpeech.enabled = false;
        BossEnter();


    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BossSpeaks(test);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            BossSpeaks(test2);
        }


        if (speaking == true)
        {

            if (SpeechBubble.enabled == false)
            {
                SpeechBubble.enabled = true;
                BossSpeech.enabled = true;
            }

            timer += Time.deltaTime;

            if (timer > secondsPerCharacter && currentCharacter < currentDialogue.text.Length)
            {
                speechToBeParsed += currentDialogue.text[currentCharacter];
                currentCharacter++;
                timer = 0.0f;
            }
            else if (currentCharacter == currentDialogue.text.Length && Input.anyKeyDown)
            {
                curIndex++;
                speaking = false;
            }

        }

        BossSpeech.text = speechToBeParsed;

    }

    public void BossSpeaks(Dialogue speech)
    {

        // Sets the dialogue to be parsed and starts the display

        currentDialogue = speech;
        speaking = true;
        currentCharacter = 0;
        speechToBeParsed = "";


    }


    public void BossEnter()
    {

        // calls the boss into the level
        // Start the animation
        animator.SetTrigger("Enter");

    }


    public void BossExit()
    {

        // calls the boss into the level

        // Hide the speech Bubble
        SpeechBubble.enabled = false;
        BossSpeech.enabled = false;

        // Start the animation
        animator.Play("BossExit");


    }


}
