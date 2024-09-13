using System;

namespace projCoisaMVC
{
    internal class Coisa
    {
        private int id;
        private string descricao;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public Coisa(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public Coisa(int id) : this(id, "")
        {
        }

        public Coisa() : this(0, "")
        {
        }

        public override string ToString()
        {
            return $"{this.id} - {this.descricao}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Coisa other = (Coisa)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
