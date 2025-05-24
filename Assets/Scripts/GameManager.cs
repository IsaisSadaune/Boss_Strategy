using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int BossLife { get; private set; } = 100;
    public bool isProtecting = false;


    public void DamageBoss(int _damage) => 
        BossLife = Mathf.Clamp(BossLife - ApplyDefense(_damage), 0, BossLife);



    public int ApplyDefense(int _damage) => 
        isProtecting ? _damage - 1 : _damage;
}
