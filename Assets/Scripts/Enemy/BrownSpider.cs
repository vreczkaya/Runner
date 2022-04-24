public class BrownSpider : Enemy
{
    public override void Shoot()
    {
        Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
