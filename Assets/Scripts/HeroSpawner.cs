using Unity.Entities;

public struct HeroSpawner : IComponentData
{
    public Entity HeroPrefab;
    public int HeroCount;
}