﻿namespace src.api.Domain.Entities
{
    public class Endereco
    {
        public int ClienteId { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Cliente Cliente { get; set; }
    }
}