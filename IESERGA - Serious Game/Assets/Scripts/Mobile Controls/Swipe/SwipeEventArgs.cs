using UnityEngine;
using System;

public class SwipeEventArgs : EventArgs
{
    private ESwipeDirection _direction;
    public ESwipeDirection Direction
    {
        get { return this._direction; }
    }

    private Vector2 _rawDirection;
    public Vector2 RawDirection
    {
        get { return this._rawDirection; }
    }

    private Vector2 _position;
    public Vector2 Position
    {
        get { return this._position; }
    }

    public SwipeEventArgs(ESwipeDirection direction, Vector2 rawDirection, Vector2 position)
    {
         this._direction = direction;
         this._rawDirection = rawDirection;
         this._position = position;
    }
}
