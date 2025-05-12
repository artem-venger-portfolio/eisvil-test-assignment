namespace Game
{
    public class DestroyTask : DestroyTaskBase
    {
        private readonly FigureType _targetFigure;

        public DestroyTask(CollisionRoom collisionRoom, FigureType targetFigure, int targetCount) :
                base(collisionRoom, targetCount)
        {
            _targetFigure = targetFigure;
        }

        public override string DisplayName => $"Destroy {_targetFigure.ToString()}";

        protected override bool CanIncrementCounter(FigureType figure)
        {
            return _targetFigure == figure;
        }
    }
}