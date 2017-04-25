using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InventarioListaSimple
{
    class Inventario
    {
        private Producto Primero;
        private Producto Ultimo;

        public Inventario()
        {
            Primero = null;
            Ultimo = null;
        }


        /// <summary>
        /// Recibe el producto y lo agrega usando recursividad cuando se tiene mas de un producto en la lista
        /// </summary>
        /// <param name="nuevo"></param>
        public void agregarProducto(Producto nuevo)
        {
            if (buscarInicio(nuevo.codigo) == false)     //cuando es false quiere decir que no hay aun ese codigo y lo deja agregar a la lista
            {
                if (Primero == null)
                    Primero = nuevo;
                else
                    agregarProducto(Primero, nuevo);
            }

        }


        private void agregarProducto(Producto ultimo, Producto nuevo)
        {
            if (ultimo.Siguiente == null)
                ultimo.Siguiente = nuevo;
            else
                agregarProducto(ultimo.Siguiente, nuevo);

        }

        public bool buscarInicio(int codigo)
        {
            bool mostrar = false;
            Producto Actual = Primero;
            bool encontrado = false;

            while (Actual != null && encontrado != true)
            {
                if (Actual.codigo == codigo)
                {
                    mostrar = true;
                    encontrado = true;
                }
                Actual = Actual.Siguiente;
            }

            return mostrar;
        }

        public Producto buscarProducto(int codigo)
        {
            Producto mostrar = null;
            Producto Actual = Primero;    //aqui indico que el el producto actual empieza con el primer elemento que tengo, me sirve para recorrer la lista
            bool encontrado = false;      //sirve para indicarme cuando el codigo coincida con el que busco

            if (Primero != null)          //con este me dice que la lista si contiene algo dentro
            {
                while (Actual != null && encontrado != true)
                {
                    if (Actual.codigo == codigo)
                    {
                        mostrar = Actual;
                        encontrado = true;
                    }
                    Actual = Actual.Siguiente;
                }

                if (encontrado == false)
                {
                    mostrar = null;
                }
            }
            else
                MessageBox.Show("Error, lista vacia");

            return mostrar;
        }


        public void eliminarProducto(int codigo)
        {
            Producto Actual = Primero;
            Producto temporal = null;

            bool encontrado = false;

            if (Primero != null)
            {
                while (Actual != null && encontrado != true)
                {
                    if (Actual.codigo == codigo)
                    {
                        if (Actual == Primero)
                        {
                            Primero = Primero.Siguiente;
                        }
                        else if (Actual == Ultimo)
                        {
                            temporal.Siguiente = null;
                            Ultimo = temporal;
                        }
                        else
                        {
                            temporal.Siguiente = Actual.Siguiente;
                        }

                        encontrado = true;
                    }
                    temporal = Actual;
                    Actual = Actual.Siguiente;
                }

            }
            else
                MessageBox.Show("Error, lista vacia");

        }


        public void insertar(Producto producto, int codigo)
        {
            Producto Actual = Primero;
            Producto temporal = null;

            bool encontrado = false;

            if (buscarInicio(producto.codigo) == false)     //cuando es false quiere decir que no hay aun ese codigo y lo deja agregar a la lista
            {

                if (Primero != null)
                {
                    while (Actual != null && encontrado != true)
                    {
                        temporal = Actual.Siguiente;

                        if (Actual.codigo == codigo)
                        {
                            Actual.Siguiente = producto;
                            producto.Siguiente = temporal;
                            encontrado = true;
                        }
                        else
                        {
                            Actual = Actual.Siguiente;
                        }
                    }

                }
                else
                    MessageBox.Show("Error, lista vacia");

            }
        }


        public string reporte()
        {
            string mostrar = "";
            Producto Actual = Primero;

            if (Primero != null)
            {
                while (Actual != null)
                {
                    mostrar += Actual.ToString() + "\r\n";
                    Actual = Actual.Siguiente;
                }
            }
            else
                mostrar = "La lista no contiene elementos disponibles";

            return mostrar;
        }



    }

}
