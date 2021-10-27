using System.Collections.Generic;
public class TagsHolder 
{
    public Dictionary<int, string> tags = new Dictionary<int, string>();

    public TagsHolder()
    {
        tags.Add(1, "DOWN");
        tags.Add(2, "UP");
        tags.Add(3, "EnemyBullet");
        tags.Add(4, "EnemyUnlockTrigget");
        tags.Add(5, "BottomBorder");
        tags.Add(6, "TopBorder");
        tags.Add(7, "PlayerBullet");
        tags.Add(8, "Enemy");
    }
}
