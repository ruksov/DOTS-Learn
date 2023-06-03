using Unity.Entities;

public class SpeedBaker : Baker<SpeedAuthoring>
{
  public override void Bake(SpeedAuthoring authoring)
  {
    Entity entity = GetEntity(TransformUsageFlags.Dynamic);
    AddComponent(entity, new Speed
    {
      Value = authoring.Value
    });
  }
}