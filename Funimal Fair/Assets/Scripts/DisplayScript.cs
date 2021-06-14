using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteComponent = null;
    [SerializeField] private Text _displayTextComponent = null;
    private int _amount = 0;

    public int GetAmount()
    {
        return _amount;
    }

    public void SetAmount(int amount)
    {
        _amount = amount;
        if (_amount == 1)
        {
            _displayTextComponent.enabled = false;
        }
        else
        {
            _displayTextComponent.enabled = true;
            _displayTextComponent.text = _amount.ToString();
        }
    }

    public void SetImage(Sprite sprite)
    {
        _spriteComponent.sprite = sprite;
    }

}
