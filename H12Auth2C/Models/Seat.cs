namespace H12Auth2C.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int PlaneTypeId { get; set; }
        public int SeatName { get; set; }
        public bool IsReserve { get; set; }
        public PlaneType? PlaneType { get; set; }
    }
}
