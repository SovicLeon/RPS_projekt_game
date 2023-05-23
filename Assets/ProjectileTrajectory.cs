using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] float destroyTimer = 7f;

    private void Start()
    {
        Destroy(gameObject, destroyTimer);
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
        if (dir_y < 0)
        {
            Vector3 scale = transform.localScale;
            scale.y = scale.y * -1;
            transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
