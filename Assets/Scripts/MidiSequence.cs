using MidiJack;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Sequence/MidiSequence", order = 1)]
public class MidiSequence : Sequence
{
    [Tooltip("MIDI channel under which the note is played")]
    public MidiChannel midiChannel = MidiChannel.Ch10;

    [Tooltip("Note which triggers the jump")]
    public int noteNumber = 0x3C;

    public override bool IsDown => GetKeyDown();

    private bool GetKeyDown()
    {
        return MidiMaster.GetKeyDown(midiChannel, noteNumber);
    }
}