using UnityEngine;

public class NoCatZone : MonoBehaviour
{
    [Tooltip("Manager which will handle cat events")]
    public CatManager manager;

    private void OnTriggerEnter(Collider other)
    {
        var cat = other.GetComponent<Cat>();
        if (cat == null)
        {
            return;
        }
        
        StartCoroutine(manager.ReSpawn(cat));
    }
}
