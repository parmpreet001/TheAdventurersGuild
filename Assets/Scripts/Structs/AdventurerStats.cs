public struct Stats
{
    public int hp, atk, trt, cmp, intl, wis;
    public static Stats operator+(Stats a, Stats b)
    {
        Stats stats = new Stats();
        stats.hp = a.hp + b.hp;
        stats.atk = a.atk + b.atk;
        stats.trt = a.trt + b.trt;
        stats.cmp = a.cmp + b.cmp;
        stats.intl = a.intl + b.intl;

        return stats;
    }
}

