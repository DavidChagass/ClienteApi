using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? CPF { get; set; }
    
    public DateTime Nascimento { get; set; }



}
