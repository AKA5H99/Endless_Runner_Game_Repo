using UnityEngine;

public class MoveNearPlayer : MonoBehaviour
{
    [SerializeField] float farFromPlayer = 60;
    [SerializeField] Transform playerPos;

    private void Update()
    {
        transform.position = new Vector3(0, 0, playerPos.position.z + farFromPlayer);
    }
}
