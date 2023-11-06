using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class BasketAuthoring : MonoBehaviour
{
    public float speed;
    public float leftAndRightEdge;
    public float changeDirectionChance;
    
    private class BacketTreeBaker : Baker<BasketAuthoring>
    {
        public override void Bake(BasketAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new BasketProperties
            {
                Speed = authoring.speed,
                LeftAndRightEdge = authoring.leftAndRightEdge,
                ChangeDirectionChance = authoring.changeDirectionChance,
                Random = Random.CreateFromIndex((uint)entity.Index)
            };
            
            AddComponent(entity, propertiesComponent);
        }
    }


}

public struct BasketProperties : IComponentData
{
    public float Speed;
    public float LeftAndRightEdge;
    public float ChangeDirectionChance;

    public Random Random;
}
