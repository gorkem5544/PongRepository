using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingBall
{
    IPlayerController _playerController;
    private bool _canLaunch = true;
    public LaunchingBall(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    public void LaunchBall()
    {
        if (!GameManager.Instance.GameStarted && _playerController.PlayerInput.MouseClick)
        {
            GameManager.Instance.GameStarted = true;
            Debug.Log(_canLaunch + "||" + _playerController.PlayerInput.MouseClick);
            _playerController.BallController.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 150f, ForceMode2D.Force);
        }
    }



}
