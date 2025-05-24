using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu(fileName = "Right", menuName = "Patterns/Directions/Right")]
public class Right : Idle
{
    public override void ApplyStrategy(Rigidbody r)
    {
        r.MovePosition(r.position + Vector3.right);
    }

    public override bool IsStrategyAppliable(List<StrategyData> d, Rigidbody rb) => CanGoRight(rb.transform);

    public override List<StrategyData> NextPatterns() => new() { this };
}
