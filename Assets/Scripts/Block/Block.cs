public delegate void BlockEvent(Block block);

public interface Block
{
    int AddedScore { get; }
    event BlockEvent OnBlockDestroyed;
}
