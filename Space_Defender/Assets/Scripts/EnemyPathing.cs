//using System.Collectionts;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        Debug.Log("waypoints[0]:" + waypoints[0].transform.position);

        transform.position = waypoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Count - 1)  //the enemy hasn't reached the last waypoint
        {
            var targetPostionRef = waypoints[waypointIndex +1].transform.position; //Vector3, affected by postion of Path game object
            var targetPostion = new Vector3(targetPostionRef.x, targetPostionRef.y, 0); //make sure z position is set 0
            var movementThisFrame = moveSpeed * Time.deltaTime; // the independent speed

            //move to the next waypoint
            Debug.Log("Target Waypoint Index:" + (waypointIndex + 1));
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, movementThisFrame);

            //check if the enemy has moved to the target postion, then set the next waypoint as new target
            //Debug.Log("Target targetPostion:" + targetPostion);
            //Debug.Log("Transform.position:" + transform.position);
            if (transform.position == targetPostion)
            {
                Debug.Log("Reach !!! NEXT");
                waypointIndex++;
                Debug.Log("Waypoint Index:" + waypointIndex);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
