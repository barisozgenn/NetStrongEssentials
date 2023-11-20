namespace DomainDrivenDesign.Domain.Orders;

public enum OrderStatusEnum
{
    WaitingForApproval = 1,
    Preparing = 2,
    Transferring = 3,
    Delivered = 4,
    Cancelled = 5
}