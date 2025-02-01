using UnityEngine;

public class SwipeReciever : MonoBehaviour
{
    [SerializeField]
    private float _speed = 100.0f;
    public void OnSwipe(object sender, SwipeEventArgs args)
    {
        Vector3 change = args.RawDirection.normalized * (this._speed * Time.deltaTime);
        Vector3 adjustedChange = new Vector3(change.x, 0, change.y);
        this.transform.position += adjustedChange;
    }

    /* UNITY LIFECYCLE METHODS */
    private void Start()
    {
        GestureManager.Instance.OnSwipe += this.OnSwipe;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnSwipe -= this.OnSwipe;
    }
}
