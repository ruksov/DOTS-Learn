using Unity.Burst;
using Unity.Entities;

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
  public float DeltaTime;
  
  public void Execute(MoveToPositionAspect moveToPositionAspect) => 
    moveToPositionAspect.Move(DeltaTime);
}