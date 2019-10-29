using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform target;

    public float speed = 20f;
    public float damage = 20f;
    public float radius = 0f;
    public void set_Target(Transform t)
    {
        target = t;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distance_frame = speed * Time.deltaTime;
        if (dir.magnitude <= distance_frame)
        {
            hit_Target();
            return;
        }
        transform.Translate(dir.normalized * distance_frame, Space.World);
        transform.LookAt(target);
    }
    void hit_Target()
    {
        target.gameObject.SendMessage("TakeDamage", damage);
        Destroy(gameObject);
    }
}
