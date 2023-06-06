using Unity.Entities;
using UnityEngine;

public class HeroSpawnerAuthoring : MonoBehaviour
{
    public GameObject HeroPrefab;
    public int HeroCount;

    public class Baker : Baker<HeroSpawnerAuthoring>
    {

        public override void Bake(HeroSpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Renderable);
            AddComponent(entity, new HeroSpawner()
            {
                HeroPrefab = GetEntity(authoring.HeroPrefab, TransformUsageFlags.Renderable),
                HeroCount = authoring.HeroCount
            });
        }
    }
}