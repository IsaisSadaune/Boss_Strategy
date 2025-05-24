using UnityEngine;
using System.Collections;

public class BombDestroyer : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        Destroy(this.gameObject);
    }


}
