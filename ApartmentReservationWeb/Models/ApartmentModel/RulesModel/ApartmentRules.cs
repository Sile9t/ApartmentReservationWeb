namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class ApartmentRules
    {
        public int Id { get; set; }
        public TimeOnly FromTime { get; set; }
        public TimeOnly TillTime { get; set; }
        public virtual RulesList RulesList { get; set; }
        public string CanselCondition { get; set; }
    }
}
