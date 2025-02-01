using System;
using UnityEngine;

public class SpreadEventArgs: EventArgs
{   
    private Touch[] _trackedFingers;
    public Touch[] TrackedFingers
    {
        get { return this._trackedFingers; }
    }

    private float _distanceDelta;
    public float DistanceDelta 
    {
        get{ return this._distanceDelta; }
    }

    public SpreadEventArgs(Touch[] trackedFingers, float distanceDelta) 
    {
        this._trackedFingers = trackedFingers;
        this._distanceDelta = distanceDelta;
    }
}
