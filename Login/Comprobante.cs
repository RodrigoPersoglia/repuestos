using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Comprobante
    {
        int _id, _numero;
        DateTime _fechaHora;
        decimal _subTotal, _financiacion, _total;
        int _clienteID,_medioPago;
        string _cliente, _direcion, _localidad, _cp, _usuario;
        bool _activa;

        public int ID { get { return this._id; } set { this._id = value; } }
        public int Numero { get { return this._numero; } set { this._numero = value; } }
        public DateTime FechaHora { get { return this._fechaHora; } set { this._fechaHora = value; } }
        public decimal SubTotal { get { return this._subTotal; } set { this._subTotal = value; } }
        public decimal Financiación { get { return this._financiacion; } set { this._financiacion = value; } }
        public decimal Total { get { return this._total; } set { this._total = value; } }
        public int ClienteID { get { return this._clienteID; } set { this._clienteID = value; } }
        public int MedioPagoID { get { return this._medioPago; } set { this._medioPago = value; } }
        public string Cliente { get { return this._cliente; } set { this._cliente = value; } }
        public string Direccion { get { return this._direcion; } set { this._direcion = value; } }
        public string Localidad { get { return this._localidad; } set { this._localidad = value; } }
        public string CP { get { return this._cp; } set { this._cp = value; } }
        public string Usuario { get { return this._usuario; } set { this._usuario = value; } }
        public bool Activa { get { return this._activa; } set { this._activa = value; } }

    }

}
