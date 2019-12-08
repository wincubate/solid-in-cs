using Admin.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class CreateUserService : ICreateUserService
    {
        private readonly Messenger _messenger;

        public CreateUserService(Messenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        public async Task CreateUserAsync(User user)
        {
            Message message = new Message
            {
                Recipient = user,
                MessageTemplateKind = MessageTemplateConstants.UserIsCreatedOk.ToString(),
                Culture = user.PreferredCulture,
                Parameters = new object[]
                {
                    user.Name
                }
            };
            await _messenger.SendAsync(message);
        }
    }
}
