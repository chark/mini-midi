using UnityEngine;

public class Jumpy : MonoBehaviour
{
    [Tooltip("Height of the jump on MIDI input")]
    public float jumpHeight = 5f;

    [Tooltip("Time taken in seconds for the jump to stabilize")]
    public float stabilizeDuration = 2f;

    [Tooltip("Sequence which causes the jumps")]
    public Sequence sequence;
    
    private Vector3 initialPosition;
    private float jumpTime;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Jump()
    {
        var position = transform.position;
        position.y += jumpHeight;

        transform.position = position;
        jumpTime = Time.time;
    }

    private Vector3 GetPosition()
    {
        var progress = (Time.time - jumpTime) / stabilizeDuration;

        return Vector3.Lerp(
            transform.position,
            initialPosition,
            progress
        );
    }

    private void Stabilize()
    {
        transform.position = GetPosition();
    }

    private void Update()
    {
        if (sequence.IsDown)
        {
            Jump();
        }

        Stabilize();
    }
}