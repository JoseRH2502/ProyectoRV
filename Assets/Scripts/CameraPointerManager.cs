<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
=======
using UnityEngine;
using System;
>>>>>>> 9f8f91c65d97b7fd1e7b5e4d4301fe4d5d5c85fc

public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< HEAD
    [SerializeField] private GameObject pointer;
    [SerializeField] float maxDistancePointer = 2.5f;
    [Range(0, 1)]
    [SerializeField] float disPointerObject = 0.95f;



    private const float _maxDistance = 20;
    private GameObject _gazedAtObject = null;

    private readonly string interactableTag = "Interactable";
    private float scaleSize = 0.025f;
=======
    private const float _maxDistance = 35;
    private GameObject _gazedAtObject = null;

    [SerializeField] private GameObject pointer;

    private readonly string interactableTag = "Interactable";
    private readonly string grabTag = "Grab";
    private readonly string ungrabTag = "UnGrab";
    private readonly string enemyTag = "Enemy";
>>>>>>> 9f8f91c65d97b7fd1e7b5e4d4301fe4d5d5c85fc


    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
<<<<<<< HEAD
        if (_gazedAtObject.name == "Play")
            _gazedAtObject?.SendMessage("StartGame", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Tutorial")
            _gazedAtObject?.SendMessage("LoadTutorial", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "About")
            _gazedAtObject?.SendMessage("LoadAboutUs", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Exit")
            _gazedAtObject?.SendMessage("ExitApp", null, SendMessageOptions.DontRequireReceiver);

    }

=======
        if (_gazedAtObject.CompareTag(interactableTag))
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);


        // Esta funcionan va a tomar un objeto con el Gaze y lo va a atachar a la mano indicada
        if (_gazedAtObject.CompareTag(grabTag))
            _gazedAtObject?.SendMessage("OnGrabRayInteractionAttach", null, SendMessageOptions.DontRequireReceiver);
        
        // Esta funcionan va a tomar un objeto y lo va a des-atachar sobre la mesa colisionada
        if (_gazedAtObject.CompareTag(ungrabTag))
            _gazedAtObject?.SendMessage("OnGrabRayInteractionDeAttach", null, SendMessageOptions.DontRequireReceiver);

    }


>>>>>>> 9f8f91c65d97b7fd1e7b5e4d4301fe4d5d5c85fc
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
<<<<<<< HEAD

        RaycastHit hit;
=======
        RaycastHit hit;
        
>>>>>>> 9f8f91c65d97b7fd1e7b5e4d4301fe4d5d5c85fc
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
<<<<<<< HEAD
                // New GameObject.
                GazeManager.Instance.StartGazeSelection();
                _gazedAtObject = hit.transform.gameObject;
            }
            if (hit.transform.CompareTag(interactableTag))
            {
                PointerOnGaze(hit.point);
            }
            else
            {
                PointerOutGaze();
            }

        }
        else
        {
            // No GameObject detected in front of the camera.
           // _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

     
    }

    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scalefactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scalefactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitPoint, disPointerObject);
    }

    private void PointerOutGaze()
    {
        pointer.transform.localScale = Vector3.one * 0.1f;
        pointer.transform.parent.transform.localPosition = new Vector3(0, 0, maxDistancePointer);
        pointer.transform.parent.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }

    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);

        return new Vector3(x, y, z);
=======
                _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                if (hit.transform.CompareTag(interactableTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(grabTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(ungrabTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(enemyTag))
                {
                    Shot.Instance.StartFiring();
                }
            }
        }
        else
        {
            GazeManager.Instance.CancelGazeSelection();
            _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }


>>>>>>> 9f8f91c65d97b7fd1e7b5e4d4301fe4d5d5c85fc
    }
}
