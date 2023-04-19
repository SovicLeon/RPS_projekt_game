using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;

    public void Move(float deltaX, float deltaY)
    {
        Vector3 newPos = transform.localPosition;
        if (deltaX != 0) {
            newPos.x -= deltaX * parallaxFactor;
        }
        if (deltaY != 0) {
            newPos.y -= deltaY * parallaxFactor;
        }
        transform.localPosition = newPos;
    }
}
