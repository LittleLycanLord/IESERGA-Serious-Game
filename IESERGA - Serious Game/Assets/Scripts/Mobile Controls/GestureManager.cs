using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;

    private Touch[] _trackedFingers = new Touch[2];
    private float _gestureTime;
    private Vector2 _startPoint = Vector2.zero;
    private Vector2 _endPoint = Vector2.zero;

    [SerializeField]
    private bool _isInPuzzlet;
    public bool IsInPuzzlet
    {
        get { return this._isInPuzzlet; }
        set { this._isInPuzzlet = value; }
    }

    [SerializeField]
    private GameObject _puzzleCamera;

    [SerializeField] private TapProperty _tapProperty;
    public EventHandler<TapEventArgs> OnTap;

    [SerializeField] private SwipeProperty _swipeProperty;
    public EventHandler<SwipeEventArgs> OnSwipe;

    [SerializeField] private DragProperty _dragProperty;
    public EventHandler<DragEventArgs> OnDrag;

    [SerializeField] private PanProperty _panProperty;
    public EventHandler<PanEventArgs> OnPan;

    [SerializeField] private SpreadProperty _spreadProperty;
    public EventHandler<SpreadEventArgs> OnSpread;

    [SerializeField] private RotateProperty _rotateProperty;
    public EventHandler<RotateEventArgs> OnRotate;

    private void CheckTap()
    {
        if (this._gestureTime <= this._tapProperty.Time &&
            Vector2.Distance(this._startPoint, this._endPoint) < (Screen.dpi * this._tapProperty.MaxDistance))
            this.FireTapEvent();
    }

    private void FireTapEvent()
    {
        GameObject hitObject = this.GetHitObject(this._startPoint);
        TapEventArgs args = new TapEventArgs(_startPoint, hitObject);

        if (this.OnTap != null)
            this.OnTap(this, args);

        if (hitObject != null)
        {
            ITappable handler = hitObject.GetComponent<ITappable>();
            if (handler != null)
                handler.OnTap(args);
        }
    }

    private void CheckSwipe()
    {
        if (this._gestureTime <= this._swipeProperty.Time &&
            Vector2.Distance(this._startPoint, this._endPoint) >= (Screen.dpi * this._swipeProperty.MinDistance))
            this.FireSwipeEvent();
    }

    private void FireSwipeEvent()
    {
        Vector2 rawDirection = this._endPoint - this._startPoint;
        ESwipeDirection direction = this.GetSwipeDirection(rawDirection);

        SwipeEventArgs args = new SwipeEventArgs(direction, rawDirection, _startPoint);
        if (this.OnSwipe != null)
            this.OnSwipe(this, args);
    }

    private ESwipeDirection GetSwipeDirection(Vector2 rawDirection)
    {
        // Horizontal Swipe
        if (Mathf.Abs(rawDirection.x) > Mathf.Abs(rawDirection.y))
        {
            if (rawDirection.x > 0)
                return ESwipeDirection.RIGHT;
            else
                return ESwipeDirection.LEFT;
        }
        // Vertical Swipe
        else
        {
            if (rawDirection.y > 0)
                return ESwipeDirection.UP;
            else
                return ESwipeDirection.DOWN;
        }
    }

    private void CheckDrag()
    {
        if (this._startPoint.x >= Screen.width * 0.41)
            this.FireDragEvent();
    }

    private void FireDragEvent()
    {
        DragEventArgs args = new DragEventArgs(this._trackedFingers[0]);

        if (this.OnDrag != null)
            this.OnDrag(this, args);
    }

    private void CheckPan()
    {
        if (Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position) <= Screen.dpi * this._panProperty.MaxDistance)
            this.FirePanEvent();
    }

    private void FirePanEvent()
    {
        PanEventArgs args = new PanEventArgs(this._trackedFingers);
        if (this.OnPan != null)
            this.OnPan(this, args);
    }

    private void CheckSpread()
    {
        Vector2 previousPoint0 = this.GetPreviousPoint(this._trackedFingers[0]);
        Vector2 previousPoint1 = this.GetPreviousPoint(this._trackedFingers[1]);

        float previousDistance = Vector2.Distance(previousPoint0, previousPoint1);
        float currentDistance = Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position);

        float distanceDelta = currentDistance - previousDistance;

        if (Mathf.Abs(distanceDelta) >= this._spreadProperty.MinDistanceChange && !SceneManager.GetActiveScene().name.Contains("Port"))
            this.FireSpreadEvent(distanceDelta);
    }

    private void FireSpreadEvent(float distanceDelta)
    {
        SpreadEventArgs args = new SpreadEventArgs(this._trackedFingers, distanceDelta);

        if (this.OnSpread != null)
            this.OnSpread(this, args);
    }

    private void CheckRotate()
    {
        Vector2 previousPoint0 = this.GetPreviousPoint(this._trackedFingers[0]);
        Vector2 previousPoint1 = this.GetPreviousPoint(this._trackedFingers[1]);

        Vector2 previousDifference = previousPoint0 - previousPoint1;
        Vector2 currentDifference = this._trackedFingers[0].position - this._trackedFingers[1].position;

        float currentDistance = Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position);

        float angle = Vector2.Angle(previousDifference, currentDifference);

        if (angle >= this._rotateProperty.MinRotationChange &&
            currentDistance >= Screen.dpi * this._rotateProperty.MinDistance)
            this.FireRotateEvent(angle, previousDifference, currentDifference);
    }
    private void FireRotateEvent(float angle, Vector2 previousDifference, Vector2 currentDifference)
    {}

    private Vector2 GetMidpoint(Vector2 pointA, Vector2 pointB)
    {
        Vector2 midpoint = (pointA + pointB) / 2;

        return midpoint;
    }

    private GameObject GetHitObject(Vector2 screenPoint)
    {
        GameObject hitObject = null;
        Ray ray;
        
        if(this._isInPuzzlet == true)
           ray = _puzzleCamera.GetComponent<Camera>().ScreenPointToRay(screenPoint);
        else
            ray = Camera.main.ScreenPointToRay(screenPoint);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            hitObject = hit.collider.gameObject;

        return hitObject;
    }

    private Vector2 GetPreviousPoint(Touch finger)
    {
        Vector2 previousPoint = finger.position - finger.deltaPosition;

        return previousPoint;
    }

    private void CheckSingleFingerInput()
    {
        this._trackedFingers[0] = Input.GetTouch(0);
        switch (this._trackedFingers[0].phase)
        {
            case TouchPhase.Began:
                this._startPoint = this._trackedFingers[0].position;
                this._gestureTime = 0;
                break;

            case TouchPhase.Ended:
                this._endPoint = this._trackedFingers[0].position;
                this.CheckTap();
                this.CheckSwipe();
                break;

            default:
                this._gestureTime += Time.deltaTime;
                this.CheckDrag();
                break;
        }
    }

    private void CheckDualFingerInput()
    {
        this._trackedFingers[0] = Input.GetTouch(0);
        this._trackedFingers[1] = Input.GetTouch(1);

        switch (this._trackedFingers[0].phase, this._trackedFingers[1].phase)
        {
            case (TouchPhase.Moved, TouchPhase.Moved):
                this.CheckPan();
                break;
        }

        switch (this._trackedFingers[0].phase, this._trackedFingers[1].phase)
        {
            case (_, TouchPhase.Moved):
            case (TouchPhase.Moved, _):
                this.CheckSpread();
                this.CheckRotate();
                break;
        }
    }


    /* UNITY LIFECYCLE METHODS */
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.touchCount)
            {
                case 1:
                    this.CheckSingleFingerInput();
                    break;

                case 2:
                    this.CheckDualFingerInput();
                    break;
            }
        }
    }
}
