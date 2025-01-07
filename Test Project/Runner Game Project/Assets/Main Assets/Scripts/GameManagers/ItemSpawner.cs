using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPos; // lane 1, lane 2, lane 3
    [SerializeField] Transform[] items; // All items prefabs to be spawned
    [SerializeField] Transform[] specialItems; // Special Items prefabs eg:- Magnet, Speed Boost
    [SerializeField] GameObject coin;
    [SerializeField] Transform spawnedObjects; // Spawned Item container
    [SerializeField] int specialItemSpawnAfter = 10; // Special item will spawn after 10 normar spawns


    private GameManager gameManager;
    int[] ItemSpawningAtSpawnPos = new int[3];


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        spawnItems();
    }
    private void spawnItems()
    {
        // Assigning random item to all lanes
        ItemSpawningAtSpawnPos[0] = Random.Range(0, items.Length);
        ItemSpawningAtSpawnPos[1] = Random.Range(0, items.Length);
        ItemSpawningAtSpawnPos[2] = Random.Range(0, items.Length);

        //spawning special item after 10 normal spawns
        if(specialItemSpawnAfter <= 0)
        {
            spawnSpecialItems();
            specialItemSpawnAfter = 10;
        }
        else if (ItemSpawningAtSpawnPos[0] == ItemSpawningAtSpawnPos[1] && ItemSpawningAtSpawnPos[1] == ItemSpawningAtSpawnPos[2]) // Checking to prevent the same item from spawning in all lanes
        {
            spawnCoinsOnly(); // If the same item spawns, replace it with coins
        }
        else
        {
            spawnRandomItems();
        }

        //calling spawnItems() again after some time
        Invoke("spawnItems", gameManager.ItemSpawningDelay);
    }


    private void spawnRandomItems()
    {
        //spawning random item on pos1, po2, pos3
        Instantiate(items[ItemSpawningAtSpawnPos[0]], spawnPos[0].position, Quaternion.identity, spawnedObjects);
        Instantiate(items[ItemSpawningAtSpawnPos[1]], spawnPos[1].position, Quaternion.identity, spawnedObjects);
        Instantiate(items[ItemSpawningAtSpawnPos[2]], spawnPos[2].position, Quaternion.identity, spawnedObjects);

        specialItemSpawnAfter = specialItemSpawnAfter - 1;

    }

    private void spawnCoinsOnly()
    {
        //spawning coin on pos1, po2, pos3
        Instantiate(coin, spawnPos[0].position, Quaternion.identity, spawnedObjects);
        Instantiate(coin, spawnPos[1].position, Quaternion.identity, spawnedObjects);
        Instantiate(coin, spawnPos[2].position, Quaternion.identity, spawnedObjects);

        specialItemSpawnAfter = specialItemSpawnAfter - 1;
    }

    private void spawnSpecialItems()
    {
        //Spawning Special Item at random Lane
        int x = Random.Range(0, ItemSpawningAtSpawnPos.Length);
        Instantiate(specialItems[Random.Range(0, specialItems.Length)], spawnPos[x].position, Quaternion.identity, spawnedObjects);

        //Spawning Other items at emty lane
        for (int i = 0; i < spawnPos.Length; i++)
        {
            //checking the lane is emty or not
            if(i != x)
                Instantiate(items[Random.Range(0, items.Length)], spawnPos[i].position, Quaternion.identity, spawnedObjects);
        }
    }


}