using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the smooth camera movement and centering on the player.
/// </summary>
public class CameraFollowBehavior : MonoBehaviour
{
    public float BoxSizeX;    // The dead X distance of the player from the center of the screen.
    public float BoxSizeY;    // The dead Y distance of the player from the center of the screen.
    public GameObject FollowTarget;    // The GameObject which the camera should center in on.

    private void Update()
    {
        Vector2 cam2Target = transform.position - FollowTarget.transform.position;

        float x = 0;
        float y = 0;

        if (cam2Target.x > BoxSizeX)
        {
            x = BoxSizeX;
        }
        else if (cam2Target.x < -BoxSizeX)
        {
            x = -BoxSizeX;
        }

        if (cam2Target.y > BoxSizeY)
        {
            y = BoxSizeY;
        }
        else if (cam2Target.y < -BoxSizeY)
        {
            y = -BoxSizeY;
        }

        // Target coordinates of camera Lerp
        float xTarget;
        float yTarget;
        
        // Limit camera position to inside screen edges
        xTarget = Mathf.Max(FollowTarget.transform.position.x + x, 0.5f);
        xTarget = Mathf.Min(xTarget, 12.5f);
        yTarget = Mathf.Max(3f, FollowTarget.transform.position.y + y);
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(xTarget, yTarget, transform.position.z), Time.deltaTime*5f);
    }
}
