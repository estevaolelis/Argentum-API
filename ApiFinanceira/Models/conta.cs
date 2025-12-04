using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("conta")]
public class conta : BaseModel
{
    [PrimaryKey("id")]
    public int id { get; set; }
    [Column("nome")]
    public int usuario_id { get; set; }
    [Column("tipo_conta")]
    public string tipo_conta { get; set; }
    [Column("saldo")]
    public decimal saldo { get; set; }
    [Column("data_criacao")]
    public DateTime data_criacao { get; set; }
}
