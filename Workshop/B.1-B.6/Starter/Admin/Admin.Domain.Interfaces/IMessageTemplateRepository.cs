namespace Admin.Domain.Interfaces
{
    public interface IMessageTemplateRepository
    {
        MessageTemplate GetById(int id);
        MessageTemplate GetByTemplateKindCulture(
            string kind,
            string culture
        );
    }
}
