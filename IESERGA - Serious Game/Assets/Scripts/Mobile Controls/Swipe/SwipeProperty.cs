using UnityEngine;
using System;

[Serializable]
public class SwipeProperty {

    [SerializeField]
    private float _time = 2.0f;
    public float Time
    {
        get { return this._time; }
        set { this._time = value; }
    }

    [SerializeField]
    private float _minDistance = 0.5f;
    public float MinDistance
    {
        get { return this._minDistance; }
        set { this._minDistance = value; }
    }

    [Range(0,1)]
    [SerializeField]
    private int _moveType = 0;
    public int MoveType 
    {
        get { return this._moveType; }
        set { this._moveType = value; }
    }
}
