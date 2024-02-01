using StudentEntities.Model;

namespace StudentContracts
{
    public interface IMark
    {
        public Task<Mark> Add (Mark mark);
        public Task<IEnumerable<Mark>> Get ();
        public Task<Mark> Update (Mark mark);
    }
}