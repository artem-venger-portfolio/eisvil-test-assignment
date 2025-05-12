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

        public override string DisplayName => $"{_targetFigure.ToString()} destroyed " +
                                              $"({CurrentCount}/{TargetCount})";

        protected override bool CanIncrementCounter(FigureType figure)
        {
            return _targetFigure == figure;
        }
    }
}