using MidiJack;
using UnityEngine;

public class Jumpy : MonoBehaviour
{
    [Tooltip("Height of the jump on MIDI input")]
    public float jumpHeight = 5f;

    [Tooltip("Time taken in seconds for the jump to stabilize")]
    public float stabilizeDuration = 2f;

    [Tooltip("MIDI channel under which the note is played")]
    public MidiChannel midiChannel = MidiChannel.Ch10;

    [Tooltip("Note which triggers the jump")]
    public int noteNumber = 0x3C;
    
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
        if (MidiMaster.GetKeyDown(midiChannel, noteNumber))
        {
            Jump();
        }

        Stabilize();
    }
}