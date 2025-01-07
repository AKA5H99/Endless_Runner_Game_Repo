using UnityEngine;

public class DestroyEverything : MonoBehaviour
{
    private void Update()
    {
        destroyAll();
    }

    void destroyAll()
    {
        // Detect all colliders in the radius
        Collider[] objectss = Physics.OverlapBox(transform.position, new Vector3(15,10,1));

        foreach (var obj in objectss)
        {
            // Check if the object is not a road
            if (obj.gameObject.tag != "Road")
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
