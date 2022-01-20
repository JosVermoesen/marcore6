using System.Collections.Generic;
using System.Threading.Tasks;
using marcore.Entities;
using marcore.api.Helpers;
// 

namespace marcore.api.Data
{
    public interface ICompanyRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update(User user);
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByUsernameAsync(string username);

        Task<bool> SaveAllAsync();

        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhotoForUser(int userId);

        Task<Like> GetLike(int userId, int recipientId);

        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}