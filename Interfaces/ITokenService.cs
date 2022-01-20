using System.Threading.Tasks;
using marcore.Entities;

namespace marcore.Interfaces
{
    public interface ITokenService
    {
         Task<string> CreateToken(User user);
    }
}

/* using System.Threading.Tasks;
using marcore.Entities;

namespace marcore.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
} */