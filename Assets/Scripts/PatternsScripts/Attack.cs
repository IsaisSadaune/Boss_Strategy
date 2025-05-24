using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Attack", menuName = "Patterns/Attack")]
public class Attack : StrategyData
{
    public override void ApplyStrategy(Rigidbody r)
    {
        Debug.Log("ATK");
        r.transform.localScale *= 4;
    }
    public override bool IsStrategyAppliable(List<StrategyData> lastPattern) => lastPattern[^1] is not Attack;
}
