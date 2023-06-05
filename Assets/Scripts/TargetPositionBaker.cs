using Unity.Entities;

public class TargetPositionBaker : Baker<TargetPositionAuthoring>
{
  public override void Bake(TargetPositionAuthoring authoring)
  {
    Entity entity = GetEntity(TransformUsageFlags.Dynamic);
    AddComponent(entity, new TargetPosition()
    {
      Position = authoring.Position
    });
  }
}