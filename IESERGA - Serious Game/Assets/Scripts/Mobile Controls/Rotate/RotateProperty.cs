using System;
using UnityEngine;

[Serializable]
public class RotateProperty 
{
    [SerializeField]
    private float _minDistance = 0.75f;
    public float MinDistance
    {
        get { return this._minDistance; }
        set { this._minDistance = value; }
    }

    [SerializeField]
    private float _minRotationChange = 0.4f;
    public float MinRotationChange 
    {
        get { return this._minRotationChange; }
        set { this._minRotationChange = value; }
    }
}
