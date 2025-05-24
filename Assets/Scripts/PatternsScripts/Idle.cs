using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Idle", menuName = "Patterns/Idle", order = 1)]
public class Idle : StrategyData
{
    public override void ApplyStrategy(Rigidbody r)
    {
        bool down = CanGoDown(r.transform);
        bool up = CanGoUp(r.transform);
        bool left = CanGoLeft(r.transform);
        bool right = CanGoRight(r.transform);
        if (!down && !up && !left && !right)
        {
            Debug.Log("softlock");
        }
        else
        {
            bool canMove = false;
            int x = Random.Range(0, 4);
            while (!canMove)
            {
                try
                {
                    switch (x)
                    {
                        case 0:
                            if (down)
                            {
                                r.MovePosition(r.position + Vector3.back);
                                canMove = true;
                            }
                            break;

                        case 1:
                            if (up)
                            {
                                r.MovePosition(r.position + Vector3.forward);
                                canMove = true;
                            }
                            break;

                        case 2:
                            if (left)
                            {
                                r.MovePosition(r.position + Vector3.left);
                                canMove = true;
                            }
                            break;

                        case 3:
                            if (right)
                            {
                                r.MovePosition(r.position + Vector3.right);
                                canMove = true;
                            }

                            break;
                    }
                }
                finally
                {
                    x++;
                    x %= 4;
                }
            }
            Debug.Log("Idle");
        }
    }
    public override bool IsStrategyAppliable(List<StrategyData> d, Rigidbody rb) => true;

    protected bool CanGoLeft(Transform t) => t.position.x > -4;
    protected bool CanGoRight(Transform t) => t.position.x < 4;
    protected bool CanGoUp(Transform t) => t.position.z < 4;
    protected bool CanGoDown(Transform t) => t.position.z > -4;
}


