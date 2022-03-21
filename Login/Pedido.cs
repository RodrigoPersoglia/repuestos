using System;

namespace Login
{
    public class Pedido
    {
        private int _id;
        private int _numero;
        private DateTime _fecha;
        private double _KgEstimados;
        private string _ordenCompra;
        private string _observaciones;
        private string _cliente;
        private string _articulo;
        private string _unidad;
        private string _terminacion;
        private string _estado;
        private string _prioridad;
        private string _aleacion;
        private string _temple;
        private string _largo;
        private double __cantidad;
        private int detalle;
        private string _codArticulo;
        private int _matriz;





        public int ID { get { return this._id; } set { this._id = value; } }
        public int Numero { get { return this._numero; } set { this._numero = value; } }
        public DateTime Fecha { get { return this._fecha; } set { this._fecha = value; } }
        public double KgEstimados { get { return this._KgEstimados; } set { this._KgEstimados = value; } }
        public string OrdenCompra { get { return this._ordenCompra; } set { this._ordenCompra = value; } }
        public string Observaciones { get { return this._observaciones; } set { this._observaciones = value; } }
        public string Cliente { get { return this._cliente; } set { this._cliente = value; } }
        public string Articulo { get { return this._articulo; } set { this._articulo = value; } }
        public string Unidad { get { return this._unidad; } set { this._unidad = value; } }
        public string  Terminacion{ get { return this._terminacion; } set { this._terminacion = value; } }
        public string Estado { get { return this._estado; } set { this._estado = value; } }
        public string Prioridad { get { return this._prioridad; } set { this._prioridad = value; } }
        public string Aleacion { get { return this._aleacion; } set { this._aleacion = value; } }
        public string Temple { get { return this._temple; } set { this._temple = value; } }
        public string Largo { get { return this._largo; } set { this._largo = value; } }
        public double Cantidad { get { return this.__cantidad; } set { this.__cantidad = value; } }
        public int Detalle { get { return this.detalle; } set { this.detalle = value; } }

        public string Codigo_Articulo { get { return this._codArticulo; } set { this._codArticulo = value; } }

        public int Matriz { get { return this._matriz; } set { this._matriz = value; } }
        public Pedido() { }




    }
}