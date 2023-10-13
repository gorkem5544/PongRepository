using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Abstracts.Uis
{
    public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] Button _button;
    private void OnEnable()
    {
        _button.onClick.AddListener(HandleOnButtonClicked);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleOnButtonClicked);
    }
    public abstract void HandleOnButtonClicked();
}

}