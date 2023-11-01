using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class ParticleManager : SingletonDontDestroyMono<ParticleManager>
    {
        List<GameObject> _gameWinParticles = new List<GameObject>();
        [SerializeField] GameObject _ballHitParticle;

        private void Start()
        {
            StopAllParticle();
        }
        protected override void Awake()
        {
            base.Awake();
            _gameWinParticles.Add(GameObject.FindGameObjectWithTag("GameWinParticle"));
        }
        private void OnEnable()
        {
            _gameWinParticles.Add(GameObject.FindGameObjectWithTag("GameWinParticle"));
            GameWinParticleStop();
        }


        public void BallHitParticleMethod(Vector2 pos)
        {
            GameObject newBallHitParticle = Instantiate(_ballHitParticle, pos, Quaternion.identity);
            newBallHitParticle.gameObject.SetActive(true);
            Destroy(newBallHitParticle, 1f);
        }
        public void GameWinParticleStart()
        {
            foreach (GameObject item in _gameWinParticles)
            {
                item.SetActive(true);
            }
        }
        public void GameWinParticleStop()
        {
            StopAllParticle();
        }
        public void StopAllParticle()
        {
            foreach (GameObject item in _gameWinParticles)
            {
                item.SetActive(false);
            }
        }
    }

}