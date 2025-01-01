namespace DomainDrivenDesign.Domain.Orders
{
    /// <summary>
    /// Represents the various statuses an order can have during its lifecycle.
    /// </summary>
    public enum OrderStatusEnum
    {
        /// <summary>
        /// The order is waiting for approval.
        /// </summary>
        WaitingForApproval = 1,

        /// <summary>
        /// The order is being prepared.
        /// </summary>
        Preparing = 2,

        /// <summary>
        /// The order is in the process of being transferred.
        /// </summary>
        Transferring = 3,

        /// <summary>
        /// The order has been delivered to the customer.
        /// </summary>
        Delivered = 4,

        /// <summary>
        /// The order has been cancelled.
        /// </summary>
        Cancelled = 5
    }
}