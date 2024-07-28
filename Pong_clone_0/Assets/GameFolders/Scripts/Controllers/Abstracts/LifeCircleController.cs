using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Abstracts
{
    public abstract class LifeCircleController : MonoBehaviour
    {

        [SerializeField] float _maxLifeTime;
        protected float _currentLifeTime;

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > _maxLifeTime)
            {
                DestroyObject();
            }
        }

        protected abstract void DestroyObject();
    }

}