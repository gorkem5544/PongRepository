using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BallController : MonoBehaviour, IEntityController
{
    [SerializeField] PlayerController _playerController;
    private void Update()
    {
        if (!GameManager.Instance.GameStarted)
        {

            this.transform.position = new Vector2(transform.position.x, _playerController.transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.collider.gameObject.CompareTag("EnemyGoal"))
        {
        }*/
        if (other.collider.gameObject.CompareTag("PlayerGoal"))
        {
            GameManager.Instance.IncreaseScore(1);

        }
        /*
        else if (other.collider.gameObject.CompareTag("Platform"))
        {

        }*/
        GetComponent<Rigidbody2D>().velocity = new Vector2();
    }
}
