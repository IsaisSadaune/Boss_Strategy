using UnityEngine;
using System.Collections.Generic;

public abstract class StrategyData : ScriptableObject, IPatterns
{
    public float cooldownAfterPattern;

    public abstract void ApplyStrategy(Rigidbody r);
    public abstract bool IsStrategyAppliable(List<StrategyData> lastPattern);
    public virtual List<StrategyData> NextPatterns() => null;



}
