using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenObjectIcanUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public void Show(Sprite _sprite)
    {
        gameObject.SetActive(true);
        iconImage.sprite = _sprite;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
