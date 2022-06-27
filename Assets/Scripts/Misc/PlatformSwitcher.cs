using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class turns objects on or off based on platform - are we running in editor or on device?
/// </summary>
public class PlatformSwitcher : MonoBehaviour
{
    public UnityTemplateProjects.SimpleCameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        cameraController.enabled = false;
#else
        gameObject.SetActive(false);
#endif
    }
}
