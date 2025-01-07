using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform desiredCameraPos,player;
    public float smoothSpeed = 5; // The smoothness of the camera follow

    private void LateUpdate()
    {
        follow();
    }

    void follow()
    {
        transform.position = Vector3.Lerp(transform.position, desiredCameraPos.position, Time.deltaTime * smoothSpeed);
        transform.LookAt(player.position);
    }
}