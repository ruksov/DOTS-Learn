using Unity.Entities;
using Unity.Mathematics;

public partial class MovingSystemBase : SystemBase
{
  protected override void OnUpdate()
  {
    return;
    
    foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
    {
      moveToPositionAspect.Move(SystemAPI.Time.DeltaTime);

      if (moveToPositionAspect.TargetIsReached())
        moveToPositionAspect.TargetPosition = GenerateRandomPosition();
    }
  }

  private float3 GenerateRandomPosition()
  {
    RefRW<RandomComponent> random = SystemAPI.GetSingletonRW<RandomComponent>();
    return new float3(
      random.ValueRW.Random.NextFloat(-10, 10),
      0,
      random.ValueRW.Random.NextFloat(-10, 10)
    );
  }
}