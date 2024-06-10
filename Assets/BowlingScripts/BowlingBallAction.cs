using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallAction : MonoBehaviour
{
    //Create a list of all bowling ball objects
    public List<GameObject> allBowlingBallModels = new List<GameObject>();

    //create index of bowling ball list
    public int currentChoiceIndex;

    // this is a transform in the scene for usshi'fang to specify the initial velocity of the bowling ball.
    [Tooltip("Forward direction to be used as test initial direction.")]
    public Transform testVelocityDirection;

    [Tooltip("How fast the test ball will go?")]
    public float testVelocityMagnitude;

    public Rigidbody testBowlingBall;


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
        } else {
            if (Input.GetKeyDown(KeyCode.Space))
                StartCoroutine(PendTestLaunch());
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

    // wait for 2 seconds and launch the ball
    IEnumerator PendTestLaunch()
    {
        //yield return new WaitForSeconds(2f);

        testBowlingBall.isKinematic = false;
        //testBowlingBall.useGravity = true;
        yield return null;

        Launch(testVelocityDirection.forward * testVelocityMagnitude);
    }
    private void Launch(Vector3 initialVelcity)
    {
        Debug.Log("Launch: Values");

        testBowlingBall.AddForce(initialVelcity, ForceMode.VelocityChange);
    }
}
