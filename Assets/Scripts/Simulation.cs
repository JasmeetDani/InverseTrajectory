using UnityEngine;

public class Simulation : MonoBehaviour
{
    [SerializeField]
    private BallController ballController = null;

    [SerializeField]
    private BouncePointController bouncePointController;


    private bool bPerformRacquetHit = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bPerformRacquetHit = true;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            bouncePointController.MoveLeft(Constants.BouncePointMoveDistance);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            bouncePointController.MoveRight(Constants.BouncePointMoveDistance);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            bouncePointController.MoveForward(Constants.BouncePointMoveDistance);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            bouncePointController.MoveBackward(Constants.BouncePointMoveDistance);
        }
    }

    void FixedUpdate()
    {
        if (bPerformRacquetHit)
        {
            bPerformRacquetHit = false;


            // The code can be extended to tweak the time to reach the front wall as per intended shot power

            Vector3 V = AIUtils.DetermineHitVelocity_For_StraightFrontWallHit(ballController.Pos,
                                                                  Constants.TimeToHitFrontWallInCaseOfDirectHit,
                                                                  new Vector3(bouncePointController.Pos.x, 0, bouncePointController.Pos.z));

            ballController.Fire(V);
        }
    }
}