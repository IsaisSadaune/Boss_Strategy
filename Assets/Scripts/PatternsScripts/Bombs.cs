using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Bombs", menuName = "Patterns/Bombs")]
public class Bombs : StrategyData
{
    public GameObject bombs;

    public List<StrategyData> nextPatterns;
    public override void ApplyStrategy(Rigidbody r)
    {
        Instantiate(bombs, r.position + Vector3.forward, Quaternion.identity);
        Instantiate(bombs, r.position + Vector3.back, Quaternion.identity);
        Instantiate(bombs, r.position + Vector3.left, Quaternion.identity);
        Instantiate(bombs, r.position + Vector3.right, Quaternion.identity);
    }

    //public override bool IsStrategyAppliable(List<StrategyData> lastPattern, Rigidbody rb) => !lastPattern.Find( x => x is Bombs);
    public override bool IsStrategyAppliable(List<StrategyData> lastPattern, Rigidbody rb) => true;

    public override List<StrategyData> NextPatterns() => nextPatterns;
}
