using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Gun", menuName = "Patterns/Gun")]
public class Gun : StrategyData
{
    public override void ApplyStrategy(Rigidbody r)
    {
        Debug.Log("GUN");
        r.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }
    public override bool IsStrategyAppliable(List<StrategyData> lastPattern, Rigidbody rb) => lastPattern[^1] is not Gun;
}
