namespace ListaDeTarefas.Models
{
    public class Filtros
    {
        public string CategoriaId { get; set; }
        public string Vencimento { get; set; }
        public string StatusId { get; set; }

        public bool TemCategoria => !string.IsNullOrEmpty(CategoriaId) && CategoriaId != "todos";
        public bool Temstatus => !string.IsNullOrEmpty(StatusId) && StatusId != "todos";
        public bool TemVencimentos => !string.IsNullOrEmpty(Vencimento) && Vencimento != "todos";
        public bool EPassado => Vencimento == "passado";
        public bool EFuturo => Vencimento == "futuro";
        public bool EHoje => Vencimento == "hoje";

        public Filtros(string categoriaId, string vencimento, string statusId)
        {
            CategoriaId = categoriaId;
            Vencimento = vencimento;
            StatusId = statusId;
        }

        public static Dictionary<string, string> VencimentoValoresFiltro => new Dictionary<string, string>
        {
            {"todos", "Todos"},
            {"passado", "Passado"},
            {"futuro", "Futuro"},
            {"hoje", "Hoje"}
        };
    }
}
