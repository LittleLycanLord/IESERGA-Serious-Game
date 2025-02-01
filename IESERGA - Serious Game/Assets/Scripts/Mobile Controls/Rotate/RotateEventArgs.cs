using System;
using UnityEngine;

public class RotateEventArgs: EventArgs
{   
    private Touch[] _trackedFingers;
    public Touch[] TrackedFingers
    {
        get { return this._trackedFingers; }
    }

    private ERotateDirection _rotateDirection;
    public ERotateDirection RotateDirection
    {
        get { return this._rotateDirection; }
    }

    private float _angle;
    public float Angle
    {
        get { return this._angle; }
    }

    private GameObject _hitObject;
    public GameObject HitObject
    {
        get { return this._hitObject; }
    }

    public RotateEventArgs(Touch[] trackedFingers, ERotateDirection direction, float angle, GameObject hitobject = null) 
    {
        this._trackedFingers = trackedFingers;
        this._rotateDirection = direction;
        this._angle = angle;
        this._hitObject = hitobject;
    }
}


