using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

public partial struct MovingSystem : ISystem
{
  [BurstCompile]
  public void OnCreate(ref SystemState state)
  {
  }

  [BurstCompile]
  public void OnUpdate(ref SystemState state)
  {
    JobHandle moveJobHandle = new MoveJob()
    {
      DeltaTime = SystemAPI.Time.DeltaTime
    }.ScheduleParallel(state.Dependency);

    moveJobHandle.Complete();
    
    new TestAndUpdateTargetPositionJob()
    {
      Random = SystemAPI.GetSingletonRW<RandomComponent>()
    }.Run();
  }

  [BurstCompile]
  public void OnDestroy(ref SystemState state)
  {
  }
}