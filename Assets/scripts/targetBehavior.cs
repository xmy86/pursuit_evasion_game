using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public void Initialize()
    {
        transform.localPosition = new Vector3(Random.Range(-1.5f, 1.5f), 0.5f, Random.Range(-1f, 1f));
    }
    
}
