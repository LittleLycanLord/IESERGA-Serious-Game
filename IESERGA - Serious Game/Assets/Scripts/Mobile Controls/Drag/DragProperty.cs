using System;
using UnityEngine;

[Serializable]
public class DragProperty 
{
    [Tooltip("Minimum allowable time to consider an action a drag")]
    [SerializeField]
    private float _time = 0.0f;
    public float Time
    {   
        get { return this._time; }
        set { this._time = value; }
    }
   
}
