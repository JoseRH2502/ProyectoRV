using UnityEngine;
using System;

public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private const float _maxDistance = 35;
    private GameObject _gazedAtObject = null;

    [SerializeField] private GameObject pointer;

    private readonly string interactableTag = "Interactable";
    private readonly string grabTag = "Grab";
    private readonly string ungrabTag = "UnGrab";
    private readonly string enemyTag = "Enemy";


    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
        if (_gazedAtObject.CompareTag(interactableTag))
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);


        // Esta funcionan va a tomar un objeto con el Gaze y lo va a atachar a la mano indicada
        if (_gazedAtObject.CompareTag(grabTag))
            _gazedAtObject?.SendMessage("OnGrabRayInteractionAttach", null, SendMessageOptions.DontRequireReceiver);
        
        // Esta funcionan va a tomar un objeto y lo va a des-atachar sobre la mesa colisionada
        if (_gazedAtObject.CompareTag(ungrabTag))
            _gazedAtObject?.SendMessage("OnGrabRayInteractionDeAttach", null, SendMessageOptions.DontRequireReceiver);

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


    }
}
