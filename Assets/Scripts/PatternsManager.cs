using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsManager : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private Rigidbody rb;

    [SerializeField] private List<StrategyData> patternsList;

    [Tooltip("Anti Softlock")][SerializeField] private StrategyData idlePattern;
    [Tooltip("Super Anti Softlock")][SerializeField] private StrategyData teleportPattern;
    private StrategyData actualPattern = null;

    public List<StrategyData> NextPatterns { get; private set; } = new();

    //Last 10 moves
    private List<StrategyData> lastPatterns = new();



    private void Awake()
    {
        rb = boss.GetComponent<Rigidbody>();
        FillHistory();
    }

    private void Start()
    {
        StartCoroutine(Cooldown_NextPattern());
    }



    //Choisit une strategie et l'applique depuis le pool
    [ContextMenu("Strategy")]
    public void Strategy()
    {
        StrategyData pattern;
        if (NextPatterns.Count != 0)
        {
            if (NextPatterns[0].IsStrategyAppliable(lastPatterns, rb))
            {
                pattern = NextPatterns[0];
                NextPatterns.Remove(pattern);
            }
            else
            {
                pattern = idlePattern;
                NextPatterns.Clear();
            }
        }
        else
        {
            pattern = patternsList[Random.Range(0, patternsList.Count)];
            NextPatterns.Clear();
        }

        if (!pattern.IsStrategyAppliable(lastPatterns, rb))
        {
            //Si pas possible de se déplacer, tp au spawn (normalement ça n'arrive jamais)
            pattern = idlePattern.IsStrategyAppliable(lastPatterns, rb) ? idlePattern : teleportPattern;
        }
        actualPattern = pattern;

        pattern.ApplyStrategy(rb);
        if (NextPatterns.Count == 0 && pattern.NextPatterns() != null) NextPatterns.AddRange(pattern.NextPatterns());
        AddPatternToHistory(pattern);

        StartCoroutine(Cooldown_NextPattern());
    }

    //si le pattern suivant et précédent sont des idle, alors le cube va plus vite
    private float TimeBetweenTwoPatterns() => actualPattern != null ? actualPattern.cooldownAfterPattern : 0.5f;

    private void AddPatternToHistory(StrategyData pattern)
    {
        lastPatterns.Add(pattern);
        while (lastPatterns.Count > 10)
        {
            lastPatterns.RemoveAt(0);
        }
    }



    private void FillHistory()
    {
        while (lastPatterns.Count < 10)
        {
            lastPatterns.Add(teleportPattern);
        }
    }
    private IEnumerator Cooldown_NextPattern()
    {
        yield return new WaitForSeconds(TimeBetweenTwoPatterns());
        IPatterns.ResetPatternsComponents(boss.transform);
        Strategy();
    }

}
