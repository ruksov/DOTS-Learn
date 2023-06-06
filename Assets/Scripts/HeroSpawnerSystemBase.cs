using Unity.Collections;
using Unity.Entities;

public partial class HeroSpawnerSystemBase : SystemBase
{
  protected override void OnUpdate()
  {
    EntityQuery heroQuery = EntityManager.CreateEntityQuery(typeof(HeroTag));

    var spawner = SystemAPI.GetSingleton<HeroSpawner>();
    RefRW<RandomComponent> random = SystemAPI.GetSingletonRW<RandomComponent>();
    
    int heroCount = heroQuery.CalculateEntityCount();
    if(heroCount >= spawner.HeroCount)
      return;
    
    EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

    for(int i = 0; i < spawner.HeroCount - heroCount && i < 500; i++)
    {
      Entity hero = entityCommandBuffer.Instantiate(spawner.HeroPrefab);
    
      entityCommandBuffer.SetComponent(hero, new Speed()
      {
        Value = random.ValueRW.Random.NextFloat(1, 15)
      });
    }
  }
}