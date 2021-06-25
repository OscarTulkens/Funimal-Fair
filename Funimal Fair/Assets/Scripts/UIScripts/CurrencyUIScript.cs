using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyUIScript : MonoBehaviour
{
    [SerializeField] private Text _currencyText = null;
    [SerializeField] private float _updateTime = 0;
    private int _currentValue = 0;
    private int _lastValue = 0;
    private void Start()
    {
        EventManagerScript.instance.OnUpdateCurrencyUI += UpdateCurrencyUI;
        //loadStartCurrencyValue
        _currencyText.text = "000";
    }

    private void UpdateCurrencyUI(object sender, EventManagerScript.OnUpdateCurrencyUIArgs e)
    {
        LeanTween.value(gameObject, e.Total - e.ChangeAmount, e.Total, e.ChangeAmount* _updateTime).setOnUpdate((float val) => { _currentValue = (int)val; DoUIUpdate(); });
    }

    private void DoUIUpdate()
    {
        if (_currentValue!=_lastValue)
        {
            _currencyText.text = _currentValue.ToString("000");
            LeanTween.scale(_currencyText.gameObject, Vector3.one * 1.3f, _updateTime*0.9f).setEasePunch();
        }

        _lastValue = _currentValue;
    }
}
