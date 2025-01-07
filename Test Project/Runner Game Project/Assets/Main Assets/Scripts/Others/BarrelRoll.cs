using UnityEngine;

public class BarrelRoll : MonoBehaviour
{
    [SerializeField] float rollSpeed;

    private void Start()
    {
        rollSpeed = Random.Range(2, 4);
    }
    private void Update()
    {
        //Move back to give rolling effect
        transform.position += Vector3.back * rollSpeed * Time.deltaTime;
    }
}
