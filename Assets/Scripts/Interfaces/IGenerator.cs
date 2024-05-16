public interface IGenerator
{
    void Generate();

    void RestoreAll();

    void OnDied(int score);
}
