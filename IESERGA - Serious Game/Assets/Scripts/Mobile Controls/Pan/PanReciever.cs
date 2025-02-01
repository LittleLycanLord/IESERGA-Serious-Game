using UnityEngine;

public class PanReciever : MonoBehaviour
{   
    [SerializeField]
    private float _speed = 50.0f;

    private void OnPan(object sender, PanEventArgs args)
    {
        Vector2 deltaPosition0 = args.TrackedFingers[0].deltaPosition;
        Vector2 deltaPosition1 = args.TrackedFingers[1].deltaPosition;

        Vector2 averagePosition = (deltaPosition0 + deltaPosition1) / 2;
        averagePosition = averagePosition / Screen.dpi;

        Vector3 change = averagePosition * (this._speed * Time.deltaTime);
        Vector3 adjustedChange = new Vector3(change.x, 0, change.y);
        this.transform.position += adjustedChange;
    }

    /* UNITY LIFECYCLE METHODS */
    private void Start()
    {
        GestureManager.Instance.OnPan += this.OnPan;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnPan -= this.OnPan;
    }
}
