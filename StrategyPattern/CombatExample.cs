
//var ch = new Character(new AgressiveCombatStrategy());
//ch.ApplyAttackStrategy();

//ch.SetCombatStrategy(new DefensiveCombatStrategy());
//ch.ApplyAttackStrategy();

//Console.ReadLine();


class Character
{
    private ICombatStrategy combatStrategy;

    public Character(ICombatStrategy combatStrategy)
    {
        this.combatStrategy = combatStrategy;
    }

    public Character()
    {

    }

    public void SetCombatStrategy(ICombatStrategy combatStrategy)
    {
        this.combatStrategy = combatStrategy;
    }

    public void ApplyAttackStrategy()
    {
        combatStrategy.Attack();
    }
}

interface ICombatStrategy
{
    void Attack();
}

class AgressiveCombatStrategy : ICombatStrategy
{
    public void Attack()
    {
        Console.WriteLine("Agressive attack");
    }
}

class DefensiveCombatStrategy : ICombatStrategy
{
    public void Attack()
    {
        Console.WriteLine("Defensive attack");
    }
}