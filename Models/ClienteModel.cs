using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteTecnico.Models


{
   
    public enum TipoPessoa
    {
        [Display(Name = "Fisica")]
        Fisica,

        [Display(Name = "Juridica")]
        Juridica
    }

    public enum Genero
    {
        [Display(Name = "Masculino")]
        Masculino,

        [Display(Name = "Feminino")]
        Feminino,

        [Display(Name = "Outro")]
        Outro
    }

    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage= "Campo Obrigatório")]
        [StringLength(150, ErrorMessage = "O campo Nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage= "Campo Obrigatório")]
        [StringLength(150, ErrorMessage = "O campo Email deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage= "Campo Obrigatório")]
        [StringLength(15, ErrorMessage = "O campo Telefone deve ter no máximo 11 caracteres numéricos.")]
        public string Telefone { get; set; }

        public DateTime DataDeCadastro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Column(TypeName = "nvarchar(20)")]
        [EnumDataType(typeof(TipoPessoa))]
        public TipoPessoa TipoDePessoa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(20, ErrorMessage = "O campo CPF/CNPJ deve ter no máximo 14 caracteres.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(15, ErrorMessage = "O campo Inscrição Estadual deve ter no máximo 12 caracteres.")]
        public string InscricaoEstadual { get; set; }

        [DefaultValue(false)]
        public bool Isento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Column(TypeName = "nvarchar(15)")]
        [EnumDataType(typeof(Genero))]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataDeNascimento { get; set; }

        [DefaultValue(false)]
        public bool Bloqueado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(8, ErrorMessage = "O campo Senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(15, ErrorMessage = "O campo Senha deve ter no máximo 15 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(8, ErrorMessage = "O campo Confirmação de Senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(15, ErrorMessage = "O campo Confirmação de Senha deve ter no máximo 15 caracteres.")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmacaoDeSenha { get; set; }
    }
} 
