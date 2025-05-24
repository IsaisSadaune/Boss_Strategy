using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu(fileName = "Up", menuName = "Patterns/Directions/Up")]
public class Up : Idle
{
    public override void ApplyStrategy(Rigidbody r)
    {
        r.MovePosition(r.position + Vector3.forward);
    }

    public override bool IsStrategyAppliable(List<StrategyData> d, Rigidbody rb) => CanGoUp(rb.transform);

    public override List<StrategyData> NextPatterns() => new() { this };
}
