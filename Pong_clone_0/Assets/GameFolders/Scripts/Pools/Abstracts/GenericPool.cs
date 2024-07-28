using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts
{
    public class GenericPool<T, S> : SingletonDontDestroyMono<S> where T : Component where S : MonoBehaviour
    {
        [SerializeField] T _poolPrefabs;
        [SerializeField] int _count;
        
        Queue<T> _poolList = new Queue<T>();

        private void Start()
        {
            GrowPool();
        }
        /// <summary>
        /// Queue listemizde T objesi yok ise GrowPool methodu ile yeni T objeleri yaratır ve bu objeleri bize döner  
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            if (_poolList.Count == 0)
            {
                GrowPool();
            }
            return _poolList.Dequeue();
        }

        /// <summary>
        /// _count kadar bize yeni T objeleri Instantiate eder ve bunlaru queue listemizin içine alır 
        /// </summary>
        private void GrowPool()
        {
            for (int i = 0; i < _count; i++)
            {
                T newPool = Instantiate(_poolPrefabs);
                newPool.gameObject.SetActive(false);
                newPool.transform.parent = this.transform;
                _poolList.Enqueue(newPool);
            }
        }

    /// <summary>
    /// Parametredeki T objesini aktifliğini kapatır
    /// bu objeyi queue listemize alır
    /// </summary>
    /// <param name="pool"></param>
        public void SetPool(T pool)
        {
            pool.gameObject.SetActive(false);
            _poolList.Enqueue(pool);
        }
    }

}