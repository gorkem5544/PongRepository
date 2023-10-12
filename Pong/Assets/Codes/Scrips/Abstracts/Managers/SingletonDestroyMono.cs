using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonDestroyMono<T> : SingletonMonoObject<T> where T: MonoBehaviour
{
    protected override void SetSingletonMono()
    {
        Instance = this as T;
    }
}
