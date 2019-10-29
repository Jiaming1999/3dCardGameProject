using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_and_Attack : MonoBehaviour
{
    public Transform default_aim; // the enemy base;
    public float move_speed = 20f;
    //public LayerMask player_mask;
    public float attack_range = 50f;
    public float search_range = 100f;
    public GameObject rocket_prefab;
    public float fire_rate = 0.5f;
    private float fire_countdown = 0f;
    public Transform fire_point;

    private string enemy_tag;
    private Transform target;
    private Vector3 direction = Vector3.forward;

    private void Start()
    {
        if (gameObject.tag == "Player1")
        {
            enemy_tag = "Player2";
        } else if (gameObject.tag == "Player2")
        {
            enemy_tag = "Player1";
        }
        InvokeRepeating("update_Target", 0f, 0.5f);
    }

    void update_Target ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        float shortest = Mathf.Infinity;
        GameObject nearest = null;
        foreach (GameObject enemy in enemies)
        {
            float enemy_distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemy_distance < shortest)
            {
                shortest = enemy_distance;
                nearest = enemy;
            }
        }

        if (nearest != null)
        {   if (shortest <= search_range && shortest > attack_range)
            {
                transform.LookAt(nearest.transform);
            }
            else if (shortest <= attack_range)
            {
                target = nearest.transform;
            }
            else
            {
                target = null;
            }
            Debug.Log(target);
        }
        
    }
    // Update is called once per frame
    void Update()
    {   if (target == null)
        {   
            transform.LookAt(default_aim);
            transform.Translate(direction * move_speed * Time.deltaTime);
            return;
        }
        else
        {
            transform.LookAt(target);
            if (fire_countdown <= 0f)
            {
                attack();
                fire_countdown = 1f / fire_rate;
            }
            fire_countdown -= Time.deltaTime;
        }
    }

    void attack ()
    {
        GameObject temp = (GameObject)Instantiate(rocket_prefab, fire_point.position, fire_point.rotation);
        Rocket rocket = temp.GetComponent<Rocket>();
        if (rocket != null)
        {
            rocket.set_Target(target);
        }
    }
}
    