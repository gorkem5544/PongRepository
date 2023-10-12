using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartingObj : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _gameStartingInfoText;

    private void Awake()
    {

    }
    public void DeActiveGameStartingInfoText()
    {
        if (_gameStartingInfoText.gameObject.activeSelf == true)
        {
            _gameStartingInfoText.gameObject.SetActive(false);
        }
    }
    public void ActiveGameStartingInfoText()
    {
        if (_gameStartingInfoText.gameObject.activeSelf == false)
        {
            _gameStartingInfoText.gameObject.SetActive(true);
        }
    }
}
