using Monoscene;

namespace Monoscene_Test;

public class TestScene : Scene
{
    public TestScene() : base("TestScene")
    {
    }

    public override void Instantiate()
    {
        TestPlayer testPlayer = new TestPlayer();
        testPlayer.AddToScene(this);
    }
}
