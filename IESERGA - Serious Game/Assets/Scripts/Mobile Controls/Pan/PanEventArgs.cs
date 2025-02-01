using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanEventArgs : EventArgs
{
    private Touch[] _trackedFingers;
    public Touch[] TrackedFingers
    {
        get { return this._trackedFingers; }
    }

    public PanEventArgs(Touch[] trackedFingers)
    {
        this._trackedFingers = trackedFingers;
    }
}
