using System.Collections;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    [Tooltip("Time taken to spawn in seconds")]
    public float spawnTime = 3f;

    [Tooltip("Where the cat spawns")] 
    public Transform spawn;

    public IEnumerator ReSpawn(Cat cat)
    {
        cat.Poof();
        
        yield return new WaitForSeconds(spawnTime);
        
        cat.Move(spawn.position, spawn.rotation);
        cat.UnPoof();
    }
}
