using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;
    public Vector3 offsetPosition;
    public Quaternion offsetRotation; 
    public Quaternion normalRotation;

    public EndController end;

    public bool move = false;

    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        if (pathCreator != null && move)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.position = new Vector3(transform.position.x + offsetPosition.x, 
                transform.position.y + offsetPosition.y,
                transform.position.z + offsetPosition.z);

            normalRotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            //Debug.Log("Rotation Previouse: " + transform.rotation);

            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.z, transform.rotation.y, transform.rotation.w);
            transform.rotation = new Quaternion(normalRotation.x + offsetRotation.x,
                normalRotation.y + offsetRotation.y,
                normalRotation.z + offsetRotation.z,
                normalRotation.w + offsetRotation.w);

            if (distanceTravelled >= pathCreator.path.length)
            {
                //ENd
                end.Emit(true);
            }
        }

        
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
