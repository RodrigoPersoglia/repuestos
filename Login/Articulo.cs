using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Articulo
    {
        private int _id;
        private string _codigo;
        private string _codigoProveedor;
        private string _numeroPieza;
        private string _descripcion;
        private double _precio;
        private int _stockMin;
        private int _stockMax;
        private int _stockActual;
        private string _observaciones;
        private string _ubicacion;
        // ID de otras tablas
        private int _Marca;
        private int _Rubro;
        private int _Lado;
        private int _Proveedor;
        private string _nombreProveedor;




        public int ID { get { return this._id; } set { this._id = value; } }
        public string Codigo { get { return this._codigo; } set { this._codigo = value; } }
        public string CodigoProveedor { get { return this._codigoProveedor; } set { this._codigoProveedor = value; } }
        public string NumeroPieza { get { return this._numeroPieza; } set { this._numeroPieza = value; } }
        public string Descripcion { get { return this._descripcion; } set { this._descripcion = value; } }
        public double Precio { get { return this._precio; } set { this._precio = value; } }
        public int StockMin { get { return this._stockMin; } set { this._stockMin = value; } }
        public int StockMax { get { return this._stockMax; } set { this._stockMax = value; } }
        public int StockActual { get { return this._stockActual; } set { this._stockActual = value; } }
        public string Observaciones { get { return this._observaciones; } set { this._observaciones = value; } }
        public string Ubicacion { get { return this._ubicacion; } set { this._ubicacion = value; } }

     
        public int Marca { get { return this._Marca; } set { this._Marca = value; } }
        public int Rubro { get { return this._Rubro; } set { this._Rubro = value; } }
        public int Lado { get { return this._Lado; } set { this._Lado = value; } }
        public int Proveedor { get { return this._Proveedor; } set { this._Proveedor = value; } }
        public string NombreProveedor { get { return this._nombreProveedor; } set { this._nombreProveedor = value; } }


        public Articulo() { }


    }
}