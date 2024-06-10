using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallKeyboardChoice : MonoBehaviour
{
    //Create a list of all bowling ball objects
    public List<GameObject> allBowlingBallModels = new List<GameObject>();

    //create index of bowling ball list
    public int currentChoiceIndex;

    // Start is called before the first frame update
    void Start()
    {

        RefreshBowlingBall(); 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentChoiceIndex++; //increment index by 1 => currentChoiceIndex = currentChoiceIndex + 1

            //Select 1st ball if we reached the end
            if (currentChoiceIndex >= allBowlingBallModels.Count)  
                currentChoiceIndex = 0;

            RefreshBowlingBall();
        }

    }

    public void RefreshBowlingBall()
    {

        //check if there are any bowling balls to select
        if (allBowlingBallModels.Count > 0)
        {
            //loop through options setting true the bowling ball selected
            for (int i = 0; i < allBowlingBallModels.Count; i++)
            {

                if (i == currentChoiceIndex)
                    allBowlingBallModels[i].SetActive(true);
                else
                    allBowlingBallModels[i].SetActive(false);
            }
        }
    }
}
