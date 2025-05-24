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


    private IEnumerator Cooldown_NextPattern()
    {
        IPatterns.ResetPatternsComponents(boss.transform);
        Strategy();
        yield return new WaitForSeconds(TimeBetweenTwoPatterns());
    }


    //Choisit une strategie et l'applique depuis le pool
    [ContextMenu("Strategy")]
    public void Strategy()
    {
        StrategyData pattern;
        if (NextPatterns.Count != 0 && NextPatterns[0].IsStrategyAppliable(lastPatterns))
        {
            pattern = NextPatterns[0];
            NextPatterns.Remove(pattern);
        }
        else
        {
            pattern = patternsList[Random.Range(0, patternsList.Count)];
            NextPatterns.Clear();
        }

        if (!pattern.IsStrategyAppliable(lastPatterns))
        {
            //Si pas possible de se déplacer, tp au spawn (normalement ça n'arrive jamais)
            pattern = idlePattern.IsStrategyAppliable(lastPatterns) ? idlePattern : teleportPattern;
        }
        actualPattern = pattern;
        StartCoroutine(Cooldown_NextPattern());

        pattern.ApplyStrategy(rb);
        if (NextPatterns.Count == 0 && pattern.NextPatterns() != null) NextPatterns.AddRange(pattern.NextPatterns());
        AddPatternToHistory(pattern);
    }

    //si le pattern suivant et précédent sont des idle, alors le cube va plus vite
    private float TimeBetweenTwoPatterns() => 0.2f;

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
}
