using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Defense", menuName = "Patterns/Defense")]
public class Defense : StrategyData
{
    public override void ApplyStrategy(Rigidbody r)
    {
        r.MovePosition(new Vector3(0, 0, 0));
        Debug.Log("Defense");
    }
    public override bool IsStrategyAppliable(List<StrategyData> lastPattern) => lastPattern[^1] is not Defense;
}
