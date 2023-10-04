namespace Patterns.Mediator
{
    public interface Vehicle
    {
        public void BrakePressed();
        public void BrakeRelease();
        public void LeftPressed();
        public void RightPressed();
        public void ObstacleDetected();
    }
}