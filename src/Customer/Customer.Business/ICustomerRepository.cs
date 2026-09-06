namespace Customer.Business
{
    public interface ICustomerRepository
    {
        bool ExistsByEmail(string email);
    }
}
