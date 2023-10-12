using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoObject<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }

    protected virtual void Awake()
    {
        SetSingletonMono();
    }

    protected abstract void SetSingletonMono();
}