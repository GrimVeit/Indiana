using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private RawImage rawImage;
    public Vector2 movementScale = Vector2.one;

    private Vector2 uvOffset;
    private Vector3 lastCameraPosition;


    private void Start()
    {
        Coroutines.Start(TestCoro());
        lastCameraPosition = _camera.transform.position;
    }

    private IEnumerator TestCoro()
    {
        while (true)
        {
            Vector3 delta = (_camera.transform.position - lastCameraPosition);
            uvOffset += new Vector2(delta.x * movementScale.x, delta.y * movementScale.y);
            rawImage.uvRect = new Rect(uvOffset, rawImage.uvRect.size);
            lastCameraPosition = _camera.transform.position;
            yield return null;
        }
    }
}
