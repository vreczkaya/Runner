using UnityEngine;

public class BlackSpider : Enemy
{
    public GameObject blackElement;
    public override void Shoot()
    {
        Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
        Instantiate(blackElement, this.transform.position, Quaternion.identity);
    }
}
