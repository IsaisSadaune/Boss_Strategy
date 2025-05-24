using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu(fileName = "Left", menuName = "Patterns/Directions/Left")]
public class Left : Idle
{
    public override void ApplyStrategy(Rigidbody r)
    {
        r.MovePosition(r.position + Vector3.left);
    }

    public override bool IsStrategyAppliable(List<StrategyData> d, Rigidbody rb) => CanGoLeft(rb.transform);

    public override List<StrategyData> NextPatterns() => new() { this };
}
