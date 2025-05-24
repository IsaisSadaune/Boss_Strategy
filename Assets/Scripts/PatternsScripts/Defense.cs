using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Defense", menuName = "Patterns/Defense")]
public class Defense : StrategyData
{
    public override void ApplyStrategy(Rigidbody r)
    {
        r.MovePosition(Vector3.zero);
        Debug.Log("Defense");
    }
    public override bool IsStrategyAppliable(List<StrategyData> lastPattern, Rigidbody rb) => lastPattern[^1] is not Defense;
}
