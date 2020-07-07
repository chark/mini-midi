using UnityEngine;

public abstract class Sequence : ScriptableObject
{
    /// <summary>
    /// Is the sequence pressed down for the current step.
    /// </summary>
    public abstract bool IsDown { get; }
}
