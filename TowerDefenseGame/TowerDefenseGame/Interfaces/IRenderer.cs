namespace TowerDefenseGame.Interfaces
{
    public interface IRenderer
    {
        void Render(object obj);

        void RemoveModel(IGameObject gameObject);

        void Clear();
    }
}