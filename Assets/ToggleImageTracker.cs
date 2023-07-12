using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ToggleImageTracker : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject model3D;
    private bool modelActive = true;
    private float lastClickTime = 0f;
    private float doubleClickTimeThreshold = 0.3f;

    private void Start()
    {
        // Obtén la referencia al ARTrackedImageManager de AR Foundation
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnMouseDown()
    {
        // Verifica si ha pasado el tiempo suficiente para considerar un segundo toque
        if (Time.time - lastClickTime < doubleClickTimeThreshold)
        {
            // Es un doble toque, activa el modelo 3D
            modelActive = true;
            model3D.SetActive(true);
            trackedImageManager.enabled = true;
        }
        else
        {
            // Es un primer toque, desactiva el modelo 3D
            modelActive = false;
            model3D.SetActive(false);
            trackedImageManager.enabled = false;
        }

        // Actualiza el tiempo del último toque
        lastClickTime = Time.time;
    }
}