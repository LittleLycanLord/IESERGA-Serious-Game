using UnityEngine;

public class SpreadReceiver : MonoBehaviour
{
    [SerializeField] 
    private float _speedResize = 120.0f;

    [SerializeField]
    private float _maxZoomInY = 7.45f;

    [SerializeField]
    private float _maxZoomOutY = 30.0f;

    [SerializeField]
    private float _maxZoomInRot = 45.0f;

    [SerializeField]
    private float _maxZoomOutRot = 85.0f;

    public void OnSpread(object sender, SpreadEventArgs args)
    {
        float scale = args.DistanceDelta / Screen.dpi;
        scale = scale * this._speedResize * Time.deltaTime;

        scale = -scale;

        float newY = Camera.main.transform.localPosition.y + scale;
        float newRot = Camera.main.transform.localRotation.eulerAngles.x + scale;

        if (newY >= this._maxZoomOutY)
            newY = this._maxZoomOutY;
        if (newY <= this._maxZoomInY)
            newY = this._maxZoomInY;
        if (newRot >= this._maxZoomOutRot)
            newRot = this._maxZoomOutRot;
        if (newRot <= this._maxZoomInRot)
            newRot = this._maxZoomInRot;

        Vector3 change = new Vector3(Camera.main.transform.localPosition.x, newY, Camera.main.transform.localPosition.z);
        Camera.main.transform.localEulerAngles = new Vector3(newRot, Camera.main.transform.localEulerAngles.y, Camera.main.transform.localEulerAngles.z);
        Camera.main.transform.localPosition = change;
    }

    /* UNITY LIFECYCLE METHODS */
    private void Start()
    {
        GestureManager.Instance.OnSpread += this.OnSpread;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnSpread -= this.OnSpread;
    }
}
