public class BlackSpider : Enemy
{
    private int minHealth = 1;
    private int currentHealth = 2;

    public override void Shoot()
    {
        currentHealth--;
        if (currentHealth < minHealth)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
