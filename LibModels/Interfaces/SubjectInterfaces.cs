namespace LibModels.Interfaces
{
    interface ISubjectItem
    {
        int Id { get; }
        string Username { get; }
        string Email { get; }
        string Phone { get; }
    }

    interface ISubjectItemListFilterParams
    {
        string StatusCode { get; }
    }
}
