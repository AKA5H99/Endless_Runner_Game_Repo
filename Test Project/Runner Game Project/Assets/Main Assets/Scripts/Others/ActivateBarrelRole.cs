using UnityEngine;

public class ActivateBarrelRole : MonoBehaviour
{
    private void Update()
    {
        // Detect all colliders in the radius
        Collider[] Obstacles = Physics.OverlapSphere(transform.position, 10);

        foreach (var Obstacle in Obstacles)
        {
            // Check if the object is a Obstacle
            if (Obstacle.CompareTag("Obstacle"))
            {
                //Check for BarrelRoll Script if its not null activate the script
                if(Obstacle.GetComponent<BarrelRoll>() != null)
                {
                    Obstacle.GetComponent<Animator>().enabled = true;
                    Obstacle.GetComponent<BarrelRoll>().enabled = true;

                }
            }
        }
    }
}
