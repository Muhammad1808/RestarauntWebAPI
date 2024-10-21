namespace RestarauntWebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public int EmployeeId {  get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderDetails> Details { get; set; }
    }
}
