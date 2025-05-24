using UnityEngine;
using System.Collections.Generic;

public interface IPatterns
{
    public void ApplyStrategy(Rigidbody r);
    public bool IsStrategyAppliable(List<StrategyData> lastPattern, Rigidbody rb);
    private static void ResetScale(Transform t) => t.localScale = Vector3.one;
    private static void ResetGun(Transform t) => t.GetChild(0).GetChild(0).gameObject.SetActive(false);
    public static void ResetPatternsComponents(Transform t)
    {
        ResetScale(t);
        ResetGun(t);
    }
}
