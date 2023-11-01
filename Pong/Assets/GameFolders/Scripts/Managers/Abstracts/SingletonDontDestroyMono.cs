using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts
{
    public abstract class SingletonDontDestroyMono<T> : SingletonMonoObject<T> where T : MonoBehaviour
    {
        public override void SetSingletonMono()
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
}