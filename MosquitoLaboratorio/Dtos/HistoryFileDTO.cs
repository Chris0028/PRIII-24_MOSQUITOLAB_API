namespace MosquitoLaboratorio.Dtos
{
    public class HistoryFileDTO
    {
        public string Result { get; set; }
        public short Status { get; set; }
        public string? Code { get; set; }
        public string Ci { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
