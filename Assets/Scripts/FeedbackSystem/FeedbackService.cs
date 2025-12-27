public class FeedbackService : IFeedbackService
{
    public void PlayInvalidMove(Tower from, Tower to)
    {
        from.Feedback?.FlashInvalid();
        to.Feedback?.FlashInvalid();
    }

    public void PlaySelectTower(Tower tower)
    {
        tower.Feedback?.Select();
    }

    public void PlayDeselectTower(Tower tower)
    {
        tower.Feedback?.Deselect();
    }
}
