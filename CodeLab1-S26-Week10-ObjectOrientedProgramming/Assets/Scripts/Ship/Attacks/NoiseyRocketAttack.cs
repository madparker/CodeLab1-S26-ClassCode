using UnityEngine;

public class NoiseyRocketAttack : BaseAttack
{
    public override void Attack()
    {
        Vector2 pos = transform.position;
        
        SpawnBullet(pos);
    }

    public override void SpawnBullet(Vector2 pos)
    {
        Vector3 left  = pos;
        Vector3 right = pos;

        left.x -= 0.1f;
        left.y += 1;
        
        right.x += 0.1f;
        right.y += 1;
        
        GameObject rocket1 = Instantiate(bulletPrefab, left, Quaternion.identity);
        GameObject rocket2 = Instantiate(bulletPrefab, right, Quaternion.identity);
        
        rocket1.GetComponent<NoiseMove>().InitVel(new Vector2(-1, 3));
        rocket2.GetComponent<NoiseMove>().InitVel(new Vector2(1, 3));
    }
}
