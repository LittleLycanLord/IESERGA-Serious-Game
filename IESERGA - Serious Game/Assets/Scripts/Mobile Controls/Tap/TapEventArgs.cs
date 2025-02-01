using System;
using UnityEngine;

public class TapEventArgs : EventArgs
{
    private Vector2 _position;
    public Vector2 Position
    {
        get { return this._position; }
        set { this._position = value; }
    }

    private GameObject _hitObject;
    public GameObject HitObject
    {
        get { return this._hitObject; }
    }

    public TapEventArgs(Vector2 position, GameObject HitObject)
    {
        this._position = position;
        this._hitObject = HitObject;
    }
}
