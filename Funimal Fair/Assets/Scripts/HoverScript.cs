using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    private Vector3 _startPosition = Vector3.zero;
    public Vector3 HoverOffset = Vector3.zero;
    public float HoverTime = 0;
    public float Delay = 0;

    private int _hoverID = 0;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.localPosition;
        StartHover();
    }

    public void StartHover()
    {
        StartHover(_startPosition, Delay);
    }

    public void StartHover(Vector3 centerpos, float delay)
    {
        _hoverID = LeanTween.moveLocal(gameObject, centerpos + HoverOffset, HoverTime).setEaseInOutSine().setLoopPingPong().setDelay(delay).id;
    }

    public void StopHover()
    {
        LeanTween.cancel(_hoverID);
    }

    public void PauseHover()
    {
        LeanTween.pause(_hoverID);
    }

    public void ResumeHover()
    {
        LeanTween.resume(_hoverID);
    }
}
