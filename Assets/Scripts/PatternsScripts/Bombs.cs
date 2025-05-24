using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Bombs", menuName = "Patterns/Bombs")]
public class Bombs : StrategyData
{
    public GameObject bombs;

    public StrategyData attackPattern;
    public override void ApplyStrategy(Rigidbody r)
    {
        Instantiate(bombs, r.position + Vector3.forward, Quaternion.identity);
        Instantiate(bombs, r.position + Vector3.back, Quaternion.identity);
        Instantiate(bombs, r.position + Vector3.left, Quaternion.identity);
        Instantiate(bombs, r.position + Vector3.right, Quaternion.identity);
    }

    public override bool IsStrategyAppliable(List<StrategyData> lastPattern) => !lastPattern.Find( x => x is Bombs);

    public override List<StrategyData> NextPatterns() => new() { attackPattern, attackPattern, attackPattern };
}
