using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///<summary>Controller for the slingshot</summary>
public class Slingshot : MonoBehaviour
{
    ///<summary>The main camera</summary>.
    public Camera cam;
    ///<summary>The base force of the slingshot.</summary>
    public float slingForce;
    ///<summary>Distance from the camera.</summary>
    public float zDistance;
    ///<summary>Available ammo (or attempts).</summary>
    public int ammo;
    public LineDrawer line;
    public TextMeshProUGUI ammoCounter;
//    public GameObject targetPlane;
    public GUIManager guiManager;

    // The starting position of the ball, which is at the center of the device's screen.
    private Vector3 _startingViewportPosition;
    // 
    private Vector3 _newPosition;
    private Vector3 _diffPosition;
    private bool _isTouching;
    private int _defaultAmmo;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _startingViewportPosition = new Vector3(0.5f, 0.5f, zDistance);
        this.transform.position = cam.ViewportToWorldPoint(_startingViewportPosition);

        _rigidbody = GetComponent<Rigidbody>();

        ammoCounter.text = $"{ammo}";
        _defaultAmmo = ammo;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(cam.ScreenPointToRay(touch.position), out hit))
                    {
                        if (hit.transform.gameObject.CompareTag("Slingshot"))
                        {
                            _isTouching = true;
                            line.Toggle();
                        }
                    }
                    break;
                case TouchPhase.Moved:
                    if (_isTouching)
                    {
                        _newPosition = new Vector3(touch.position.x, touch.position.y, transform.position.z);
                        _newPosition = cam.ScreenToWorldPoint(_newPosition);
                        transform.position = new Vector3(_newPosition.x, _newPosition.y, zDistance - Mathf.Abs(_newPosition.y));
                        _diffPosition = cam.ViewportToWorldPoint(_startingViewportPosition) - transform.position;
                        line.DrawLine(transform.position, _diffPosition, slingForce);
                    }
                    break;
                case TouchPhase.Ended:
                    if (_isTouching)
                    {
                        line.Toggle();
                        _isTouching = false;
                        _rigidbody.isKinematic = false;
                        _rigidbody.AddForce(_diffPosition * slingForce, ForceMode.Impulse);
                        --ammo;
                        ammoCounter.text = $"{ammo}";
                    }
                    break;

                case TouchPhase.Canceled:
                    if (_isTouching)
                    {
                        line.Toggle();
                        _isTouching = false;
                        transform.position = cam.ViewportToWorldPoint(_startingViewportPosition);
                    }
                    break;
            }
        }
        else
        {
            transform.position = cam.ViewportToWorldPoint(_startingViewportPosition);
        }
        if (transform.position.y < -100)
        {
            ResetPosition();
        }
    }

    public void ResetAmmo()
    {
        ammo = _defaultAmmo;
        ammoCounter.text = $"{ammo}";
    }

    public void ResetPosition()
    {
        _rigidbody.isKinematic = true;
        transform.position = cam.ViewportToWorldPoint(_startingViewportPosition);

        if (ammo <= 0)
            guiManager.GameOver();
    }

    void OnCollisionEnter(Collision entity)
    {
        if (entity.gameObject.CompareTag("Target"))
        {
            Destroy(entity.gameObject);
            guiManager.AddScore();
        }
        ResetPosition();
    }
}
