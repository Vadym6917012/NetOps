namespace NetOps.Domain.Enums
{
    public enum RequestStatus
    {
        New = 0,
        Assigned = 1,
        InProgress = 2,
        WaitingForCustomer = 3,
        Completed = 4,
        Cancelled = 5
    }
}