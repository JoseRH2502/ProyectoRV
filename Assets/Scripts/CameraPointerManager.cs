
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pointer;
    [SerializeField] float maxDistancePointer = 2.5f;
    [SerializeField] float disPointerObject = 0.95f;

    private const float _maxDistance = 20;
    private GameObject _gazedAtObject = null;

    private readonly string interactableTag = "Interactable";
    private readonly string enemyTag = "Enemy";



    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {

        if (_gazedAtObject.name == "Play")
            _gazedAtObject?.SendMessage("StartGame", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Tutorial")
            _gazedAtObject?.SendMessage("LoadTutorial", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "About")
            _gazedAtObject?.SendMessage("LoadAboutUs", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Exit")
            _gazedAtObject?.SendMessage("ExitApp", null, SendMessageOptions.DontRequireReceiver);

        if (_gazedAtObject.CompareTag(interactableTag))
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);

    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                if (hit.transform.CompareTag(interactableTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(enemyTag))
                {
                    _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
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
     
    }
}
