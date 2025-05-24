using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu(fileName = "Down", menuName = "Patterns/Directions/Down")]
public class Down : Idle
{
    public override void ApplyStrategy(Rigidbody r)
    {
        r.MovePosition(r.position + Vector3.back);
    }

    public override bool IsStrategyAppliable(List<StrategyData> d, Rigidbody rb) => CanGoDown(rb.transform);

    public override List<StrategyData> NextPatterns() => new() { this };
}
