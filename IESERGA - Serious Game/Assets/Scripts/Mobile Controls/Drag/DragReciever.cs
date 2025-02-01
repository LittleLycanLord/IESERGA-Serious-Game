using UnityEngine;

public class DragReciever : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    public void OnDrag(object sender, DragEventArgs args)
    {
        Vector2 deltaPosition0 = args.TrackedFinger.deltaPosition;;
        Vector2 averagePosition = deltaPosition0 / Screen.dpi;

        Vector3 change = averagePosition * (this._speed * Time.deltaTime);
        Vector3 adjustedChange = new Vector3(change.x, 0, change.y);
        this.transform.position += adjustedChange;
    }

    /* UNITY LIFE CYCLE METHODS */
    void Start()
    {
        GestureManager.Instance.OnDrag += OnDrag;
    }

    void OnDisable()
    {
        GestureManager.Instance.OnDrag -= OnDrag;
    }
}
