﻿namespace produtos02.Data.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Id = Guid.NewGuid();
        }

        public Categoria(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
