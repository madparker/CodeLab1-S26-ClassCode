using System;
using System.Security.Principal;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarburstShield : BaseShield
{
    public GameObject bullet;
    bool spin = false;

    public override float AdjustDamage(float damage)
    {
        Vector3 pos = transform.position;

        BaseAttack attack = GetComponent<BaseAttack>();

        attack.Attack();

        if (Random.Range(0f, 1f) > 0.5f)
        {
            pos.x += Random.Range(3f, 5f);
        }
        else
        {
            pos.x -= Random.Range(3f, 5f);
        }

        // BaseAttack attack - G
        
        transform.position = pos;
        
        spin = true;
        Invoke(nameof(Reset), 3f);
        
        return base.AdjustDamage(damage);
    }

    void Update()
    {
        if (spin )
        {
            Spin();
        }
    }

    void Spin()
    {
        transform.Rotate(0, 0, Time.deltaTime * 360);
        
        Camera.main.backgroundColor = 
            new Color(Mathf.PerlinNoise1D(transform.rotation.z),
                Mathf.PerlinNoise1D(transform.rotation.z),
                Mathf.PerlinNoise1D(transform.rotation.z));
    }

    void Reset()
    {
        spin = false;
        transform.rotation = Quaternion.identity;
        Camera.main.backgroundColor = Color.black;
    }
}
