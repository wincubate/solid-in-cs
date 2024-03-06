namespace Admin.Domain.Interfaces
{
    public interface IMessageTemplateRepository
    {
        MessageTemplate GetById(int id);
    }
}
