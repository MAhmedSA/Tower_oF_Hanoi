public interface IFeedbackService
{
    void PlayInvalidMove(Tower from, Tower to);
    void PlaySelectTower(Tower tower);
    void PlayDeselectTower(Tower tower);
}