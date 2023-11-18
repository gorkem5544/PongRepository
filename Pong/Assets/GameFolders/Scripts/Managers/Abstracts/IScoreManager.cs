namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Abstracts
{
    public interface IScoreManager
    {
        void AddScore(int value);
        System.Action<int> OnScoreChanged { get; set; }
    }

}