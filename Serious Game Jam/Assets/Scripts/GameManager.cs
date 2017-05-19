using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public class Delivery
    {

        //Holds all the dialgue for the game
        public List<Dialogue> sceneDialogue = new List<Dialogue>();

        public List<GameObject> items = new List<GameObject>();
        public bool active;
        public string name;
        public GameObject boss;


        public void AddDialogue(string _text, ref GameObject _entity)
        {

            sceneDialogue.Add(new Dialogue(_text, ref _entity, sceneDialogue.Count));

        }

        public void AddItem(GameObject item)
        {


            items.Add(item);


        }

        public bool ProcessDialogue(int index)
        {

            if (index > sceneDialogue.Count - 1)
            {
                return false;
            }
            sceneDialogue[index].Fire();
            return true;

        }

        public bool SetActiveItem(int index)
        {
            if (index > items.Count - 1)
            {
                return false;
            }
            else
            {
                items[index].gameObject.SetActive(true);
                return true;
            }


        }
    }

    public struct Dialogue
    {

        public string text { get; set; }
        int id { get; set; }
        GameObject actor;

        public Dialogue(string _text, ref GameObject _entity, int _id)
        {

            text = _text;
            id = _id;
            actor = _entity;



        }


        public void Fire()
        {
            actor.GetComponent<BossController>().BossEnter();
            actor.GetComponent<BossController>().BossSpeaks(text);

        }
    }


    //UI Elements go here
	bool gameEnd = false;

    public int curDeliveryIndex = 0;
    public int curItemIndex = 0;
    private List<Delivery> deliveries = new List<Delivery>();


    [SerializeField]
    public List<GameObject> items = new List<GameObject>();
    [SerializeField]
    public List<string> itemKey = new List<string>();

    public GameObject curObject;
    public GameObject boss;
    public GameObject endScreen;


    // Use this for initialization
    void Start()
    {

        // DontDestroyOnLoad(gameObject);

        #region Delivery Content
        Delivery d = new Delivery();

        d.name = "Main";
        d.AddDialogue("Welcome to the customs inspection office!", ref boss);
        d.AddDialogue("As an inspection officer, your job is to examine goods that come through here and determine if they are Genuine or Fake.", ref boss);
        d.AddDialogue("You represent the front line defence that protects the people of our country from illicit and dangerous goods.", ref boss);
        d.AddDialogue("Every time you confiscate an illicit item you are making the world a better place by putting a spanner in the works of international organized crime.", ref boss);

        d.AddDialogue("You can rotate the item by clicking and dragging with the mouse.", ref boss);
        d.AddDialogue("Use the [+] and [-] buttons to zoom in and out, you can also use the mouse wheel.", ref boss);
        d.AddDialogue("Look for the tell-tale signs that you have been taught and make your verdict:\nIs the item Genuine or Fake?", ref boss);


		d.AddItem(items[itemKey.IndexOf("DVD Fake")]);
        d.AddItem(items[itemKey.IndexOf("Cigarette Real")]);
		d.AddItem(items[itemKey.IndexOf("Whiskey Fake")]);
		d.AddItem(items[itemKey.IndexOf("Box Real")]);
		d.AddItem(items[itemKey.IndexOf("Cigarette Fake")]);
        d.AddItem(items[itemKey.IndexOf("DVD Real")]);



        deliveries.Add(d);
        #endregion


        deliveries[curDeliveryIndex].active = true;
		curObject = items [curDeliveryIndex];

    }


    void Update()
    {

        if (deliveries[curDeliveryIndex].active == true)
        {

            if (!boss.GetComponent<BossController>().speaking)
            {
                //TODO fix getting current delivery
                if (!deliveries[curDeliveryIndex].ProcessDialogue(boss.GetComponent<BossController>().curIndex))
                {
                    if (boss.GetComponent<BossController>().state != BossController.BossState.EXIT)
                    {
                        boss.GetComponent<BossController>().BossExit();

                    }
                }
            }



            if (!deliveries[curDeliveryIndex].SetActiveItem(curItemIndex))
            {

                deliveries[curDeliveryIndex].active = false;

            }
			else
			{
            curObject = deliveries[curDeliveryIndex].items[curItemIndex];
			}
        }

        else if (deliveries[curDeliveryIndex].active == false && gameEnd == false)
        {
            endScreen.GetComponent<EndGameScreen>().ShowTheResults();
			gameEnd = true;
        }



    }


    void SetFake()
    {
        curObject.GetComponent<Item>().active = false;
        endScreen.GetComponent<EndGameScreen>().AddAnswer(curObject, true);

        curItemIndex++;

    }

    void SetNotFake()
    {

        curObject.GetComponent<Item>().active = false;
        endScreen.GetComponent<EndGameScreen>().AddAnswer(curObject, false);

        curItemIndex++;

    }


    // This is the UI interface to the current item to allow it to be rotated.
    void RotateRight()
    {
        curObject.GetComponent<ClickRotate>().Rotate(-90.0f);
    }

    void RotateLeft()
    {

        curObject.GetComponent<ClickRotate>().Rotate(90.0f);

    }

}
