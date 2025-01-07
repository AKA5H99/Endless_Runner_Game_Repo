using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] Transform[] cityTransform;
    [SerializeField] float halfLength = 75;


    void Update()
    {
        //If the player gets closer, move city1 forward to city2
        if (playerTransform.position.z > cityTransform[0].transform.position.z + halfLength + 10f)
        {
            cityTransform[0].transform.position = new Vector3(0, 0, cityTransform[1].position.z + halfLength * 2);
        }

        //If the player gets closer, move city2 forward to city1
        if (playerTransform.position.z > cityTransform[1].transform.position.z + halfLength + 10f)
        {
            cityTransform[1].transform.position = new Vector3(0, 0, cityTransform[0].position.z + halfLength * 2);
        }

    }

}