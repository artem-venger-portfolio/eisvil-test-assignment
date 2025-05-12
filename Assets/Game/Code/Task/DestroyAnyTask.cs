namespace Game
{
    public class DestroyAnyTask : DestroyTaskBase
    {
        public DestroyAnyTask(CollisionRoom collisionRoom, int targetCount) : base(collisionRoom, targetCount)
        {
        }

        public override string DisplayName => "Destroy any";

        protected override bool CanIncrementCounter(FigureType figure)
        {
            return true;
        }
    }
}