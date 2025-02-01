using UnityEngine;

public class TapReciever : MonoBehaviour
{
    public void OnTap(object sender, TapEventArgs args)
    {}

    /* UNITY LIFECYCLE METHODS */
    private void Start()
    {
        GestureManager.Instance.OnTap += this.OnTap;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnTap -= this.OnTap;
    }

}
