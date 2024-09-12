namespace FitSalon.WebUI.CQRS.Results.EmployeeResults
{
    public class GetEmployeeByIDQueryResult
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
