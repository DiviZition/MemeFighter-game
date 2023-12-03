using UnityEngine;

public interface IBoostEffect
{
    public Sprite EffectsIcon { get; }
    public TypeOfEffect TypeOfEffect { get; }
    public bool IsEnded { get; }
    public float Progress { get; }
    
    /// <summary> Runs all the time, until "IsEnded" becomes true </summary>
    public void DoLogic(PlayerComponents components);
    /// <summary> Call this method when an effect is ends. It resets effect so u can reuse it </summary>
    public void ResetValues();
    public void ForceQuit();
}