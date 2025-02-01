using System;
using UnityEngine;

[Serializable]
public class SpreadProperty
{
    [SerializeField]
    private float _minDistanceChange = 0.5f;
    public float MinDistanceChange 
    {
        get {return this._minDistanceChange; }
        set {this._minDistanceChange = value; }
    }
}

