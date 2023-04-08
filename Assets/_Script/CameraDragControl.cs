using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystems
{
    public class CameraDragControl : MonoBehaviour
    {

        Camera controlCamera;

        Vector2 mousePos;

        void Awake()
        {
            controlCamera = GetComponent<Camera>();
        }
        void Update()
        {
            if (Time.timeScale == 0) return;

            float scroll = -Input.mouseScrollDelta.y;
            controlCamera.orthographicSize += (controlCamera.orthographicSize * scroll / 2) * 0.5f;

            if(Input.GetMouseButtonDown(2))
            {
                mousePos = controlCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(2))
            {
                Vector2 current = controlCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 offset = mousePos - current;
// transform.mousePos.
                controlCamera.transform.Translate(offset);
                mousePos = controlCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}
