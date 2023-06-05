using Unity.Entities;

public class RandomBaker : Baker<RandomAuthoring>
{
  public override void Bake(RandomAuthoring authoring)
  {
    Entity entity = GetEntity(TransformUsageFlags.Dynamic);
    AddComponent(entity, new RandomComponent()
    {
      Random = new Unity.Mathematics.Random(1)
    });
  }
}