using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Matriz
    {
        public Matriz() { }

        private int _id;//
        private int _ejemplar;//
        private int _salidas; //
        private double _peso; //
        private string _estado; //
        private string _codigo; //
        private string _leyenda; //
        private int _propietario; //
        private int _kgAcumulados;//
        private int _kgAcumulados2;//
        private bool _Controlada;//

        public int Propietario { get { return this._propietario; } set { this._propietario = value; } }
        public int ID { get { return this._id; } set { this._id = value; } }
      
        public int Ejemplar { get { return this._ejemplar; } set { this._ejemplar = value; } }
        
        public int Salidas { get { return this._salidas; } set { this._salidas = value; } }
     
        public double Peso{ get { return this._peso; } set { this._peso = value; } }

        public string Estado { get { return this._estado; } set { this._estado = value; } }

        public string Codigo { get { return this._codigo; } set { this._codigo = value; } }
        
        public string Leyenda { get { return this._leyenda; } set { this._leyenda = value; } }
        public int KgAcumulados { get { return this._kgAcumulados; } set { this._kgAcumulados = value; } }
        public int KgAcumulados2 { get { return this._kgAcumulados2; } set { this._kgAcumulados2 = value; } }
        public bool Controlada { get { return this._Controlada; } set { this._Controlada = value; } }

    }
}