using UnityEngine;
using System;

public class DragEventArgs : EventArgs
{
    private Touch _trackedFinger;
    public Touch TrackedFinger
    {
        get { return this._trackedFinger; }
    }

    private GameObject _hitObject;
    public GameObject HitObject
    {
        get { return this._hitObject; }
    }

    public DragEventArgs(Touch trackedFinger, GameObject hitobject = null)
    {
        this._trackedFinger = trackedFinger;
        this._hitObject = hitobject;
    }
}
