public struct EntityStats
{
    public float hp;
    public int atk, trt, cmp, intl, wis;

    public EntityStats(int hp, int atk, int trt, int cmp, int intl, int wis)
    {
        this.hp = hp;
        this.atk = atk;
        this.trt = trt;
        this.cmp = cmp;
        this.intl = intl;
        this.wis = wis;
    }

    //Copy constructor
    public EntityStats(EntityStats stats)
    {
        hp = stats.hp;
        atk = stats.atk;
        trt = stats.trt;
        cmp = stats.cmp;
        intl = stats.intl;
        wis = stats.wis;
    }
    public static EntityStats operator+(EntityStats a, EntityStats b)
    {
        EntityStats stats = new EntityStats();
        stats.hp = a.hp + b.hp;
        stats.atk = a.atk + b.atk;
        stats.trt = a.trt + b.trt;
        stats.cmp = a.cmp + b.cmp;
        stats.intl = a.intl + b.intl;

        return stats;
    }
}

