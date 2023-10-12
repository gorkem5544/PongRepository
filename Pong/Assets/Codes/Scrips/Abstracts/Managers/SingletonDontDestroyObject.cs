using UnityEngine;



public abstract class SingletonDontDestroyObject<T> : SingletonMonoObject<T> where T : MonoBehaviour
{


    protected override void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }
}
