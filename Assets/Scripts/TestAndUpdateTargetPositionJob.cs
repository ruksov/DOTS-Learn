using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
public partial struct TestAndUpdateTargetPositionJob : IJobEntity
{
  [NativeDisableUnsafePtrRestriction]
  public RefRW<RandomComponent> Random;
  
  public void Execute(MoveToPositionAspect moveToPositionAspect)
  {
    if (moveToPositionAspect.TargetIsReached())
      moveToPositionAspect.TargetPosition = GenerateRandomPosition();
  }
  
  private float3 GenerateRandomPosition()
  {
    return new float3(
      Random.ValueRW.Random.NextFloat(-10, 10),
      0,
      Random.ValueRW.Random.NextFloat(-10, 10)
    );
  }
}