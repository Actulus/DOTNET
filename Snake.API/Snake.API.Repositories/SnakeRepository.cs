using Snake.API.Domain;

namespace Snake.API.Repositories
{
    public class SnakeRepository : ISnakeRepository
    {
        public void Add(float points, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Snake> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
