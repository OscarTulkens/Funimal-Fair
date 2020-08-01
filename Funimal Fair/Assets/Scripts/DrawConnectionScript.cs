using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class DrawConnectionScript : MonoBehaviour
{
    private LineRenderer _lineRenderer = null;

    private void Awake()
    {
        UpdateLineSettings();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTileConnection();
    }

    public void UpdateTileConnection()
    {
        _lineRenderer.SetPosition(0, new Vector3(transform.position.x, 0, transform.position.z));
        if (this.GetComponent<BaseTileScript>().NextTile!=null)
        {
            Vector3 nexttilePos = this.GetComponent<BaseTileScript>().NextTile.transform.position;
            _lineRenderer.SetPosition(1, new Vector3(nexttilePos.x, 0, nexttilePos.z));
        }
        UpdateLineSettings();
    }

    private void UpdateLineSettings()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.alignment = LineAlignment.TransformZ;
        _lineRenderer.widthMultiplier = 0.2f;
    }
}
