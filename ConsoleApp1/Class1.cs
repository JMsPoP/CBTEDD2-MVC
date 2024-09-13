using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projCoisaMVC
{
    internal class Coisas
    {
        #region Atributos
        private Coisa[] asCoisas;
        private int max;
        private int qtde;
        #endregion

        #region Propriedades
        public int Max { get => max; }
        public int Qtde { get => qtde; }
        internal Coisa[] AsCoisas { get => asCoisas; }
        #endregion

        #region Construtores
        public Coisas(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.asCoisas = new Coisa[max];
            for (int i = 0; i < this.max; i++)
            {
                this.asCoisas[i] = new Coisa(-1, "");
            }
        }
        #endregion

        #region Métodos
        public string mostrar()
        {
            string ret = "";
            foreach (Coisa co in this.asCoisas)
            {
                if (co.Id != -1)
                {
                    ret += co.ToString();
                }
            }
            /*
            for(int i=0; i<this.qtde; ++i)
            {
                ret += this.AsCoisas[i].ToString();
            }
            */
            return ret;
        }
        public bool adicionar(Coisa c)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
            {
                this.asCoisas[this.qtde] = c;
                this.qtde++;
            }
            return podeAdicionar;
        }

        public Coisa pesquisar(Coisa c)
        {
            Coisa coisaAchada = new Coisa(-1, "");
            /*
            int i = 0;
            while (i < this.max && this.asCoisas[i].Id != c.Id)
            {
                i++;
            }
            if (i<this.max)
            {
                coisaAchada = this.asCoisas[i];
            }
            */
            foreach (Coisa co in this.asCoisas)
            {
                if (co.Equals(c))
                {
                    coisaAchada = co;
                    break;
                }
            }
            return coisaAchada;
        }




        public bool remover(Coisa c)
        {
            // Primeiro, encontramos o índice do item a ser removido
            int index = -1;
            for (int i = 0; i < this.max; i++)
            {
                if (this.asCoisas[i].Equals(c))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return false; // Item não encontrado
            }

            // Substitui o item removido por um marcador
            this.asCoisas[index] = new Coisa(-1, "");
            this.qtde--;

            // Ajusta os IDs dos itens subsequentes e move os itens
            for (int i = index + 1; i < this.max; i++)
            {
                if (this.asCoisas[i].Id != -1) // Só ajusta IDs se o item não for um marcador
                {
                    this.asCoisas[i - 1] = this.asCoisas[i];
                    this.asCoisas[i - 1].Id--; // Decrementa o ID
                }
                else
                {
                    // Marca o último item como removido se for um marcador
                    this.asCoisas[i - 1] = new Coisa(-1, "");
                }
            }
            // Remove o último item redundante
            this.asCoisas[this.max - 1] = new Coisa(-1, "");

            return true;
        }
        #endregion




    }
}