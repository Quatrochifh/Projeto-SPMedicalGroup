using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int Idclinica { get; set; }

        [StringLength(maximumLength: 14, MinimumLength = 14, ErrorMessage = "O CNPJ precisa ter 14 números!")]
        [Required(ErrorMessage = "Cnpj obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]
        public string Endereço { get; set; }

        [Required(ErrorMessage = "Nome da Clinica obrigatório!")]
        public string NomeClinica { get; set; }

        [Required(ErrorMessage = "Horário de funcionamento obrigatório")]
        public TimeSpan Abertura { get; set; }

        [Required(ErrorMessage = "Horário de funcionamento obrigatório")]
        public TimeSpan Fechamento { get; set; }

        [Required(ErrorMessage = "Campo 'RazaoSocial' obrigatório!")]
        public string RazaoSocial { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
