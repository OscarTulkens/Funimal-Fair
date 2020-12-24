using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private RotationAxis _rotationAxis = RotationAxis.X;
    [SerializeField] private float _rotationSpeed = 0;
    [SerializeField] private bool _keepChildGlobalRotation = false;
    [SerializeField] private List<Transform> _childrenToRotate = new List<Transform>();
    private List<Vector3> _childrenStartRotation = new List<Vector3>();
    private Vector3 _rotationAxisVar = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        SetRotationAxis();
        SaveStartRotation();
    }

    // Update is called once per frame
    void Update()
    {
        RotateMainObject();
        RotateChildren();
    }

    enum RotationAxis
    {
        X,
        Y,
        Z
    }

    private void RotateMainObject()
    {
        transform.Rotate(_rotationAxisVar, Time.deltaTime * _rotationSpeed);
    }

    private void RotateChildren()
    {
        for (int i = 0; i < _childrenToRotate.Count; i++)
        {
            if (_keepChildGlobalRotation)
            {
                _childrenToRotate[i].transform.localRotation = Quaternion.Euler(_childrenStartRotation[i]);
            }
            _childrenToRotate[i].RotateAround(transform.position, _rotationAxisVar, _rotationSpeed * Time.deltaTime);
        }

    }

    private void SetRotationAxis()
    {
        switch (_rotationAxis)
        {
            case RotationAxis.X:
                _rotationAxisVar = Vector3.right;
                break;
            case RotationAxis.Y:
                _rotationAxisVar = Vector3.up;
                break;
            case RotationAxis.Z:
                _rotationAxisVar = Vector3.back;
                break;
            default:
                break;
        }
    }

    private void SaveStartRotation()
    {
        foreach (Transform child in _childrenToRotate)
        {
            _childrenStartRotation.Add(child.rotation.eulerAngles);
        }

    }
}
