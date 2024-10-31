using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos
{
    public class HistoryFileDTO
    {
        public long Id { get; set; }
        public string Result { get; set; }
        public short Status { get; set; }
        public string? Code { get; set; }
        public string Ci { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string DiseaseName { get; set; }
        public string CodePatient { get; set; }

    }
}
