using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonDontDestroyMono<T> : SingletonMonoObject<T> where T : MonoBehaviour
{
    protected override void SetSingletonMono()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}