using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private RawImage rawImage;
    public Vector2 movementScale = Vector2.one;

    [SerializeField] private bool isRight = true;

    private Vector2 uvOffset;
    private Vector3 lastCameraPosition;

    private IEnumerator test;


    private void Start()
    {
        test = TestCoro();
        Coroutines.Start(test);
        lastCameraPosition = _camera.transform.position;
    }

    private void OnDestroy()
    {
        if (test != null)
           Coroutines.Stop(test);
    }

    private IEnumerator TestCoro()
    {
        while (true)
        {
            Vector3 delta = (_camera.transform.position - lastCameraPosition);

            if (isRight)
            {
                uvOffset += new Vector2(delta.x * movementScale.x, delta.y * movementScale.y);
            }
            else
            {
                uvOffset -= new Vector2(delta.x * movementScale.x, delta.y * movementScale.y);
            }
            rawImage.uvRect = new Rect(uvOffset, rawImage.uvRect.size);
            lastCameraPosition = _camera.transform.position;
            yield return null;
        }
    }
}
