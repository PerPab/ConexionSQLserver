using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSQL
{
    internal class Pedido
    {
        public int idPedido { get; set; }
        public string ciudadDestino { get; set; }
        public double importeTotal { get; set; }

    }

    internal class GestorPedidos
    {
        public List<Pedido> listaDePedidos { get; set; }

        public void AgregarPedido( int idPedido, string ciudadDestino, double importeTotal)
        {
            if(this.listaDePedidos == null)
            {
                this.listaDePedidos = new List<Pedido>();

            }
            listaDePedidos.Add(new Pedido {  idPedido = idPedido, ciudadDestino = ciudadDestino, importeTotal = importeTotal });
        }

        public void Total()
        {
            Console.WriteLine($"La suma es: {this.listaDePedidos.Sum(x => x.importeTotal)}");
        }
    }
}
