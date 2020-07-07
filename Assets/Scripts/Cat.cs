using UnityEngine;

public class Cat : MonoBehaviour
{
    [Tooltip("Physics body of the cat")]
    public Rigidbody body;
    
    [Tooltip("Renderer of the cats body")]
    public Renderer bodyRenderer;

    /// <summary>
    /// Poofs the cat out of existence.
    /// </summary>
    public void Poof()
    {
        bodyRenderer.enabled = false;
        body.isKinematic = true;
    }

    /// <summary>
    /// Un-poofs the poof-ing.
    /// </summary>
    public void UnPoof()
    {
        bodyRenderer.enabled = true;
        body.isKinematic = false;
    }

    /// <summary>
    /// Moves cat to given position and rotation.
    /// </summary>
    public void Move(Vector3 position, Quaternion rotation)
    {
        var tr = transform;
        
        tr.position = position;
        tr.rotation = rotation;
    }
}