using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts
{
    public abstract class SingletonMonoObject<T> : MonoBehaviour, IManager where T : MonoBehaviour
    {
        public static T Instance { get; protected set; }

        protected virtual void Awake()
        {
            SetSingletonMono();
        }

        public abstract void SetSingletonMono();
    }
}