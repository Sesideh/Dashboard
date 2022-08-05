namespace Common
{
    public enum ActionType
    {
        None,
        Save,
        Delete,
        Update,
        Forward,
        Approve,
        Reject,
        Hold,
    }

    public enum DataType
    {
        None,
        Price,
        Precentage
    }

    public enum Trending
    {
        None,
        Yearly,
        Monthly,
        Ninty_Days,
        Sixty_Days,
        Weekly
    }

    public enum KPIType
    {
        Upward,
        DownWard
    }

    public enum CompanyType
    {
        Company,
        Project
    }
}
